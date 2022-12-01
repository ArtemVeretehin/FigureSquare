namespace FigureSquare
{
    /// <summary>
    /// Класс для круга
    /// </summary>
    public class Circle : Figure
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0) throw new FigureOnCreateException("Радиус не может быть меньше/равен 0");
                radius = value;
            }
        }

        public Circle(double Radius)
        {
            if (Radius <= 0) throw new FigureOnCreateException("Радиус не может быть меньше/равен 0");
            this.Radius = Radius;
        }


        /// <summary>
        /// Метод для вычисления площади круга
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
        {
            double Square = Math.PI * Math.Pow(Radius, 2);
            return Math.Round(Square, 3);
        }
    }
}