namespace HomeworkNinth.Models
{
    public class OrderDetails
    {
        public int Id { get; set; } // 添加此行
        public string Name { get; set; }
        public int Amount { get; set; }
        public int SinglePrice { get; set; }
        public int totalEveryPrice => SinglePrice * Amount;
        public int OrderId { get; set; } // 添加此行
        public Order Order { get; set; } // 添加此行

        public OrderDetails(string name, int amount, int singlePrice)
        {
            Name = name;
            Amount = amount;
            SinglePrice = singlePrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OrderDetails))
            {
                return false;
            }
            OrderDetails orderDetail_obj = (OrderDetails)obj;

            return orderDetail_obj.Name == this.Name &&
                orderDetail_obj.SinglePrice == this.SinglePrice &&
                orderDetail_obj.Amount == this.Amount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }



        public override string ToString()
        {
            return $"商品名称为{Name}\t单个商品价格为{SinglePrice}\t订单商品数量为{Amount}\t单个订单金额为{totalEveryPrice}";
        }
    }


}
