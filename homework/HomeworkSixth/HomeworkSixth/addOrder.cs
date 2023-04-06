using HomeworkFifth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeworkSixth
{
    public partial class addOrder : Form
    {
        private OrderService newOrderService;

        public addOrder(OrderService orderService)
        {
            InitializeComponent();
            newOrderService = orderService;
        }


        public addOrder()
        {
            InitializeComponent();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 从输入控件中获取订单信息并创建新的 Order 对象
            int orderId = int.Parse(textBox1.Text);
            string customerName = textBox2.Text;
            Order newOrder = new Order(orderId, customerName);

            // 从输入控件中获取订单明细信息并创建新的 OrderDetail 对象
            string productName = textBox3.Text;
            int number = int.Parse(textBox4.Text);
            int price = int.Parse(textBox5.Text);
            //orderDetails newOrderDetail = new OrderDetail(, unitPrice);
            OrderDetails newOrderDetail = new OrderDetails(productName, number, price);

            // 将新的 OrderDetail 对象添加到 Order 的 OrderDetails 列表中
            newOrder.OrderDetailsList.Add(newOrderDetail);

            // 将新的订单添加到 OrderService
            newOrderService.addOrder(newOrder);


            this.DialogResult = DialogResult.OK;

            // 关闭窗口
            this.Close();
        }
    }
}
