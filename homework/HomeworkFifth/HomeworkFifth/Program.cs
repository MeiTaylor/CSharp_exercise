using System.Linq;

namespace HomeworkFifth
{


    public class OrderDetails
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int SinglePrice { get; set; }
        public int totalEveryPrice => SinglePrice * Amount;

        public OrderDetails(string name, int amount, int single_price)
        {
            Name = name;
            Amount = amount;
            SinglePrice = single_price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OrderDetails))
            {
                return false;
            }
            OrderDetails orderDetail_obj = (OrderDetails)obj;

            return orderDetail_obj.Name == this.Name &&
                orderDetail_obj.SinglePrice ==this.SinglePrice &&
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

    public class Order: IComparable<Order>
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }


        public int totalPrice => OrderDetailsList.Sum(OrderDetails => OrderDetails.totalEveryPrice);
        public LinkedList<OrderDetails> OrderDetailsList { get; set; }
        public Dictionary<int, OrderDetails> OrderDetailsDictionary { get; set; }

        public Order(int orderId,string customer)
        {
            this.OrderId = orderId;
            this.Customer = customer;
            OrderDetailsList = new LinkedList<OrderDetails>();
            OrderDetailsDictionary = new Dictionary<int, OrderDetails>();
        }

        public void Add(OrderDetails obj)
        {
            OrderDetailsList.AddLast(obj);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   this.OrderId == order.OrderId&&
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

    }

    public class OrderService
    {
        public List<Order> sumOrder { get; set; }
        public OrderService()
        {
            sumOrder = new List<Order>();
        }

        public void addOrder(Order obj)
        {
            if (sumOrder.Contains(obj))
            {
                throw new InvalidOperationException("该订单已经存在了，无法继续被录入");
            }
            sumOrder.Add(obj);
        }

        public void deleteOrder(int orderID)
        {
            Order deleteOrder = sumOrder.FirstOrDefault(order => order.OrderId == orderID);
            if (deleteOrder == null)
            {
                throw new InvalidOperationException("该订单不存在，删除失败");
            }
            sumOrder.Remove(deleteOrder);
        }

        public void changeOrder (Order changeOrder)
        {
            var haveOrder = sumOrder.FirstOrDefault(order => order.OrderId == changeOrder.OrderId);
            if (haveOrder==null)
            {
                throw new InvalidOperationException("要更新的订单不是已有的订单，请重试");
            }
            else{
                sumOrder[sumOrder.IndexOf(haveOrder)] = changeOrder;
            }
        }

        public List<Order> searchOrder(Func<Order, bool> sear)
        {
            return sumOrder.Where(sear).OrderBy(order => order.totalPrice).ToList();
        }

        public void sortOrders()
        {
            sumOrder.Sort();
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {

            OrderService orderService = new OrderService();

            //首先我们先添加订单
            Order order001 = new Order(001, "小明");
            Order order002 = new Order(002, "小红");
            Order order003 = new Order(003, "小绿");

            //添加订单的具体细节detail信息
            order001.OrderDetailsList.AddLast(new OrderDetails("奶茶", 3, 15));
            order001.OrderDetailsList.AddLast(new OrderDetails("果茶", 5, 13));

            order002.OrderDetailsList.AddLast(new OrderDetails("手机", 1, 2999));
            order002.OrderDetailsList.AddLast(new OrderDetails("手机壳", 5, 19));

            order003.OrderDetailsList.AddLast(new OrderDetails("衬衫", 4, 199));
            order003.OrderDetailsList.AddLast(new OrderDetails("鞋子", 2, 299));


            //访问订单信息以及订单明细的信息

            Console.WriteLine(order001.ToString());
            foreach (OrderDetails item in order001.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(order003.ToString());
            foreach (OrderDetails item in order003.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(order002.ToString());
            foreach (OrderDetails item in order002.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();





            //添加订单
            try
            {
                orderService.addOrder(order001);
                orderService.addOrder(order003);
                orderService.addOrder(order002);

                Console.WriteLine("成功添加三个订单");
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加订单时出现错误："+ex.Message);
            }
            Console.WriteLine();


            //修改订单
            try
            {
                Order orderChange = new Order(2, "小红");
                orderChange.OrderDetailsList.AddLast(new OrderDetails("冰箱",1,4999));
                orderChange.OrderDetailsList.AddLast(new OrderDetails("彩电",2,1999));
                orderService.changeOrder(orderChange);
                Console.WriteLine("修改订单信息成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("修改订单时出现错误："+ex.Message);
            }
            Console.WriteLine();

            //查询订单
            //通过订单号寻找
            var searchResults1 = orderService.searchOrder(order => order.OrderId == 002||order.OrderId==003);
            foreach (var result in searchResults1)
            {
                Console.WriteLine(result.ToString());
                foreach (var item in result.OrderDetailsList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            //通过商品名称查询
            var searchResults2 = orderService.searchOrder(order => order.OrderDetailsList.Any(detail => detail.Name == "鞋子"));
            foreach (var result in searchResults2)
            {
                Console.WriteLine(result.ToString());
                foreach (var item in result.OrderDetailsList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine();


            //排序
            orderService.sortOrders();
            Console.WriteLine("排序完成啦");


            //访问订单信息以及订单明细的信息

            Console.WriteLine(order001.ToString());
            foreach (OrderDetails item in order001.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(order002.ToString());
            foreach (OrderDetails item in order002.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(order003.ToString());
            foreach (OrderDetails item in order003.OrderDetailsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();


        }
    }



}