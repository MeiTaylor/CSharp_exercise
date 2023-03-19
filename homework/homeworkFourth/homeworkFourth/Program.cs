namespace homeworkFourth
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T Data)
        {
            Next = null;
            this.Data = Data;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public Node<T> Head { get { return head; } }
        public GenericList() {
            tail = null;
            head = null;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach (Action<T> action)
        {
            Node<T> i = this.Head;
            while(i != null)
            {
                action(i.Data);
                i = i.Next;
            }
        }
    }

    //ForEach(Action<T> action)

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello, World!");
                //首先先创建一个链表
                GenericList<double> list = new GenericList<double>();
                list.Add(3.1);
                list.Add(2.9);
                list.Add(4.5);
                //先给最大最小值赋初值
                double max = list.Head.Data;
                double min = list.Head.Data;
                double sum = 0;
                list.ForEach(x => { if (x > max) max = x; });
                list.ForEach(x => { if (x < min) min = x; });
                list.ForEach(x => { sum += x; });
                //Console.WriteLine(max);
                Console.WriteLine($"最大值为{max}");
                Console.WriteLine($"最小值为{min}");
                Console.WriteLine($"总和为{sum}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"错误信息为{e}");
            }

        }
    }
}