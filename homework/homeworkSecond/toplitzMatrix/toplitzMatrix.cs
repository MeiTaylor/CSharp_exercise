namespace toplitzMatrix
{

    internal class toplitzMatrix
    {
        static bool isToeplitzMatrix()
        {
            Console.Write("请输入行数");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("请输入列数");
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] array = new int[m][];
            for (int i = 0; i < m; i++)
            {
                array[i] = new int[n];
                Console.Write($"请输入第{i + 1}行的值：");
                string str = Console.ReadLine();
                string[] strArray = str.Split(" ");
                int[] intArray = new int[strArray.Length];
                for (int j = 0; j < strArray.Length; j++)
                {
                    int number = Convert.ToInt32(strArray[j]);
                    array[i][j] = number;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int temp = array[0][i];
                int t = i;
                for (int j = 1; j < Math.Min(m, n - i); j++)
                {
                    if (array[j][++t] != temp)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                int temp = array[i][0];
                int t = i;
                for (int j = 1; j < Math.Min(n, m - i); j++)
                {
                    if (array[++t][j] != temp)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
            static void Main(string[] args)
        {
            if (isToeplitzMatrix())
            {
                Console.WriteLine("是托普利兹矩阵");
            }
            else
            {
                Console.WriteLine("不是托普利兹矩阵");
            }
        }
    }
}

