using Dapper;
using Data.Context;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        private ExodoDbSession _session;

        public RepositoryClient(ExodoDbSession session)
        {
            _session = session;
        }

        public async Task<bool> Create()
        {
            return await _session.Connection.QuerySingleAsync<bool>("Query hear", null, _session.Transaction);
        }
    }
}
