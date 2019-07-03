using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
   
        abstract class Shape : IComparable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract float Perimeter();

        public abstract float Area();

        public int CompareTo(object o)
        {
            Shape p = o as Shape;
            if (p != null)
                return this.Perimeter().CompareTo(p.Perimeter());
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
   
    class Square : Shape
    {
        private float side;
        public float Side
        {
            get { return side; }
            set { side = value; }
        }

        public Square(float side):base("Square")
        {
            this.side = side;
        }

        public override float Perimeter()
        {
            return side * 4;
        }
        
        public override float Area()
        {
            return side * side;
        }
    }

    class Circle : Shape
    {
        private float radius;
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(float radius) : base("Circle")
        {
             this.radius = radius;
        }

        public override float Perimeter()
        {
            return (float)(2 * 3.14 * radius);
        }

        public override float Area()
        {
            return (float)(3.14 * radius * radius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();
            int i = 0;

            while (i < 3)
            {
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                if (name == "Circle")
                {
                    Console.WriteLine("Enter radius: ");
                    int rad = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Circle(rad));
                    i++;

                }
                else if (name == "Square")
                {
                    Console.WriteLine("Enter side: ");
                    int side = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Square(side));
                    i++;

                }
                else
                {
                    Console.WriteLine("You entered not valid shape");
                    return;
                }
            }

            foreach (var k in list)
            {
                Console.WriteLine("Name: " + k.Name + ", Area: " + k.Area() + ", Perimeter: " + k.Perimeter());
            }

            Console.WriteLine($"\nMax perimeter: {list.Max().Perimeter()} in shape {list.Max().Name}\n");

            Console.WriteLine("Sorted list:");
            list.Sort();
            
          

            foreach (var k in list)
            {
                Console.WriteLine("Name: " + k.Name + ", Area: " + k.Area() + ", Perimeter: " + k.Perimeter());
            }
        }
    }
}
