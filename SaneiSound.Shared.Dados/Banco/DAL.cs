using SenaiSound.Modelos;

namespace SenaiSound.Banco
{
    // T Indica que a classe dal representará uma classe genérica
    public class DAL<T> where T : class
    {
        private readonly SenaiSoundContext context;

        public DAL(SenaiSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void AdicionarObjeto(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void AtualizarObjeto(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
        public void RemoverObjeto(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

    }
}
