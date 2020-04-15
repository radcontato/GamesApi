using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XGames.Domain.Entities.Base;
using XGames.Domain.Interfaces.Repositories.Base;

namespace XGames.Infra.Persistence.Repositories.Base
{
    public class BaseRepository<TEntidade, TId> : IBaseRepository<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {

        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> ListBy(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> ListEOrderedBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }

        public TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> List(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListOrderedBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        }

        public TEntidade Create(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        public TEntidade ToEdit(TEntidade entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;

            return entidade;
        }

        public void Remove(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }
        public IEnumerable<TEntidade> AddToList(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public bool Exists(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}