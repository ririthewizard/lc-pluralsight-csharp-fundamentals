using System.Text;

namespace BethanysPieShop.InventoryManagement
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime OrderFulfillmentDate { get; private set; }

        public List<OrderItem> OrderItems { get; }

        public bool Fulfilled { get; set; } = false;

        public Order()
        {
            Id = new Random().Next(9999999);

            int numberOfSeconds = new Random().Next(100);
            OrderFulfillmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

            OrderItems = new List<OrderItem>();
        }

        public string ShowOrderDetails()
        {
            StringBuilder orderDetails = new StringBuilder();

            orderDetails.AppendLine($"Order ID: {Id}");
            orderDetails.AppendLine($"Order fulfillment date: {OrderFulfillmentDate.ToShortTimeString()}");

            if (OrderItems != null)
            {
                foreach (OrderItem item in OrderItems)
                {
                    orderDetails.AppendLine();
                }
            }

            return orderDetails.ToString();
        }
    }
}
