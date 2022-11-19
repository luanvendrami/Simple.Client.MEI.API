using Domain.Dto;
using Domain.Models.ResponseModels;

namespace Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Tuple<List<string>, bool>> Create(ClientInputDto clientInputDto);
        Task<Tuple<List<string>, bool, List<FetchClientResponseModel>>> FetchClient(FetchClientInputDto fetchClientInputDto);
    }
}
