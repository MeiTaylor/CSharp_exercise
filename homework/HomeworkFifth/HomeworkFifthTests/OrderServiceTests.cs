using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeworkFifth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFifth.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        public OrderService orderService;

        [TestInitialize]
        public void Setup()
        {
            orderService = new OrderService();
        }

        [TestMethod()]
        public void addOrderTest()
        {
            var order = new Order(1, "Customer A");
            orderService.addOrder(order);

            Assert.IsTrue(orderService.sumOrder.Contains(order));
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            var order = new Order(1, "小李");
            orderService.addOrder(order);

            orderService.deleteOrder(order.OrderId);

            Assert.IsFalse(orderService.sumOrder.Contains(order));
        }

        [TestMethod()]
        public void changeOrderTest()
        {
            var order = new Order(1, "小白");
            orderService.addOrder(order);

            var changeOrder = new Order(1, "小蓝");
            orderService.changeOrder(changeOrder);

            Assert.AreEqual(changeOrder, orderService.sumOrder.First());
        }

        [TestMethod()]
        public void searchOrderTest()
        {
            var order1 = new Order(1, "小张");
            var order2 = new Order(2, "小周");
            orderService.addOrder(order1);
            orderService.addOrder(order2);

            var searchResults = orderService.searchOrder(order => order.Customer == "小周");

            Assert.AreEqual(1, searchResults.Count());
            Assert.AreEqual(order1, searchResults.First());
        }

        [TestMethod()]
        public void sortOrdersTest()
        {
            var order1 = new Order(1, "小张");
            var order2 = new Order(2, "小周");
            orderService.addOrder(order1);
            orderService.addOrder(order2);

            orderService.sortOrders();

            Assert.AreEqual(order2, orderService.sumOrder[0]);
            Assert.AreEqual(order1, orderService.sumOrder[1]);
        }
    }
}