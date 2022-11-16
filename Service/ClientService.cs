using AutoMapper;
using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Models.RequestModels;

namespace Service
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryClient _repositoryClient;
        private readonly IMapper _mapper;
        private readonly List<string> ResultMessage = new();

        public ClientService(IRepositoryClient repositoryClient, IMapper mapper)
        {
            _repositoryClient = repositoryClient;
            _mapper = mapper;
        }

        public async Task<Tuple<List<string>, bool>> Create(ClientInputDto clientInputDto)
        {
            var clientRequest = _mapper.Map<ClientRequestModel>(clientInputDto);

            if (!clientRequest.Validations())
            {
                return new Tuple<List<string>, bool>(clientRequest.Message, false);
            }

            bool create = await _repositoryClient.Create();

            if (!create) 
            {
                ResultMessage.Add("Failed to register customer.");
                return new Tuple<List<string>, bool>(ResultMessage, false);
            }
            ResultMessage.Add("Client registered successfully!");
            return new Tuple<List<string>, bool>(ResultMessage, true);
        }
    }
}
