namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入第一个数字：");
            float a= Convert.ToSingle(Console.ReadLine());
            Console.Write("请输入第二个数字：");
            float b = Convert.ToSingle(Console.ReadLine());
            Console.Write("请输入运算符：");
            char ch = Convert.ToChar(Console.ReadLine());
            float c = 0;
            switch(ch)
            {
                case '+':
                    c = a + b;
                    break;
                case '-':
                    c = a - b;
                    break;
                case '*':
                    c = a * b;
                    break;
                case '/':
                    if (b == 0.0)
                    {
                        Console.WriteLine("被除数不能为0");
                    }
                    else
                    {
                        c = a / b;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("c的值为："+c);
        }
    }
}