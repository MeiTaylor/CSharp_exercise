namespace SimpleFactory
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
        public Triangle(double sideOne, double sideTwo, double sideThree)
        {
            this.sideOne = sideOne;
            this.sideTwo = sideTwo;
            this.sideThree = sideThree;
        }

        public override double Area()
        {
            double p = (sideOne + sideTwo + sideThree) / 2;
            if (IsValid())
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

    //Circle圆形
    public class Circle:Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * radius * radius;
            throw new NotImplementedException();
        }
        public override bool IsValid()
        {
            return radius > 0;
        }
    }






    public class ShapeFactory
    {
        public static Shape getShape(int n)
        {
            Random rand = new Random();
            switch (n)
            {
                case 1:
                    return new Rectangle(rand.NextDouble() * 10, rand.NextDouble() * 10);
                    break;
                case 2:
                    return new Square(rand.NextDouble() * 10);
                    break;
                case 3:
                    bool flage = true;
                    while (flage)
                    {
                        double a = rand.NextDouble() * 10;
                        double b = rand.NextDouble() * 10;
                        double c = rand.NextDouble() * 10;
                        Triangle tri = new Triangle(a, b, c);
                        if (tri.IsValid())
                        {
                            flage = false;
                            return tri;
                        }
                    }
                    return null;
                    break;
                case 4:
                    return new Circle(rand.NextDouble() * 10);
                    break;
                default:
                    throw new NotImplementedException();

            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int shapeNumbers = 10;

            Shape[] shapes = new Shape[shapeNumbers];
            for (int i = 0; i < shapeNumbers; i++)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(1, 5);
                Shape shape = ShapeFactory.getShape(randomIndex);
                shapes[i]= shape;
            }

            double totalAreas = 0;
            for(int i = 0;i < shapeNumbers; i++)
            {
                totalAreas += shapes[i].Area();
            }


            Console.WriteLine("总面积为："+totalAreas);
        }
    }
}