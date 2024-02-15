using Store.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTest
    {
        [TestMethod]
        [TestCategory("Hanlers")]
        public void DadoUmComandoInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Validate();

            Assert.AreEqual(command.IsValid, false);
        }
    }
}
