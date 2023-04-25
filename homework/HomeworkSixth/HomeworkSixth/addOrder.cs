using HomeworkFifth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            // 添加数字到ComboBox
            for (int i = 1; i <= 9; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }

            // 删除所有的TabPage
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 从输入控件中获取订单信息并创建新的 Order 对象
                int orderId = int.Parse(textBoxOrderID.Text);
                string customerName = textBoxName.Text;
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

                // 设置对话框结果为 OK，表示订单添加成功
                this.DialogResult = DialogResult.OK;

                // 关闭窗口
                this.Close();
            }
            catch (Exception ex)
            {
                // 发生异常，显示错误消息
                MessageBox.Show($"添加订单时出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清空TabControl中的TabPages
            this.tabControl1.TabPages.Clear();

            // 获取ComboBox选中的数字
            int num = this.comboBox1.SelectedIndex + 1;

            // 创建指定数量的TabPage
            for (int i = 0; i < num; i++)
            {
                // 创建TabPage
                TabPage tabPage = new TabPage("商品明细" + (i + 1).ToString());

                // 创建商品名称Label和TextBox控件
                Label label1 = new Label();
                label1.AutoSize = true;
                label1.Text = "商品名称：";
                tabPage.Controls.Add(label1);

                System.Windows.Forms.TextBox textBox_1 = new System.Windows.Forms.TextBox();
                textBox_1.Name = "textBox_1"; // 添加这行代码
                tabPage.Controls.Add(textBox_1);

                // 创建商品单价Label和TextBox控件
                Label label2 = new Label();
                label2.AutoSize = true;
                label2.Text = "商品单价：";
                tabPage.Controls.Add(label2);

                System.Windows.Forms.TextBox textBox_2 = new System.Windows.Forms.TextBox();
                textBox_2.Name = "textBox_2"; // 添加这行代码
                tabPage.Controls.Add(textBox_2);

                // 创建商品数量Label和TextBox控件
                Label label3 = new Label();
                label3.AutoSize = true;
                label3.Text = "商品数量：";
                tabPage.Controls.Add(label3);

                System.Windows.Forms.TextBox textBox_3 = new System.Windows.Forms.TextBox();
                textBox_3.Name = "textBox_3"; // 添加这行代码
                tabPage.Controls.Add(textBox_3);

                // 计算控件位置并将它们放置在TabPage的中心
                tabPage.SizeChanged += (s, ea) =>
                {
                    int centerX = tabPage.Width / 2;
                    int centerY = tabPage.Height / 2;

                    label1.Location = new Point(centerX - label1.Width - textBox_1.Width - 20, centerY - 50);
                    textBox_1.Location = new Point(label1.Right + 10, label1.Top);
                    label2.Location = new Point(centerX - label2.Width - textBox_2.Width - 20, label1.Bottom + 20);
                    textBox_2.Location = new Point(label2.Right + 10, label2.Top);
                    label3.Location = new Point(centerX - label3.Width - textBox_3.Width - 20, label2.Bottom + 20);
                    textBox_3.Location = new Point(label3.Right + 10, label3.Top);
                };

                // 将TabPage添加到TabControl中
                this.tabControl1.TabPages.Add(tabPage);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取订单号和顾客姓名
                int orderId = int.Parse(textBoxOrderID.Text);
                string customerName = textBoxName.Text;

                // 创建订单对象
                Order newOrder = new Order(orderId, customerName);

                StringBuilder sb = new StringBuilder();

                // 遍历TabControl中的TabPages，获取每个TabPage中的商品明细信息并添加到订单对象中
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    // 获取商品名称、单价、数量的值
                    string productName = tabPage.Controls.OfType<System.Windows.Forms.TextBox>().FirstOrDefault(t => t.Name == "textBox_1")?.Text;
                    int singlePrice = int.Parse(tabPage.Controls.OfType<System.Windows.Forms.TextBox>().FirstOrDefault(t => t.Name == "textBox_2")?.Text ?? "0");
                    int amount = int.Parse(tabPage.Controls.OfType<System.Windows.Forms.TextBox>().FirstOrDefault(t => t.Name == "textBox_3")?.Text ?? "0");

                    // 创建订单明细对象并添加到订单中

                    OrderDetails newOrderDetail = new OrderDetails(productName, singlePrice, amount);

                    // 将新的 OrderDetail 对象添加到 Order 的 OrderDetails 列表中
                    newOrder.OrderDetailsList.Add(newOrderDetail);
                    Console.WriteLine("怎么什么哦都没有" + $"{singlePrice}+{amount}");
                    sb.Append($"商品名称：{productName}\n商品单价：{singlePrice}\n商品数量：{amount}\n\n");
                }

                // 弹出消息框，显示订单详细信息
                MessageBox.Show(sb.ToString(), "添加订单成功");

                // 将新的订单添加到 OrderService
                newOrderService.addOrder(newOrder);

                // 设置对话框结果为 OK，表示订单添加成功
                this.DialogResult = DialogResult.OK;

                // 关闭窗口
                this.Close();
            }
            catch (Exception ex)
            {
                // 发生异常，显示错误消息
                MessageBox.Show($"添加订单时出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
