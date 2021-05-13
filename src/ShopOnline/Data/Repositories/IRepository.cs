﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {

        // Repository pattern
        T add(T model);
        bool update(T model);
        T delete(int id);
        T delete(T model);

        ICollection<T> findAll();

        ICollection<T> findAll(string[] includes = null);
        ICollection<T> findByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        T findById(int id);

    }
}
