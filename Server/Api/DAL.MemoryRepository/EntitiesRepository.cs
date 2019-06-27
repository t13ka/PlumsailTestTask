namespace DAL.MemoryRepository
{
    using Core;

    using Models;

    public class EntitiesRepository : BaseMemoryRepository<IEntity, Entity>, IEntitiesRepository
    {
    }
}