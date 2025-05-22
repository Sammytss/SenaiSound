using SenaiSound.Banco;
using SenaiSound.Modelos;


namespace SenaiSound.Menus
{
    internal class MenuAlterarDadosDoArtista : Menu
    {
        public override void Executar(DAL<Artista> artistaDAL)
        {
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Alterar dados do artista");
            Console.WriteLine("Digite o nome do artista que deseja atualizar: ");
            string nomeDoArtista = (Console.ReadLine()!);
            var artistasRecuperados = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));
            if (artistasRecuperados is not null)
                {
                Console.WriteLine("O que você pretende atualizar no artista: ");
                Console.WriteLine($"1 - Nome atual: {artistasRecuperados.Nome}");
                Console.WriteLine($"2 - Bio atual: {artistasRecuperados.Bio}");
                Console.WriteLine($"3 - Todos os dados: ");
                string respostaAtalizar = Console.ReadLine()!;
                if (int.TryParse(respostaAtalizar, out int respostaNumerica))
                {

                    if (respostaNumerica == 1)
                    {
                        Console.Write("Digite o novo nome do artista: ");
                        string novoNome = Console.ReadLine()!;
                        artistasRecuperados.Nome = novoNome;
                        artistaDAL.AtualizarObjeto(artistasRecuperados);
                    }
                    else if (respostaNumerica == 2)
                    {
                        Console.Write("Digite a nova bio do artista: ");
                        string novaBio = Console.ReadLine()!;
                        artistasRecuperados.Bio = novaBio;
                        artistaDAL.AtualizarObjeto(artistasRecuperados);
                    }
                    else if (respostaNumerica == 3)
                    {
                        Console.Write("Digite o novo nome do artista: ");
                        string novoNome = Console.ReadLine()!;
                        Console.Write("Digite a nova bio do artista: ");
                        string novaBio = Console.ReadLine()!;
                        artistasRecuperados.Nome = novoNome;
                        artistasRecuperados.Bio = novaBio;
                        artistaDAL.AtualizarObjeto(artistasRecuperados);
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                    Console.WriteLine($"Os dados do artista {artistasRecuperados.Nome} foram alterados com sucesso!");
                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Artista não encontrado.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
