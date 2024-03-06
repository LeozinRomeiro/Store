using Store.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Store.Domain.Repositories.Interfaces;

namespace Store.Domain.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly SqlConnection _connection;
        public CustomerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<Customer> GetByDocumentAsync(string document)
		{
			var query = $"SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE Id = {document}";
			return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new { document = document });
		}
	}
}
