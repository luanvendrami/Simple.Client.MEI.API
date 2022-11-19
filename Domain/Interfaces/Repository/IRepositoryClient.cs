using Domain.Models.RequestModels;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryClient
    {
        Task<bool> Create(ClientRequestModel clientRequest);
    }
}
