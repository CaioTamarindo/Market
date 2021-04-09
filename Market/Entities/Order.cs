using System;
using Market.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace Market.Entities {
    class Order {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order() {
        }

        public Order(OrderStatus status, Client client) {    
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem) {
            OrderItem.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem) {
            OrderItem.Remove(orderItem);
        }

        public double Total() {
            double sum = 0;
            foreach(OrderItem orderItem in OrderItem) {
                sum += orderItem.SubTotal();
            }
            return sum;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append("(");
            sb.Append(Client.BirthDate);
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");
            
            foreach(OrderItem item in OrderItem) {
                sb.Append(item.Product);
                sb.Append(", $");
                sb.Append(item.Price);
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append("Subtotal: $");
                sb.Append(item.SubTotal());
            }
            sb.Append("Total price: $");

            return sb.ToString();
        }
    }
}
