namespace FigureSquare
{
    /// <summary>
    /// Класс для треугольника
    /// </summary>
    public class Triangle : Figure
    {
        private double a_side;
        private double b_side;
        private double c_side;
        public double A_Side
        {
            get
            {
                return a_side;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FigureOnCreateException("Сторона треугольника не может быть меньше/равна 0!");
                }

                //Если длина каждой стороны меньше суммы двух других сторон - стороны введены корректно
                if ((value + B_Side > C_Side) && (value + C_Side > B_Side) && (B_Side + C_Side > value))
                {
                    a_side = value;
                }
                else
                {
                    throw new FigureOnCreateException("Треугольник с указанными параметрами не может существовать! Длина каждой стороны должна быть меньше сумм длин двух других сторон!");
                }
            }
        }
        public double B_Side
        {
            get
            {
                return b_side;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FigureOnCreateException("Сторона треугольника не может быть меньше/равна 0!");
                }

                //Если длина каждой стороны меньше суммы двух других сторон - стороны введены корректно
                if ((A_Side + value > C_Side) && (A_Side + C_Side > value) && (value + C_Side > A_Side))
                {
                    b_side = value;
                }
                else
                {
                    throw new FigureOnCreateException("Треугольник с указанными параметрами не может существовать! Длина каждой стороны должна быть меньше сумм длин двух других сторон!");
                }
            }
        }
        public double C_Side
        {
            get
            {
                return c_side;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FigureOnCreateException("Сторона треугольника не может быть меньше/равна 0!");
                }

                //Если длина каждой стороны меньше суммы двух других сторон - стороны введены корректно
                if ((A_Side + B_Side > value) && (A_Side + value > B_Side) && (B_Side + value > A_Side))
                {
                    c_side = value;
                }
                else
                {
                    throw new FigureOnCreateException("Треугольник с указанными параметрами не может существовать! Длина каждой стороны должна быть меньше сумм длин двух других сторон!");
                }
            }
        }


        public Triangle(double A_Side, double B_Side, double C_Side)
        {
            if ((A_Side <= 0) || (B_Side <= 0) || (C_Side <= 0))
            {
                throw new FigureOnCreateException("Стороны треугольника не могут быть меньше/равны 0!");
            }

            //Если длина каждой стороны меньше суммы двух других сторон - стороны введены корректно
            if ((A_Side + B_Side > C_Side) && (A_Side + C_Side > B_Side) && (B_Side + C_Side > A_Side))
            {
                this.a_side = A_Side;
                this.b_side = B_Side;
                this.c_side = C_Side;
            }
            else
            {
                throw new FigureOnCreateException("Треугольник с указанными параметрами не может существовать! Длина каждой стороны должна быть меньше сумм длин двух других сторон!");
            }
        }


        /// <summary>
        /// Метод для вычисления площади треугольника по трем сторонам.
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
        {
            double HalfPerimeter = (A_Side + B_Side + C_Side) / 2;
            double Square = Math.Sqrt(HalfPerimeter * (HalfPerimeter - A_Side) * (HalfPerimeter - B_Side) * (HalfPerimeter - C_Side));
            return Math.Round(Square, 3);
        }

        /// <summary>
        /// Метод, сравнивающий стороны треугольника. Возвращает стороны треугольника в порядке возрастания длины. 
        /// </summary>
        /// <param name="shortSize1"></param>
        /// <param name="shortSize2"></param>
        /// <param name="longSide"></param>
        public void TriangleSidesCompare(out double shortSize1, out double shortSize2, out double longSide)
        {
            if (A_Side > B_Side)
            {
                shortSize1 = B_Side;
                (shortSize2, longSide) = (C_Side, A_Side);

                if (C_Side > A_Side)
                {
                    (shortSize2, longSide) = (A_Side, C_Side);
                }
            }
            else
            {
                shortSize1 = A_Side;
                (shortSize2, longSide) = (C_Side, B_Side);
                if (C_Side > B_Side)
                {
                    (shortSize2, longSide) = (B_Side, C_Side);
                }
            }
            if (shortSize1 > shortSize2) (shortSize1, shortSize2) = (shortSize2, shortSize1);
        }

        /// <summary>
        /// Метод для проверки треугольника на прямоугольность.
        /// </summary>
        /// <returns></returns>
        public bool IsTriangleRight()
        {
            double shortSize1;
            double shortSize2;
            double longSide;

            TriangleSidesCompare(out shortSize1, out shortSize2, out longSide);

            return (Math.Pow(longSide, 2) == Math.Pow(shortSize1, 2) + Math.Pow(shortSize2, 2));
        }
    }
}