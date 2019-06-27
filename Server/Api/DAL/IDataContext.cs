namespace DAL.Abstractions
{
    public interface IDataContext
    {
        IEntitiesRepository EntitiesRepository { get; }
    }
}