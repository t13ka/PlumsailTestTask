namespace BLL
{
    using System;
    using System.Collections.Generic;

    using Core;

    public interface IEntitiesService
    {
        IEntity Add(string value);

        IEntity FindById(Guid id);

        IEnumerable<IEntity> Get();

        IEnumerable<IEntity> Get(string query);
    }
}