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


            //������������Ӷ���
            Order order001 = new Order(001, "С��");
            Order order002 = new Order(002, "С��");
            Order order003 = new Order(003, "С��");

            //��Ӷ����ľ���ϸ��detail��Ϣ
            order001.OrderDetailsList.Add(new OrderDetails("�̲�", 3, 15));
            order001.OrderDetailsList.Add(new OrderDetails("����", 5, 13));

            order002.OrderDetailsList.Add(new OrderDetails("�ֻ�", 1, 2999));
            order002.OrderDetailsList.Add(new OrderDetails("�ֻ���", 5, 19));

            order003.OrderDetailsList.Add(new OrderDetails("����", 4, 199));
            order003.OrderDetailsList.Add(new OrderDetails("Ь��", 2, 299));

            orderService.addOrder(order001);
            orderService.addOrder(order003);
            orderService.addOrder(order002);

            ordersBindingSource = new BindingSource { DataSource = orderService.sumOrder };
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = ordersBindingSource;
            dataGridView2.DataSource = orderDetailsBindingSource;


            //���ò�ѯ����
            comboBox1.Items.Add("ȫ������");
            comboBox1.Items.Add("������");
            comboBox1.Items.Add("�ͻ�����");
            comboBox1.Items.Add("��Ʒ����");



            // ������
            dataGridView1.DataSource = ordersBindingSource;

            // ���� DataGridView1 ����
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ϊ CellBeginEdit �¼���Ӵ������
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;



        }


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // ���Ҫ�༭�����Ƿ�Ϊ��������
            if (dataGridView1.Columns[e.ColumnIndex].Name == "OrderId")
            {
                // ����Ƕ������У�ȡ���༭����ʾ��Ϣ��
                e.Cancel = true;
                MessageBox.Show("�����Ų��ܱ��޸ġ�");
            }
        }

        private void UpdateUI()
        {
            // ��������OrderService��һ����ΪGetOrders�ķ������÷������ض����б�
            var orders = orderService.sumOrder;

            // ��DataGridView������Դ����Ϊ�µĶ����б�
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orderService.sumOrder;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // ��鵱ǰ���Ƿ�Ϊnull�����Ƿ���ѡ�е���
            if (dataGridView1.CurrentRow == null || dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }

            // ��ȡ��ѡ����
            Order selectedOrder = dataGridView1.CurrentRow.DataBoundItem as Order;

            if (selectedOrder != null)
            {
                // ���õڶ��� DataGridView ������ԴΪ��ѡ��������ϸ��Ϣ
                dataGridView2.DataSource = selectedOrder.OrderDetailsList;
            }
            else
            {
                // ���û����ѡ��������յڶ��� DataGridView
                dataGridView2.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> searchResults = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //ȫ������
                    searchResults = orderService.sumOrder;
                    break;
                case 1: //���ݶ�����
                    int.TryParse(textBox1.Text, out int OrderId);
                    searchResults = orderService.searchOrder(order => order.OrderId == OrderId);
                    break;
                case 2: //�ͻ�����
                    searchResults = orderService.searchOrder(order => order.Customer == textBox1.Text);
                    break;
                case 3: //��Ʒ����
                    searchResults = orderService.searchOrder(order => order.OrderDetailsList.Any(detail => detail.Name == textBox1.Text));
                    break;
                default:
                    MessageBox.Show("��������ȷ�Ĳ�ѯ����");
                    break;

            }

            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("δ�ҵ��κ�ƥ��Ķ�����");
                return;
            }

            StringBuilder searchResultText = new StringBuilder();
            foreach (var order in searchResults)
            {
                searchResultText.AppendLine(order.ToString());
                searchResultText.AppendLine("������ϸ��");
                foreach (var detail in order.OrderDetailsList)
                {
                    searchResultText.AppendLine(detail.ToString());
                }
                searchResultText.AppendLine("---------------");
            }

            DialogResult result = MessageBox.Show(this, searchResultText.ToString(), "��ѯ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                // ���ȷ�ϰ�ť�󣬷���������
                this.Visible = true;
                if (searchResults == null || searchResults.Count == 0)
                {
                    MessageBox.Show("δ�ҵ��κ�ƥ��Ķ�����");
                    return;
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // �������Ѿ��� OrderService ��Ϊ�������ݸ��� AddOrderForm

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

                // ʹ�� orderId ��ȡ����
                Order order = orderService.GetOrderById(orderId);

                if (order != null)
                {
                    // ���¶�����Ϣ
                    order.Customer = customer;

                    // �����Ҫ���¶�����ϸ�����ڴ˴�����߼�
                }
            }

            // ���½���
            UpdateUI();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("����ѡ��һ����Ч�Ķ�����");
                return;
            }

            if (dataGridView2.CurrentRow == null || dataGridView2.SelectedCells.Count == 0)
            {
                // ɾ����������
                int selectedOrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);

                // ������Դ��ɾ����Ӧ�Ķ���
                Order selectedOrder = orderService.GetOrderById(selectedOrderId);
                if (selectedOrder != null)
                {
                    orderService.deleteOrder(selectedOrderId);

                    // ����dataGridView1�����ݰ�
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = orderService.sumOrder;
                }
                else
                {
                    MessageBox.Show("δ�ҵ���Ӧ�Ķ�����");
                }
            }
            else
            {
                // ɾ��������ϸ��Ϣ����
                int selectedDetailedIndex = dataGridView2.CurrentRow.Index;
                string productName = dataGridView2.Rows[selectedDetailedIndex].Cells["Name"].Value.ToString();
                int selectedOrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);
                Order selectedOrder = orderService.GetOrderById(selectedOrderId);

                if (selectedOrder != null)
                {
                    selectedOrder.removeOrderDetailByName(productName);

                    // ����dataGridView2�����ݰ�
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = selectedOrder.OrderDetailsList;
                }
                else
                {
                    MessageBox.Show("δ�ҵ���Ӧ�Ķ�����");
                }
            }
        }

    }
}