using Domain.Dto;

namespace Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Tuple<List<string>, bool>> Create(ClientInputDto clientInputDto);
    }
}
