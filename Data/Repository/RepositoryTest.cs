using Dapper;
using Data.Context;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryTest : IRepositoryTest
    {
        private ExodoDbSession _session;

        public RepositoryTest(ExodoDbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<string>> GetTest()
        {
            return await _session.Connection.QueryAsync<string>("Query hear", null, _session.Transaction);
        }
    }
}
