using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjetoFinalEletronicos
{
    public class BaseServico<T> where T : class
    {
        public virtual IList<T> Listar()
        {
            using (var contexto = new BaseContexto())
            {
                return contexto.Set<T>().ToList();
            }
        }
        public virtual IList<T> Listar<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            using (var contexto = new BaseContexto())
            {
                var query = contexto.Set<T>().AsQueryable();
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query.AsNoTracking().ToList();
            }
        }

        public virtual T Selecionar(int id)
        {
            using (var contexto = new BaseContexto())
            {
                return contexto.Set<T>().Find(id);
            }
        }

        public virtual void Adicionar(T item)
        {
            using (var contexto = new BaseContexto())
            {
                contexto.Set<T>().Add(item);
                contexto.SaveChanges();
            }
        }

        public virtual void Excluir(T item)
        {
            using (var contexto = new BaseContexto())
            {
                contexto.Entry<T>(item).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public virtual void Atualiza(T item)
        {
            using (var contexto = new BaseContexto())
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
