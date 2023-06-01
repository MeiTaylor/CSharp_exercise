using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



using Microsoft.EntityFrameworkCore;




namespace HomeworkEighth
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=orderdb;user=root;password=Nkp030119+;",
                ServerVersion.AutoDetect("server=localhost;database=orderdb;user=root;password=Nkp030119+;"));
        }
    }


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

    public class OrderService
    {
        public OrderDbContext DbContext { get; set; }

        public OrderService()
        {
            DbContext = new OrderDbContext();
        }

        public void addOrder(Order obj)
        {
            if (DbContext.Orders.Any(order => order.OrderId == obj.OrderId))
            {
                throw new InvalidOperationException("该订单已经存在了，无法继续被录入");
            }
            DbContext.Orders.Add(obj);
            DbContext.SaveChanges();
        }

        public void deleteOrder(int orderID)
        {
            Order deleteOrder = DbContext.Orders.Include(order => order.OrderDetailsList).FirstOrDefault(order => order.OrderId == orderID);
            if (deleteOrder == null)
            {
                throw new InvalidOperationException("该订单不存在，删除失败");
            }
            DbContext.Orders.Remove(deleteOrder);
            DbContext.SaveChanges();
        }

public void changeOrder(Order changeOrder)
{
    var haveOrder = DbContext.Orders.Include(order => order.OrderDetailsList).FirstOrDefault(order => order.OrderId == changeOrder.OrderId);
    if (haveOrder == null)
    {
        throw new InvalidOperationException("要更新的订单不是已有的订单，请重试");
    }
    else
    {
        DbContext.Entry(haveOrder).CurrentValues.SetValues(changeOrder);
        haveOrder.OrderDetailsList.Clear();
        foreach (var detail in changeOrder.OrderDetailsList)
        {
            // 添加以下两行，将实体标记为不再受DbContext跟踪
            DbContext.Entry(detail).State = EntityState.Detached;
            detail.Id = 0; // 重置实体的主键，以便在添加到列表时生成新的主键

            haveOrder.OrderDetailsList.Add(detail);
        }
        DbContext.ChangeTracker.DetectChanges();
        DbContext.SaveChanges();
    }
}


        public List<Order> searchOrder(Func<Order, bool> sear)
        {
            return DbContext.Orders.Include(order => order.OrderDetailsList).Where(sear).OrderBy(order => order.totalPrice).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            // 在订单列表中查找匹配的订单ID
            Order order = DbContext.Orders.Include(o => o.OrderDetailsList).FirstOrDefault(o => o.OrderId == orderId);

            return order;
        }

        public void sortOrders()
        {
            var sortedList = DbContext.Orders.Include(order => order.OrderDetailsList).OrderBy(order => order.OrderId).ToList();

            foreach (var order in sortedList)
            {
                order.OrderDetailsList = order.OrderDetailsList.OrderBy(detail => detail.Name).ToList();
            }

            DbContext.SaveChanges();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new OrderDbContext())
            {
                context.Database.EnsureCreated();
            }




            OrderService orderService = new OrderService();

            //首先我们先添加订单
            Order order001 = new Order(001, "小明");
            Order order002 = new Order(002, "小红");
            Order order003 = new Order(003, "小绿");

            //添加订单的具体细节detail信息
            order001.OrderDetailsList.Add(new OrderDetails("奶茶", 3, 15));
            order001.OrderDetailsList.Add(new OrderDetails("果茶", 5, 13));

            order002.OrderDetailsList.Add(new OrderDetails("手机", 1, 2999));
            order002.OrderDetailsList.Add(new OrderDetails("手机壳", 5, 19));

            order003.OrderDetailsList.Add(new OrderDetails("衬衫", 4, 199));
            order003.OrderDetailsList.Add(new OrderDetails("鞋子", 2, 299));


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
                Console.WriteLine("添加订单时出现错误：" + ex.Message);
            }
            Console.WriteLine();


            //修改订单
            try
            {
                Order orderChange = new Order(2, "小红");
                orderChange.OrderDetailsList.Add(new OrderDetails("冰箱", 1, 4999));
                orderChange.OrderDetailsList.Add(new OrderDetails("彩电", 2, 1999));
                orderService.changeOrder(orderChange);
                Console.WriteLine("修改订单信息成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("修改订单时出现错误：" + ex.Message);
            }
            Console.WriteLine();

            //查询订单
            //通过订单号寻找
            var searchResults1 = orderService.searchOrder(order => order.OrderId == 002 || order.OrderId == 003);
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