using Dapper;
using Microsoft.Data.SqlClient;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
	public class DiscountRepository : IDiscountRepository
	{
		private readonly SqlConnection _connection;
		public DiscountRepository(SqlConnection connection)
		{
			_connection = connection;
		}
		public Task<Discount> Get(string code)
		{
			var query = $"SELECT * FROM DISCOUNT WHERE CODE = {document}";
			return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new { document = document });
		}
	}
}
