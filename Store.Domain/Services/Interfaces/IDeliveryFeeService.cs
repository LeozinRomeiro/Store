using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Services.Interfaces
{
    public interface IDeliveryFeeService
    {
        decimal GetByZipCode(string zipCode);
    }
}
