using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;

namespace Service
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryClient _repositoryClient;

        public ClientService(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public async Task<Tuple<string, bool>> Create()
        {
            bool create = await _repositoryClient.Create();

            if (!create) 
            {
                return new Tuple<string, bool>("\r\nFailed to register customer.", false);
            }

            return new Tuple<string, bool>("\r\nClient registered successfully!", true);
        }
    }
}
