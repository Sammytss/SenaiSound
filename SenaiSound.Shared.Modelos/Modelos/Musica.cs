namespace SenaiSound.Modelos;

public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
    }
    public Musica()
    {

    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoDeLancamento { get; set; }
    public virtual Artista? Artista { get; set; }
/*    public virtual ICollection<Genero>? Generos { get; set; }*/
    public int? ArtistaId { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}