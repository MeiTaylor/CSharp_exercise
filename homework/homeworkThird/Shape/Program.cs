namespace Shape
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract bool IsValid();
    }

    //rectangle 长方形
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area()
        {
            return width * height;
        }

        public override bool IsValid()
        {
            return width > 0 && height > 0;
        }
    }

    //Square正方形
    public class Square : Shape
    {
        private double side;
        //public double Side { get; set; }
        public Square(double side)
        {
            this.side = side;
        }
        public override double Area()
        {
            return side * side;
        }
        public override bool IsValid()
        {
            return side > 0;
        }
    }


    //Triangle三角形
    public class Triangle : Shape
    {
        private double sideOne;
        private double sideTwo;
        private double sideThree;
        public double SideOne { get; set; }
        public double SideTwo { get; set; }
        public double SideThree { get; set; }
        public Triangle(int sideOne, int sideTwo, int sideThree)
        {
            this.sideOne = sideOne;
            this.sideTwo = sideTwo;
            this.sideThree = sideThree;
        }

        public override double Area()
        {
            double p = (sideOne + sideTwo + sideThree) / 2;
            if(IsValid())
            {
                return Math.Sqrt(p * (p - sideOne) * (p - sideTwo) * (p - sideThree));

            }
            else { return 0; }
        }
        public override bool IsValid()
        {
            return sideOne > 0 && sideTwo > 0 && sideThree > 0 && 
                sideOne + sideTwo > sideThree && sideOne + sideThree > sideTwo && sideTwo + sideThree > sideOne;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(10, 15);
            Console.WriteLine("长方形是否有效："+rec.IsValid());
            Console.WriteLine("长方形面积为"+rec.Area());
            //Console.WriteLine(rec.Height);     通过get和set可以访问到其中的private值
            //Console.WriteLine(rec.height);     此时则就不行

            Square squ = new Square(10);
            Console.WriteLine("正方形是否有效：" + squ.IsValid());
            Console.WriteLine("正方形面积为" + squ.Area());

            Triangle tri = new Triangle(3,4,5);
            Console.WriteLine("三角形是否有效：" + tri.IsValid());
            Console.WriteLine("三角形面积为" + tri.Area());

        }
    }
}