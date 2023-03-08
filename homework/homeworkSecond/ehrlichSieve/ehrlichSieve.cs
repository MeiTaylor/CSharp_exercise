namespace ehrlichSieve
{
    internal class ehrlichSieve
    {
        static void getEhrlichSieve(int n)
        {
            int[] notSu = new int[n+1];
            for (int i = 2; i*i <= n; i++)    //i<11可以写为i*i<=100
            {
                for (int j = i; j < (n + 1) / i + 1; j++)
                {
                    notSu[i * j] = 1;
                }
            }

            for (int i = 2; i < n + 1; i++)
            {
                if (notSu[i] == 0)
                {
                    System.Console.WriteLine(i);
                }
            }

        }
        static void Main(string[] args)
        {
            //3.用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，以此类推...最后剩下的就是素数。
            int n = 100;
            getEhrlichSieve(n);
        }
    }
}