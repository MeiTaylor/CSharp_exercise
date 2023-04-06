using HomeworkFifth;
using System.DirectoryServices;
using System.Text;

namespace HomeworkSixth
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();

        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {


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

            orderService.addOrder(order001);
            orderService.addOrder(order003);
            orderService.addOrder(order002);

            ordersBindingSource = new BindingSource { DataSource = orderService.sumOrder };
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = ordersBindingSource;
            dataGridView2.DataSource = orderDetailsBindingSource;


            //设置查询条件
            comboBox1.Items.Add("全部订单");
            comboBox1.Items.Add("订单号");
            comboBox1.Items.Add("客户姓名");
            comboBox1.Items.Add("商品名称");


        }
        private void UpdateUI()
        {
            // 假设您的OrderService有一个名为GetOrders的方法，该方法返回订单列表
            var orders = orderService.sumOrder;

            // 将DataGridView的数据源设置为新的订单列表
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orderService.sumOrder;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            // 获取所选订单
            Order selectedOrder = dataGridView1.CurrentRow.DataBoundItem as Order;

            if (selectedOrder != null)
            {
                // 设置第二个 DataGridView 的数据源为所选订单的详细信息
                dataGridView2.DataSource = selectedOrder.OrderDetailsList;
            }
            else
            {
                // 如果没有所选订单，清空第二个 DataGridView
                dataGridView2.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> searchResults = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //全部订单
                    searchResults = orderService.sumOrder;
                    break;
                case 1: //根据订单号
                    int.TryParse(textBox1.Text, out int OrderId);
                    searchResults = orderService.searchOrder(order => order.OrderId == OrderId);
                    break;
                case 2: //客户姓名
                    searchResults = orderService.searchOrder(order => order.Customer == textBox1.Text);
                    break;
                case 3: //商品名称
                    searchResults = orderService.searchOrder(order => order.OrderDetailsList.Any(detail => detail.Name == textBox1.Text));
                    break;
                default:
                    MessageBox.Show("请输入正确的查询条件");
                    break;

            }

            if (searchResults.Count == 0)
            {
                MessageBox.Show("未找到任何匹配的订单。");
                return;
            }

            StringBuilder searchResultText = new StringBuilder();
            foreach (var order in searchResults)
            {
                searchResultText.AppendLine(order.ToString());
                searchResultText.AppendLine("订单明细：");
                foreach (var detail in order.OrderDetailsList)
                {
                    searchResultText.AppendLine(detail.ToString());
                }
                searchResultText.AppendLine("---------------");
            }
            MessageBox.Show(searchResultText.ToString(), "查询结果");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 假设您已经将 OrderService 作为参数传递给了 AddOrderForm

            using (addOrder addOrderForm = new addOrder(orderService))
            {
                if (addOrderForm.ShowDialog() == DialogResult.OK)

                    UpdateUI();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Order> searchResults = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //全部订单
                    searchResults = orderService.sumOrder;
                    break;
                case 1: //根据订单号
                    int.TryParse(textBox1.Text, out int OrderId);
                    searchResults = orderService.searchOrder(order => order.OrderId == OrderId);
                    break;
                case 2: //客户姓名
                    searchResults = orderService.searchOrder(order => order.Customer == textBox1.Text);
                    break;
                case 3: //商品名称
                    searchResults = orderService.searchOrder(order => order.OrderDetailsList.Any(detail => detail.Name == textBox1.Text));
                    break;
                default:
                    MessageBox.Show("请输入正确的查询条件");
                    break;

            }

            if (searchResults.Count == 0)
            {
                MessageBox.Show("未找到任何匹配的订单。");
                return;
            }
            else if (searchResults.Count == 1)
            {
                Order order1 = searchResults[0];

                //ordedeleteOrder
                orderService.deleteOrder(order1.OrderId);
                using (addOrder addOrderForm = new addOrder(orderService))
                {
                    if (addOrderForm.ShowDialog() == DialogResult.OK)

                        UpdateUI();
                }

            }
            else
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //删除订单
            // 获取DataGridView中选中的行的索引
            int selectedIndex = dataGridView1.CurrentRow.Index;
            if (selectedIndex >= 0 && selectedIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("请先选择一个有效的订单或订单详情行。");
            }

            // 删除订单详细信息
            if (dataGridView1.CurrentRow != null && dataGridView2.CurrentRow != null)
            {
                // 获取选中行的索引
                int selectedDetailedIndex = dataGridView2.CurrentRow.Index;
                string productName = dataGridView2.Rows[selectedDetailedIndex].Cells["Name"].Value.ToString();
                int selectedOrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);
                Order selectedOrder = orderService.GetOrderById(selectedOrderId);

                if (selectedOrder != null)
                {
                    selectedOrder.removeOrderDetailByName(productName);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = selectedOrder.OrderDetailsList;
                }
                else
                {
                    MessageBox.Show("未找到相应的订单。");
                }
            }
            else
            {
                MessageBox.Show("请先选择一个有效的订单和订单详情行。");
            }
        }
        
    }
}