using HomeworkNinth.DbContexts;
using HomeworkNinth.Models;

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

