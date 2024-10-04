//namespace Lab1Test
//{
//    [TestClass]
//    public class RectangleTests
//    {
//        [TestMethod]
//        public void ConstructorTest()
//        {

//            double sideA = 5.0;
//            double sideB = 10.0;

//            Rectangle rectangle = new Rectangle(sideA, sideB);

//            Assert.AreEqual(sideA, rectangle.side1, 0.0001);
//            Assert.AreEqual(sideB, rectangle.side2, 0.0001);
//        }

//        [TestMethod]
//        public void CalculateAreaTest()
//        {
//            double sideA = 5.0;
//            double sideB = 10.0;
//            Rectangle rectangle = new Rectangle(sideA, sideB);
//            double area = rectangle.Area;
//            Assert.AreEqual(50.0, area, 0.0001);
//        }

//        [TestMethod]
//        public void CalculatePerimeterTest()
//        {
//            double sideA = 5.0;
//            double sideB = 10.0;
//            Rectangle rectangle = new Rectangle(sideA, sideB);
//            double perimeter = rectangle.Perimeter;
//            Assert.AreEqual(30.0, perimeter, 0.0001);
//        }
//    }
//}