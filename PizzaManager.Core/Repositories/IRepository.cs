using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaManager.Core.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
