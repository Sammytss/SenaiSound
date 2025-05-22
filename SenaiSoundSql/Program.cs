using SenaiSound.Menus;
using SenaiSound.Modelos;
using SenaiSound.Banco;

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuAlterarDadosDoArtista());
opcoes.Add(4, new MenuMostrarArtistas());
opcoes.Add(5, new MenuMostrarMusicas());
opcoes.Add(0, new MenuSair());
/*
var context = new SenaiSoundContext();
var artistaDAL = new DAL<Artista>(context);
var mussicaDAL = new DAL<Musica>(context);
*/
void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗███████╗███╗░░██╗░█████╗░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔════╝████╗░██║██╔══██╗██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░█████╗░░██╔██╗██║███████║██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██╔══╝░░██║╚████║██╔══██║██║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝███████╗██║░╚███║██║░░██║██║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░╚══════╝╚═╝░░╚══╝╚═╝░░╚═╝╚═╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("Boas vindas ao Senai sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 alterar dados de um artista");
    Console.WriteLine("Digite 4 para mostrar todos os artistas");
    Console.WriteLine("Digite 5 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        /*menuASerExibido.Executar(*//*artistaDAL*//*);*/
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();