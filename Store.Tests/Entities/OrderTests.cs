using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Entities
{

    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoEleDeveGerarUmNumeroCom8Caracteres()
        {
            var customer = new Customer("Leonardo", "Teste@gmail.com");
            var order = new Or
        }
    }
}
