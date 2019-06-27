namespace BLL
{
    using System;
    using System.Collections.Generic;

    using Core;

    using DAL.Abstractions;

    using Models;

    public class EntitiesService : IEntitiesService
    {
        private readonly IDataContext _dataContext;

        public EntitiesService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEntity Add(string value)
        {
            var item = new Entity { Value = value };

            _dataContext.EntitiesRepository.Add(item);

            return item;
        }

        public IEntity FindById(Guid id)
        {
            return _dataContext.EntitiesRepository.FindById(id);
        }

        public IEnumerable<IEntity> Get(string query)
        {
            return _dataContext.EntitiesRepository.Get(entity => entity.Value.Contains(query));
        }

        public IEnumerable<IEntity> Get()
        {
            return _dataContext.EntitiesRepository.Get();
        }
    }
}