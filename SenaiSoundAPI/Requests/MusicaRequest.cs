namespace SenaiSoundAPI.Requests
{
    using System.ComponentModel.DataAnnotations;

    public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoDeLancamento);
    public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoDeLancamento)
    : MusicaRequest(nome, ArtistaId, anoDeLancamento);
}
