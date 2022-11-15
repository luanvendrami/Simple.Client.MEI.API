using Domain.Dto;

namespace Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Tuple<string, bool>> Create(ClientInputDto clientInputDto);
    }
}
