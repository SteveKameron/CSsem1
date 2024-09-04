namespace TestProject1
{
    [TestClass]
    public class MessageTest
    {
        private const string Expected1 = "Hello there!";
        private const string Expected2 = "Good Morning!";

        string? Expected3;

        [TestInitialize]
        public void SetUp()
        {
            Expected3 = "Good Afternoon!";
        }

        [TestMethod]
        public void Message1()
        {
            var m1 = Messages.msg1();

            Assert.AreEqual(Expected1, m1);
        }

        [TestMethod]
        public void Message2()
        {
            var m2 = Messages.msg2();

            Assert.AreEqual(Expected2, m2);
        }
        [TestMethod]
        public void Message3()
        {
            var m2 = Messages.msg2();

            Assert.AreNotEqual(Expected3, m2);
        }
    }

    [TestClass]
    public class ArithTest
    {
        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 4)]
        [DataRow(-1, 4, 3)]
        public void Add(int x, int y, int expected)
        {
            int r = Basic.add(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DataRow(1, 2, -1)]
        [DataRow(2, 2, 0)]
        [DataRow(3, 2, 1)]
        public void Sub(int x, int y, int expected)
        {
            int r = Basic.sub(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DataRow(9, 3, 27)]
        [DataRow(3, 3, 9)]
        [DataRow(-3, -3, 9)]
        //[Ignore]
        public void Mul(int x, int y, int expected)
        {
            int r = Basic.mul(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DataRow(9, 3, 3)]
        [DataRow(3, 3, 1)]
        [DataRow(8, 2, 4)]
        public void Div(int x, int y, int expected)
        {
            int r = Basic.div(x, y);
            Assert.AreEqual(r, expected);
        }
    }

    [TestClass]
    public class ArithTest2
    {
        [DataTestMethod]
        [DynamicData(nameof(AddData), DynamicDataSourceType.Method)]
        public void Add(int x, int y, int expected)
        {
            int r = Basic.add(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(SubData), DynamicDataSourceType.Method)]
        public void Sub(int x, int y, int expected)
        {
            int r = Basic.sub(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(MulData), DynamicDataSourceType.Method)]
        public void Mul(int x, int y, int expected)
        {
            int r = Basic.mul(x, y);
            Assert.AreEqual(r, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(DivData), DynamicDataSourceType.Method)]
        public void Div(int x, int y, int expected)
        {
            int r = Basic.div(x, y);
            Assert.AreEqual(r, expected);
        }

        private static IEnumerable<object[]> AddData()
        {
            return new[]
            {
            new object[] { 1, 2, 3 },
            new object[] { 2, 2, 4 },
            new object[] { -1, 4, 3 }
        };
        }

        private static IEnumerable<object[]> SubData()
        {
            return new[]
            {
            new object[] { 1, 2, -1 },
            new object[] { 2, 2, 0 },
            new object[] { 3, 2, 1 }
        };
        }

        private static IEnumerable<object[]> MulData()
        {
            return new[]
            {
            new object[] { 9, 3, 27 },
            new object[] { 3, 3, 9 },
            new object[] { -3, -3, 9 }
        };
        }

        private static IEnumerable<object[]> DivData()
        {
            return new[]
            {
            new object[] { 9, 3, 3 },
            new object[] { 3, 3, 1 },
            new object[] { 8, 2, 4 }
        };
        }
    }
}
