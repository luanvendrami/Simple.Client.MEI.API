using Dapper;
using Data.Context;
using Domain.Interfaces.Repository;
using Domain.Models.RequestModels;

namespace Data.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        private ExodoDbSession _session;

        public RepositoryClient(ExodoDbSession session)
        {
            _session = session;
        }

        public async Task<bool> Create(ClientRequestModel clientRequest)
        {
            try
            {
                var query = $@"
                            INSERT INTO
                               Client
                               (
                                FirstName,
                                LastName,
                                Cpf,
                                BirthDate,
                                Email,
                                Phone
                               )
                            VALUES
                               (
                                  @FirstName, @LastName, @Cpf,'{clientRequest.BirthDate.ToString("yyyyMMdd")}', @Email, @Phone
                               )";
                var result = !await _session.Connection.QueryFirstOrDefaultAsync<bool>(query, new { clientRequest.FirstName, clientRequest.LastName, clientRequest.Cpf, clientRequest.Email, clientRequest.Phone }, _session.Transaction);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                var error = ex;
                throw;
            }
            
        }
    }
}
