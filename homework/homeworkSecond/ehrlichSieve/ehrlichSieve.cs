namespace ehrlichSieve
{
    internal class ehrlichSieve
    {
        static void Main(string[] args)
        {
            //3.用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，以此类推...最后剩下的就是素数。

            int[] notSu = new int[101];
            for (int i = 2; i < 11; i++)
            {
                for (int j = i; j < 101 / i + 1; j++)
                {
                    notSu[i * j] = 1;
                }
            }

            for (int i = 2; i < 101; i++)
            {
                if (notSu[i] == 0)
                {
                    System.Console.WriteLine(i);
                }
            }
        }
    }
}