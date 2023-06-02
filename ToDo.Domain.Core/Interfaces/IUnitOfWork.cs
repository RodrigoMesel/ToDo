namespace ToDo.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
