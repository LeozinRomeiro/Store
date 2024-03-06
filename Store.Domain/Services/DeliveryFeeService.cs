using RestSharp;
using Store.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
	public class DeliveryFeeService : IDeliveryFeeService
	{
		public async Task<decimal> GetByZipCode(string zipCode)
		{
			var client = new RestClient("https://api.myorg.com/");
			var request = new RestRequest().AddJsonBody(new { ZipCode = zipCode });
			var response = await client.PostAsync<decimal>(request);
			return response <5 ? 5 : response;	
		}
	}
}
