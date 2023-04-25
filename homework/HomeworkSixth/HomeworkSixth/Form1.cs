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



            // 绑定数据
            dataGridView1.DataSource = ordersBindingSource;

            // 设置 DataGridView1 属性
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 为 CellBeginEdit 事件添加处理程序
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;



        }


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // 检查要编辑的列是否为订单号列
            if (dataGridView1.Columns[e.ColumnIndex].Name == "OrderId")
            {
                // 如果是订单号列，取消编辑并显示消息框
                e.Cancel = true;
                MessageBox.Show("订单号不能被修改。");
            }
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
            // 检查当前行是否为null或者是否有选中的行
            if (dataGridView1.CurrentRow == null || dataGridView1.SelectedCells.Count == 0)
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

            if (searchResults == null || searchResults.Count == 0)
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

            DialogResult result = MessageBox.Show(this, searchResultText.ToString(), "查询结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                // 点击确认按钮后，返回主界面
                this.Visible = true;
                if (searchResults == null || searchResults.Count == 0)
                {
                    MessageBox.Show("未找到任何匹配的订单。");
                    return;
                }
            }
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                int orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
                string customer = row.Cells["Customer"].Value.ToString();

                // 使用 orderId 获取订单
                Order order = orderService.GetOrderById(orderId);

                if (order != null)
                {
                    // 更新订单信息
                    order.Customer = customer;

                    // 如果需要更新订单明细，请在此处添加逻辑
                }
            }

            // 更新界面
            UpdateUI();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请先选择一个有效的订单。");
                return;
            }

            if (dataGridView2.CurrentRow == null || dataGridView2.SelectedCells.Count == 0)
            {
                // 删除订单操作
                int selectedOrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);

                // 从数据源中删除相应的订单
                Order selectedOrder = orderService.GetOrderById(selectedOrderId);
                if (selectedOrder != null)
                {
                    orderService.deleteOrder(selectedOrderId);

                    // 更新dataGridView1的数据绑定
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = orderService.sumOrder;
                }
                else
                {
                    MessageBox.Show("未找到相应的订单。");
                }
            }
            else
            {
                // 删除订单详细信息操作
                int selectedDetailedIndex = dataGridView2.CurrentRow.Index;
                string productName = dataGridView2.Rows[selectedDetailedIndex].Cells["Name"].Value.ToString();
                int selectedOrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);
                Order selectedOrder = orderService.GetOrderById(selectedOrderId);

                if (selectedOrder != null)
                {
                    selectedOrder.removeOrderDetailByName(productName);

                    // 更新dataGridView2的数据绑定
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = selectedOrder.OrderDetailsList;
                }
                else
                {
                    MessageBox.Show("未找到相应的订单。");
                }
            }
        }

    }
}