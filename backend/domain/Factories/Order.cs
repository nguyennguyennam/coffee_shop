using aggregates.Customer;
using aggregates.Order;
using entities.OrderItem;
using entities.Voucher;

namespace Factories.OrderFactory
{
    public static class OrderFactory
    {
        public static Order CreateOrder(
            Guid customerId,
            Guid? voucherId,
            DateTime orderDate,
            string status,
            List<OrderItem> orderItems,
            double totalPrice,
            Voucher? voucher,
            CustomerType customerType
        )
        {
            if (orderItems == null || orderItems.Count == 0)
            {
                throw new ArgumentException("Order items cannot be null or empty.", nameof(orderItems));
            }
            if (totalPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalPrice), "Total price cannot be negative.");
            }
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));
            }

            var order = new Order(customerId, voucherId, orderDate, status, orderItems, totalPrice, voucher, customerType);
            return order;
        }
    }
}