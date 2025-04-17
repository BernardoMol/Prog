using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ScreenSound.Banco
{
    public class DAL<T> where T : class // define que estamos usando uma classe genérica
    {
        protected readonly ScreenSoundContext context; // é tipo privado, mas os herdeiros podem usar
        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> Listar()
        {
            // aqui o Set<T>() é um coringa, onde entraria a classe Artista ou Musica,
            // dependendo de qual classe estamos chamando. Isso so funnciona porque estamos com o contexto do EntityFramework
            return context.Set<T>().ToList();  
        }
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }
        public  T? RecuperarPor(Func<T,bool> parametro)
        {
            return context.Set<T>().FirstOrDefault(parametro); // parametro = condição de busca (nome, por exemplo seria a => a.Nome.Equals(nomeDoArtista) )
        }
    }
}