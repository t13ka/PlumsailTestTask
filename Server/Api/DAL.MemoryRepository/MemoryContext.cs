namespace DAL.MemoryRepository
{
    using DAL.Abstractions;

    public class MemoryContext : IDataContext
    {
        public MemoryContext()
        {
            EntitiesRepository = new EntitiesRepository();
        }

        public IEntitiesRepository EntitiesRepository { get; }
    }
}