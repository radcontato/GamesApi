﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XGames.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntidade, TId>
        where TEntidade : class
        where TId : struct
    {

        IQueryable<TEntidade> ListBy(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListEOrderedBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        bool Exists(Func<TEntidade, bool> where);
        IQueryable<TEntidade> List(params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListOrderedBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade Create(TEntidade entidade);
        TEntidade ToEdit(TEntidade entidade);
        void Remove(TEntidade entidade);
        IEnumerable<TEntidade> AddToList(IEnumerable<TEntidade> entidades);
    }
}
