namespace SenaiSoundWEB.Requests
{
    using System.ComponentModel.DataAnnotations;

    public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento);
    public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento);
}
