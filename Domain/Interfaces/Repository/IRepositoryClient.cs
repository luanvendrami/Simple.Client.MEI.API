namespace Domain.Interfaces.Repository
{
    public interface IRepositoryClient
    {
        Task<bool> Create();
    }
}
