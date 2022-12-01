using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureSquare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquare.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void CircleTest()
        {
            //Arrange
            double Radius = 2.55;

            //Act
            var circle = new Circle(Radius);

            //Assert
            Assert.IsTrue(circle is Circle);
            Assert.AreEqual(Radius, circle.Radius);
            Assert.ThrowsException<FigureOnCreateException>(() => new Circle(0));
            Assert.ThrowsException<FigureOnCreateException>(() => new Circle(-1));
        }


        [TestMethod()]
        public void GetSquareTest()
        {
            //Arrange
            double Radius = 4.567;
            double circle_ControlSquare = 65.526;
            Circle circle = new Circle(Radius);

            //Act
            double circle_ResultSquare = circle.GetSquare();

            //Assert
            Assert.AreEqual(circle_ResultSquare, circle_ControlSquare);
        }

        [TestMethod()]
        public void SetRadiusTest()
        {
            //Arrange
            Circle circle = new Circle(5);

            //Assert
            Assert.ThrowsException<FigureOnCreateException>(() => circle.Radius = 0);
            Assert.ThrowsException<FigureOnCreateException>(() => circle.Radius = -1);
        }
    }
}