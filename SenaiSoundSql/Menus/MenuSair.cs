using SenaiSound.Banco;
using SenaiSound.Modelos;

namespace SenaiSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
