using Microsoft.AspNetCore.Mvc;
using SenaiSoundAPI.Requests;
using SenaiSound.Banco;
using SenaiSound.Modelos;
using SenaiSoundAPI.Response;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SenaiSoundAPI.EndPoints
{
    public static class ArtistasExtencoes
    {

        public static void AddEndPointsArtistas(this WebApplication app)
        {


            app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
            {
                var artistas = dal.Listar();
                if (artistas is null)
                {
                    return Results.NotFound();
                }
                var listaDeArtistaResponse = EntityListToResponseList(artistas);
                return Results.Ok(listaDeArtistaResponse);
            });
            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                return Results.Ok(EntityToResponse(artista));
            });

            // Post de artista Request
            //•	O atributo [FromServices] indica que o parâmetro dal
            //será injetado pelo Dependency Injection (DI) do ASP.NET Core.

            //•	O atributo [FromBody] indica que o parâmetro
            //artistaRequest será preenchido com os dados enviados no corpo da requisição HTTP.
            app.MapPost("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var nome = artistaRequest.nome.Trim();
                var imagemArtista = DateTime.Now.ToString("ddMMyyyhhss") + "." + nome + ".jpg";

                var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosDePerfil", imagemArtista);

                using MemoryStream ms = new MemoryStream(Convert.FromBase64String
                    (artistaRequest.fotoPerfil!));
                using FileStream fs = new(path, FileMode.Create);
                await ms.CopyToAsync(fs);

                var artista = new Artista(artistaRequest.nome, artistaRequest.bio)
                {
                    FotoPerfil = $"/FotosDePerfil/{imagemArtista}"
                };

                if (dal.RecuperarPor(a => a.Nome.Equals(artistaRequest.nome)) is null)
                {
                    dal.AdicionarObjeto(artista);
                    return Results.Created($"/Artistas/{artista.Id}", artista);
                }
                return Results.Conflict($"{artista.Nome} já existe. ");

            });

            app.MapDelete("/Artistas/{Id}", ([FromServices] DAL<Artista> dal, int id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id.Equals(id));
                if (artista is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                dal.RemoverObjeto(artista);
                return Results.NoContent();
            });

            app.MapPut("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
            {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id.Equals(artistaRequestEdit.Id));
                if (artistaAAtualizar is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }

                // Atualiza os dados básicos
                artistaAAtualizar.Nome = artistaRequestEdit.nome;
                artistaAAtualizar.Bio = artistaRequestEdit.bio;

                // Verifica se uma nova foto foi enviada
                if (!string.IsNullOrEmpty(artistaRequestEdit.fotoPerfil))
                {
                    var imagemArtista = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + artistaRequestEdit.nome + ".jpg";
                    var caminhoFisico = Path.Combine(env.ContentRootPath, "wwwroot", "FotosDePerfil", imagemArtista);

                    // Salva a nova foto no servidor
                    Directory.CreateDirectory(Path.GetDirectoryName(caminhoFisico)!);
                    using var ms = new MemoryStream(Convert.FromBase64String(artistaRequestEdit.fotoPerfil));
                    using var fs = new FileStream(caminhoFisico, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    // Atualiza o caminho da foto no banco de dados
                    artistaAAtualizar.FotoPerfil = $"/FotosDePerfil/{imagemArtista}";
                }

                dal.AtualizarObjeto(artistaAAtualizar);
                return Results.Ok();
            });

        }
        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> artistas)
        {
            return artistas.Select(a => EntityToResponse(a)).ToList();
        }

        private static ArtistaResponse EntityToResponse(Artista artista)
        {
            return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
        }
    }

}
