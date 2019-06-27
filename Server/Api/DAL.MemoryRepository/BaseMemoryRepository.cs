namespace DAL.MemoryRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core;

    using DAL.Abstractions;

    public class BaseMemoryRepository<TEntityInterface, TEntity> : IRepository<TEntityInterface>
        where TEntityInterface : class, IBaseEntity where TEntity : class, IBaseEntity, TEntityInterface, new()
    {
        private readonly Dictionary<Guid, TEntityInterface> _entities = new Dictionary<Guid, TEntityInterface>();

        public void Add(TEntityInterface item)
        {
            if (item.Id == default)
            {
                item.Id = Guid.NewGuid();
            }

            _entities.Add(item.Id, item);
        }

        public TEntityInterface FindById(Guid id)
        {
            return _entities[id];
        }

        public IEnumerable<TEntityInterface> Get()
        {
            return _entities.Values;
        }

        public IEnumerable<TEntityInterface> Get(Func<TEntityInterface, bool> func)
        {
            return _entities.Select(t => t.Value).Where(func);
        }

        public void Remove(TEntityInterface item)
        {
            if (_entities.ContainsKey(item.Id))
            {
                RemoveById(item.Id);
            }
        }

        public void Remove(Guid id)
        {
            RemoveById(id);
        }

        private void RemoveById(Guid id)
        {
            _entities.Remove(id);
        }
    }
}