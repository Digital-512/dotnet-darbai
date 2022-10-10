using System;
using System.Text;

namespace uzd3
{
    abstract class Shape
    {
        private string Color;

        public Shape(string Color)
        {
            this.Color = Color;
        }

        // Abstraktus metodas.
        public abstract double GetArea();

        public string GetColor()
        {
            return Color;
        }

        public override string ToString()
        {
            return "Nežinoma figūra, kurios spalva yra {Color}.";
        }
    }

    class Rectangle : Shape
    {
        private int Length;
        private int Width;

        public Rectangle(int Length, int Width, string Color) : base(Color)
        {
            this.Length = Length;
            this.Width = Width;
        }

        public override double GetArea()
        {
            return Width * Length;
        }

        public override string ToString()
        {
            return $"Stačiakampis, kurio ilgis {Length}, plotis {Width}, spalva {GetColor()}.";
        }
    }

    class Triangle : Shape
    {
        private int Base;
        private int Height;

        public Triangle(int Base, int Height, string Color) : base(Color)
        {
            this.Base = Base;
            this.Height = Height;
        }

        public override double GetArea()
        {
            return Base * Height / 2;
        }

        public override string ToString()
        {
            return $"Trikampis, kurio pagrindas {Base}, aukštis {Height}, spalva {GetColor()}.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Rectangle staciakampis = new Rectangle(2, 8, "raudona");
            Triangle trikampis = new Triangle(4, 5, "mėlyna");

            // Stačiakampio plotas.
            double StaciakampioPlotas = staciakampis.GetArea();
            Console.WriteLine("Stačiakampio plotas: " + StaciakampioPlotas);

            // Trikampio plotas.
            double TrikampioPlotas = trikampis.GetArea();
            Console.WriteLine("Trikampio plotas: " + TrikampioPlotas);

            // Išvedimas naudojant ToString().
            Console.WriteLine(staciakampis.ToString());
            Console.WriteLine(trikampis.ToString());
        }
    }
}
