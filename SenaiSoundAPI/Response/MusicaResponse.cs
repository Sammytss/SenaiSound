namespace SenaiSoundAPI.Response
{
    public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoDeLancamento);
}
