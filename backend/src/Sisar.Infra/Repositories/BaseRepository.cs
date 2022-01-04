#region Namespaces

using Microsoft.EntityFrameworkCore;
using Sisar.Domain.Entities;
using Sisar.Infra.Context;
using Sisar.Infra.Interfaces;

#endregion

namespace Sisar.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        #region Propriedade

        private readonly SisarContext _context;

        #endregion

        #region Construtor

        public BaseRepository(SisarContext context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        public virtual async Task<T> Create(T obj)
        {
            obj.DtCriacao = DateTime.Now;
            obj.DtEdicao = DateTime.Now;
            obj.Ativo = true;
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            obj.DtEdicao = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                    .AsNoTracking()
                                    .ToListAsync();

        }

        #endregion
    }
}
