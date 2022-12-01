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
    public class TriangleTests
    {
        [TestMethod()]
        public void TriangleTest()
        {
            //Arrange
            //Набор корректных длин треугольника
            double[] TriangleSides_CorrectSet = new double[] { 20, 13.2, 12.5 };
            //Набор некорректных длин треугольника
            double[] TriangleSides_UncorrectSet = new double[] { 1, 10, 30 };
            //Набор нулевых длин треугольника
            double[] TriangleSides_ZeroValuesSet = new double[] { 0, 0, 0 };
            //Набор отрицательных длин треугольника
            double[] TriangleSides_NegativeValuesSet = new double[] { -2, -2, -2 };

            //Act
            var triangle = new Triangle(TriangleSides_CorrectSet[0], TriangleSides_CorrectSet[1], TriangleSides_CorrectSet[2]);

            //Assert
            Assert.IsTrue(triangle is Triangle);
            Assert.AreEqual(TriangleSides_CorrectSet[0], triangle.A_Side);
            Assert.AreEqual(TriangleSides_CorrectSet[1], triangle.B_Side);
            Assert.AreEqual(TriangleSides_CorrectSet[2], triangle.C_Side);
            Assert.ThrowsException<FigureOnCreateException>(() => new Triangle(TriangleSides_UncorrectSet[0], TriangleSides_UncorrectSet[1], TriangleSides_UncorrectSet[2]));
            Assert.ThrowsException<FigureOnCreateException>(() => new Triangle(TriangleSides_ZeroValuesSet[0], TriangleSides_ZeroValuesSet[1], TriangleSides_ZeroValuesSet[2]));
            Assert.ThrowsException<FigureOnCreateException>(() => new Triangle(TriangleSides_NegativeValuesSet[0], TriangleSides_NegativeValuesSet[1], TriangleSides_NegativeValuesSet[2]));
        }


        [TestMethod()]
        public void GetSquareTest()
        {
            //Arrange
            double A_Side = 20;
            double B_Side = 12.5;
            double C_Side = 13.2;
            double triangle_ControlSquare = 80.649;

            Triangle triangle = new Triangle(A_Side, B_Side, C_Side);
                
            //Act
            double triangle_ResultSquare = triangle.GetSquare();

            //Assert
            Assert.AreEqual(triangle_ResultSquare, triangle_ControlSquare);
        }


        [TestMethod()]
        public void TriangleSidesCompareTest()
        {
            //Arrange

            //Набор всех комбинаций сторон треугольника
            //A - длинная сторона, B - средняя сторона, C - короткая сторона
            double[] TriangleSides_Set1 = new double[] { 20, 13.2, 12.5 }; 
            //A - длинная сторона, B - короткая сторона, C - средняя сторона
            double[] TriangleSides_Set2 = new double[] { 20, 12.5, 13.2 };
            //A - средняя сторона, B - длинная сторона, C - короткая сторона
            double[] TriangleSides_Set3 = new double[] { 13.2, 20, 12.5 };
            //А - короткая сторона, B - длинная сторона, C - средняя сторона
            double[] TriangleSides_Set4 = new double[] { 12.5, 20, 13.2 }; 
            //А - короткая сторона, B - средняя сторона, C - длинная сторона
            double[] TriangleSides_Set5 = new double[] { 12.5, 13.2, 20 };
            //А - средняя сторона, B - короткая сторона, C - длинная сторона
            double[] TriangleSides_Set6 = new double[] { 13.2, 12.5, 20 };
             
            //Набор массивов для результатов сравнения сторон треугольников
            double[] TriangleSidesCompareResult_Set1 = new double[3];
            double[] TriangleSidesCompareResult_Set2 = new double[3];
            double[] TriangleSidesCompareResult_Set3 = new double[3];
            double[] TriangleSidesCompareResult_Set4 = new double[3];
            double[] TriangleSidesCompareResult_Set5 = new double[3];
            double[] TriangleSidesCompareResult_Set6 = new double[3];

            //Контрольный результат сравнения сторон (один для всех треугольников)
            double[] TriangleSidesCompareControl_Set = new double[] {12.5, 13.2, 20};
            

            //Создание треугольников для каждого набора длин сторон
            Triangle triangle1 = new Triangle(TriangleSides_Set1[0], TriangleSides_Set1[1], TriangleSides_Set1[2]);
            Triangle triangle2 = new Triangle(TriangleSides_Set2[0], TriangleSides_Set2[1], TriangleSides_Set2[2]);        
            Triangle triangle3 = new Triangle(TriangleSides_Set3[0], TriangleSides_Set3[1], TriangleSides_Set3[2]);           
            Triangle triangle4 = new Triangle(TriangleSides_Set4[0], TriangleSides_Set4[1], TriangleSides_Set4[2]);           
            Triangle triangle5 = new Triangle(TriangleSides_Set5[0], TriangleSides_Set5[1], TriangleSides_Set5[2]);            
            Triangle triangle6 = new Triangle(TriangleSides_Set6[0], TriangleSides_Set6[1], TriangleSides_Set6[2]);
            

            //Act
            triangle1.TriangleSidesCompare(out TriangleSidesCompareResult_Set1[0], out TriangleSidesCompareResult_Set1[1], out TriangleSidesCompareResult_Set1[2]);
            triangle2.TriangleSidesCompare(out TriangleSidesCompareResult_Set2[0], out TriangleSidesCompareResult_Set2[1], out TriangleSidesCompareResult_Set2[2]);
            triangle3.TriangleSidesCompare(out TriangleSidesCompareResult_Set3[0], out TriangleSidesCompareResult_Set3[1], out TriangleSidesCompareResult_Set3[2]);
            triangle4.TriangleSidesCompare(out TriangleSidesCompareResult_Set4[0], out TriangleSidesCompareResult_Set4[1], out TriangleSidesCompareResult_Set4[2]);
            triangle5.TriangleSidesCompare(out TriangleSidesCompareResult_Set5[0], out TriangleSidesCompareResult_Set5[1], out TriangleSidesCompareResult_Set5[2]);
            triangle6.TriangleSidesCompare(out TriangleSidesCompareResult_Set6[0], out TriangleSidesCompareResult_Set6[1], out TriangleSidesCompareResult_Set6[2]);

            //Assert
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set1, TriangleSidesCompareControl_Set);
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set2, TriangleSidesCompareControl_Set);
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set3, TriangleSidesCompareControl_Set);
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set4, TriangleSidesCompareControl_Set);
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set5, TriangleSidesCompareControl_Set);
            CollectionAssert.AreEqual(TriangleSidesCompareResult_Set6, TriangleSidesCompareControl_Set);
        }

        [TestMethod()]
        public void IsTriangleRightTest()
        {
            //Arrange

            //Прямоугольный треугольник
            Triangle triangle1 = new Triangle(3, 4, 5);

            //Непрямоугольный треугольник
            Triangle triangle2 = new Triangle(3, 2, 4);
            
            //Act
            bool IsTriangle1Right = triangle1.IsTriangleRight();
            bool IsTriangle2Right = triangle2.IsTriangleRight();

            //Assert
            Assert.IsTrue(IsTriangle1Right);
            Assert.IsFalse(IsTriangle2Right);
        }
    }
}