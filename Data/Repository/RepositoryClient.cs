using Dapper;
using Data.Context;
using Domain.Interfaces.Repository;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        private ExodoDbSession _session;

        public RepositoryClient(ExodoDbSession session)
        {
            _session = session;
        }

        public async Task<List<FetchClientResponseModel>> FetchCLient(ClientRequestModel clientRequestModel)
        {
            var query = $@"
                            SELECT 
                              FirstName, 
                              LastName, 
                              Cpf,
                              BirthDate,
                              Email,
                              Phone
                            FROM 
                              Client 
                            {(clientRequestModel.FirstName == null && clientRequestModel.LastName == null && clientRequestModel.Cpf == null ? "" 
                            : $@"
                                WHERE 
                                  (
                                    FirstName LIKE '{clientRequestModel.FirstName}%' 
                                    OR FirstName = NULL
                                  ) 
                                  AND (
                                    LastName LIKE '{clientRequestModel.LastName}%' 
                                    OR LastName = NULL
                                  ) 
                                  OR (
                                    Cpf LIKE '{clientRequestModel.Cpf}%' 
                                    OR Cpf = NULL
                                  )
                                ")}
                             ";
            var result = _session.Connection.Query<FetchClientResponseModel>(query, new { clientRequestModel.FirstName, clientRequestModel.LastName, clientRequestModel.Cpf }, _session.Transaction);
            return await Task.FromResult(result.ToList());
        }

        public async Task<bool> Create(ClientRequestModel clientRequest)
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
    }
}
