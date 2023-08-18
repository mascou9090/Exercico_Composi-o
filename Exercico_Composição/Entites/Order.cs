using Exercicio_Composição.Entites.Enums;
using System.Text;

namespace Exercicio_Composição.Entites
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item) { Items.Add(item); }
        public void RemoveItem(OrderItem item) { Items.Remove(item); }
        public double Total()
        {
            double totalSum = 0;
            foreach (OrderItem item in Items)
            {
                totalSum += item.Quantity * item.Price;
            }
            return totalSum;
        }

        public override string ToString()
        {
                StringBuilder formatedSaid = new StringBuilder();
            formatedSaid.AppendLine("ORDER SUMMARY:");
            formatedSaid.Append("Order moment: ");
            formatedSaid.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            formatedSaid.Append("Order status: ");
            formatedSaid.AppendLine(Status.ToString());
            formatedSaid.AppendLine(Client.ToString());
            formatedSaid.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                formatedSaid.AppendLine(item.Product.Name + ", $ " + item.Product.Price + "Quantity: " + item.Quantity + ", Subtotal: $" + item.SubTotal().ToString());
            }
            return formatedSaid.ToString();
        }
    }
}
