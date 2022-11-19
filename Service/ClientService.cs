using AutoMapper;
using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;

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

        public async Task<Tuple<List<string>, bool, List<FetchClientResponseModel>>> FetchClient(FetchClientInputDto fetchClientInputDto)
        {
            var clientRequest = _mapper.Map<ClientRequestModel>(fetchClientInputDto);
            ;

            if (!clientRequest.Validations())
            {
                return new Tuple<List<string>, bool, List<FetchClientResponseModel>>(clientRequest.Message, false, null);
            }

            List<FetchClientResponseModel> clients = await _repositoryClient.FetchCLient(clientRequest);

            if (!clients.Any())
            {
                ResultMessage.Add("Failed to fetch customer.");
                return new Tuple<List<string>, bool, List<FetchClientResponseModel>>(ResultMessage, false, null);
            }
            return new Tuple<List<string>, bool, List<FetchClientResponseModel>>(null, true, clients);
        }

        public async Task<Tuple<List<string>, bool>> Create(ClientInputDto clientInputDto)
        {
            var clientRequest = _mapper.Map<ClientRequestModel>(clientInputDto);

            if (!clientRequest.Validations())
            {
                return new Tuple<List<string>, bool>(clientRequest.Message, false);
            }

            bool create = await _repositoryClient.Create(clientRequest);

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
