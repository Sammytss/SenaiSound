/*using Microsoft.AspNetCore.Mvc;
using SenaiSound.Banco;
using SenaiSound.Modelos;

namespace SenaiSoundAPI.EndPoints
{
    public static class GenerosExtencoes
    {
        public static void AddEndPointsGeneros(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
            {
                var genero = Results.Ok(dal.Listar());
                return genero;
            });
            app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
            {
                var genero = dal.RecuperarPor(g => g.Nome!.ToUpper().Equals(nome.ToUpper()));
                if (genero is null)
                {
                    return Results.NotFound("Genero não encontrado!");
                }
                return Results.Ok(genero);
            });
            app.MapPost("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] Genero genero) =>
            {
                dal.AdicionarObjeto(genero);
                return Results.Created($"/Generos/{genero.Id}", genero);
            });
            app.MapDelete("/Generos/{Id}", ([FromServices] DAL<Genero> dal, int id) =>
            {
                var genero = dal.RecuperarPor(g => g.Id.Equals(id));
                if (genero is null)
                {
                    return Results.NotFound("Generos não encontrado!");
                }
                dal.RemoverObjeto(genero);
                return Results.NoContent();
            });
            app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] Genero genero) =>
            {
                var generoAAtualizar = dal.RecuperarPor(g => g.Id.Equals(genero.Id));
                if (generoAAtualizar is null)
                {
                    return Results.NotFound("Genero não encontrado!");
                }
                generoAAtualizar.Nome = genero.Nome;
                generoAAtualizar.Descricao = genero.Descricao;
                dal.AtualizarObjeto(generoAAtualizar);
                return Results.Ok();
            });
        }
    }
}
*/