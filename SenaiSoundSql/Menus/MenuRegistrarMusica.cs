using SenaiSound.Banco;
using SenaiSound.Modelos;

namespace SenaiSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));
        if (artistaRecuperado is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da música: ");
            int anoLancamento = int.Parse(Console.ReadLine()!);
            artistaRecuperado.AdicionarMusica(new Musica(tituloDaMusica) { AnoDeLancamento = anoLancamento });
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            artistaDAL.AtualizarObjeto(artistaRecuperado);
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
/*using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundSql.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));
        if (artistaRecuperado is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da música: ");
            int anoLancamento = int.Parse(Console.ReadLine()!);

            // Solicitar os gêneros da música
            Console.Write("Digite os gêneros da música separados por vírgula: ");
            string entradaGeneros = Console.ReadLine()!;
            var listaDeGeneros = entradaGeneros
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(nomeGenero => new Genero { Nome = nomeGenero.Trim() })
                .ToList();

            // Criar a música com os gêneros associados
            var novaMusica = new Musica(tituloDaMusica)
            {
                AnoDeLancamento = anoLancamento,
                Generos = listaDeGeneros
            };

            artistaRecuperado.AdicionarMusica(novaMusica);
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            artistaDAL.AtualizarObjeto(artistaRecuperado);
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}*/