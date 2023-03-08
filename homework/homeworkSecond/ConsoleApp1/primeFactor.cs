namespace ConsoleApp1
{
    internal class primeFactor
    {
        static void getPrimeFactor(int n)
        {

            for (int i = 1; i < n + 1; i++)
            {
                int count = 0;
                for (int j = 1; j < i + 1; j++)
                {
                    if (count > 2)
                    {
                        break;
                    }
                    if (n % i == 0 && i % j == 0)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    System.Console.WriteLine(i);
                }
            }

        }
        static void Main(string[] args)
        {
            //1.指定数据的所有素数因子

            //try{}catch{}语句抓住异常并抛出
            //写代码先做合法性验证

            try
            {
                Console.Write("请输入一个正整数：");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("该数的所有素数因子为：");
                getPrimeFactor(n);

            }
            catch(Exception e)
            {
                Console.WriteLine($"发生异常：{e.Message}");
            }

        }
    }
}