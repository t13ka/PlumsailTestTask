namespace DAL.Abstractions
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T>
        where T : class
    {
        void Add(T item);

        T FindById(Guid id);

        IEnumerable<T> Get();

        IEnumerable<T> Get(Func<T, bool> func);

        void Remove(T item);

        void Remove(Guid id);
    }
}