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
    public class OrderDetailsTests
    {

        [TestMethod()]
        public void EqualsTest()
        {
            OrderDetails a = new OrderDetails("奶茶",23,235);
            OrderDetails b = new OrderDetails("奶茶",23,235);
            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            OrderDetails a = new OrderDetails("奶茶", 23, 235);
            string b = a.ToString();
            string c = $"商品名称为奶茶\t单个商品价格为235\t订单商品数量为23\t单个订单金额为5405";

            Assert.IsTrue (b.Equals(c));
        }
    }
}