using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Utils;
using Store.Tests.Hanlers.Interfaces;

namespace Store.Domain.Hanlers
{
    public class OrderHandler : Notifiable<Notification>, IHanlers<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IDeliveryFeeRepository _deliveryfeeRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandler(ICustomerRepository customerRepository, IOrderRepository orderRepository, IDiscountRepository discountRepository, IDeliveryFeeRepository deliveryfeeRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _discountRepository = discountRepository;
            _deliveryfeeRepository = deliveryfeeRepository;
            _productRepository = productRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
            }
            var customer = _customerRepository.Get(command.Customer);
            var deliveryFee = _deliveryfeeRepository.Get(command.ZipCode);
            var discount = _discountRepository.Get(command.ZipCode);
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items).ToList());
            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }
            AddNotifications(order.Notifications);

            if (!IsValid)
            {
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
            }

            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }
    }
}
