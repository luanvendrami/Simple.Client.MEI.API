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

        public ClientService(IRepositoryClient repositoryClient, IMapper mapper)
        {
            _repositoryClient = repositoryClient;
            _mapper = mapper;
        }

        public async Task<Tuple<string, bool>> Create(ClientInputDto clientInputDto)
        {
            var clientRequest = _mapper.Map<ClientRequestModel>(clientInputDto);



            bool create = await _repositoryClient.Create();

            if (!create) 
            {
                return new Tuple<string, bool>("Failed to register customer.", false);
            }

            return new Tuple<string, bool>("Client registered successfully!", true);
        }
    }
}
