using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquare
{
    /// <summary>
    /// Класс - исключение, для обработки назначения неправильных данных о фигурах
    /// </summary>
    public class FigureOnCreateException: Exception
    {
        public FigureOnCreateException(string Message): base(Message)
        { }
    }
}
