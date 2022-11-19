using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryClient
    {
        Task<bool> Create(ClientRequestModel clientRequest);
        Task<List<FetchClientResponseModel>> FetchCLient(ClientRequestModel clientRequestModel);
    }
}
