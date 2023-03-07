namespace ConsoleApp1
{
    internal class primeFactor
    {
        static void Main(string[] args)
        {
            //1.指定数据的所有素数因子
            int a = Convert.ToInt32(System.Console.ReadLine());

            for (int i = 1; i < a + 1; i++)
            {
                int count = 0;
                for (int j = 1; j < i + 1; j++)
                {
                    if (count > 2)
                    {
                        break;
                    }
                    if (a % i == 0 && i % j == 0)
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
    }
}