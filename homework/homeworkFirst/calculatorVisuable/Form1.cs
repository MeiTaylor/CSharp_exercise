namespace calculatorVisuable
{
    public partial class Form1 : Form
    {
        float a;
        float b;
        float c;
        char ch;
        public Form1()
        {
            InitializeComponent();
        }

        private void numFirst_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(numFirst.Text, out float result))
            {
                a = result;
            }
            else
            {
                // 处理无效输入的情况
            }
        }

        private void numSecond_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(numSecond.Text, out float result))
            {
                b = result;
            }
            else
            {
                // 处理无效输入的情况
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = a + b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = a - b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c = a * b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b == 0.0)
            {
                Console.WriteLine("被除数不能为0");
            }
            else
            {
                c = a / b;
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Result.Clear();
            string s = c + " ";
            Result.Text = s;
        }
    }
}