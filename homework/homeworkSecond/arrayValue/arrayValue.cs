namespace arrayValue
{
    internal class arrayValue
    {
        static void Main(string[] args)
        {
            //2.编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。
            Console.Write("请输入一个数组的各个值：");
            string str = Console.ReadLine();
            string[] strArray = str.Split(" ");
            int[] intArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                int number = Convert.ToInt32(strArray[i]);
                intArray[i] = number;
            }
            int max = intArray[0];
            int min = intArray[0];
            int sum = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (max < intArray[i])
                {
                    max = intArray[i];
                }
                if (min > intArray[i])
                {
                    min = intArray[i];
                }
                sum += intArray[i];
            }
            int ave = sum / intArray.Length;

            System.Console.WriteLine("最大值为" + max);
            System.Console.WriteLine("最小值为" + min);
            System.Console.WriteLine("平均值为" + ave);
            System.Console.WriteLine("总和为" + sum);
        }
    }
}