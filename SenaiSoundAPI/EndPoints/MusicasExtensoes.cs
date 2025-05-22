using Microsoft.AspNetCore.Mvc;
using SenaiSoundAPI.Requests;
using SenaiSound.Banco;
using SenaiSound.Modelos;
using SenaiSoundAPI.Response;

namespace SenaiSoundAPI.EndPoints
{
    public static class MusicasExtensoes
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                var musicas = dal.Listar();
                if (musicas is null)
                {
                    return Results.NotFound();
                }
                var musicaListResponse = EntityListToResponseList(musicas);
                return Results.Ok(musicaListResponse);
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return Results.NotFound("Música não encontrada!");
                }
                return Results.Ok(EntityToResponse(musica));
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome)
                {
                    ArtistaId = musicaRequest.ArtistaId,
                    AnoDeLancamento = musicaRequest.anoDeLancamento
                };
                if (dal.RecuperarPor(m => m.Nome.Equals(musicaRequest.nome)) is null)
                {
                    dal.AdicionarObjeto(musica);
                    return Results.Created($"/Musicas/{musica.Id}", musica);
                }
                return Results.Conflict($"{musica.Nome} já existe. ");
            });

            app.MapDelete("/Musicas/{Id}", ([FromServices] DAL<Musica> dal, int id) =>
            {
                var musica = dal.RecuperarPor(a => a.Id.Equals(id));
                if (musica is null)
                {
                    return Results.NotFound("Música não encontrada!");
                }
                dal.RemoverObjeto(musica);
                return Results.NoContent();
            });

        }
        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicas)
        {
            return musicas.Select(m => EntityToResponse(m)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome, musica.AnoDeLancamento);
        }
    }
}
