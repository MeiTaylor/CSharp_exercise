using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeworkNinth.Models
{
    public class Order : IComparable<Order>
    {

        [Key] // 添加此行
        public int OrderId { get; set; }

        //public int OrderId { get; set; }
        public string Customer { get; set; }



        public int totalPrice => OrderDetailsList.Sum(OrderDetails => OrderDetails.totalEveryPrice);

        [ForeignKey("OrderId")] // 添加此行
        public List<OrderDetails> OrderDetailsList { get; set; }
        //public Dictionary<int, OrderDetails> OrderDetailsDictionary { get; set; }

        public Order(int orderId, string customer)
        {
            this.OrderId = orderId;
            this.Customer = customer;
            OrderDetailsList = new List<OrderDetails>();
            //  OrderDetailsDictionary = new Dictionary<int, OrderDetails>();
        }

        public void Add(OrderDetails obj)
        {
            OrderDetailsList.Add(obj);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   this.OrderId == order.OrderId &&
                   this.Customer == order.Customer &&
                   this.OrderDetailsList == order.OrderDetailsList;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId);
        }

        public int CompareTo(Order other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.OrderId.CompareTo(other.OrderId);
        }

        public override string ToString()
        {
            return $"订单号为{OrderId}\t客户为{Customer}\t订单总金额为{totalPrice}";
        }

        public void removeOrderDetailByName(string productName)
        {
            // 找到与给定商品名称匹配的订单详细信息
            var orderDetail = OrderDetailsList.FirstOrDefault(od => od.Name == productName);

            if (orderDetail != null)
            {
                // 删除订单详细信息
                OrderDetailsList.Remove(orderDetail);
            }
        }

    }


}
