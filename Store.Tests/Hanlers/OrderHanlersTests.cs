using Store.Domain.Commands;
using Store.Domain.Hanlers;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services.Interfaces;
using Store.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Hanlers
{
    [TestClass]
    public class OrderHanlersTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IDeliveryFeeService _deliveryfeeRepository;
        private readonly IProductRepository _productRepository;

        public OrderHanlersTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _orderRepository = new FakeOrderRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _deliveryfeeRepository = new FakeDeliveryFeeRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmClienteInexistenteOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.ZipCode = null;
            command.PromoCode = "13411080";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(_customerRepository, _orderRepository, _discountRepository, _deliveryfeeRepository, _productRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.IsValid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmCepInvalidoOPedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "13411080";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(_customerRepository, _orderRepository, _discountRepository, _deliveryfeeRepository, _productRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPromocodeInexistenteOPedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = null;
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(_customerRepository, _orderRepository, _discountRepository, _deliveryfeeRepository, _productRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPedidoSemItensOMesmoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";


            var handler = new OrderHandler(_customerRepository, _orderRepository, _discountRepository, _deliveryfeeRepository, _productRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.IsValid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoValidoOPedidoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(_customerRepository,_orderRepository,_discountRepository,_deliveryfeeRepository,_productRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.IsValid, true);
        }
    }
}
