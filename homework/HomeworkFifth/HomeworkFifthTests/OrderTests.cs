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
    public class OrderTests
    {


        [TestMethod()]
        public void AddTest()
        {
            var order = new Order(1, "小王");
            var orderDetails = new OrderDetails("奶茶", 23, 9);
            order.Add(orderDetails);

            Assert.IsTrue(order.OrderDetailsList.Contains(orderDetails));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var order1 = new Order(1, "Customer A");
            var order2 = new Order(1, "Customer A");

            Assert.IsTrue(order1.Equals(order2));
        }





        [TestMethod()]
        public void ToStringTest()
        {
            var order = new Order(1, "小王");
            var orderDetails = new OrderDetails("奶茶", 23, 9);
            order.Add(orderDetails);

            string expectedToString = "订单号为1\t客户为小王\t订单总金额为20";
            Assert.AreEqual(expectedToString, order.ToString());
        }
    }
}