using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTriangle
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(1, 2, 3));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(true, Triangle.TriangleManager.IsExist(1, 1, 1));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(-4, 2, 3));
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(2, 0, 2));
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(3, 1, float.MaxValue));
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(1, 1, 2));
        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(float.MinValue, 0, float.MaxValue));
        }
        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist(-4, -4, -4));
        }
        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(true, Triangle.TriangleManager.IsExist(4.1f, 2.3f, 1.9f));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(false, Triangle.TriangleManager.IsExist((int)4.5, 1, 1));
        }
    }
}
