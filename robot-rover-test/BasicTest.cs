using Microsoft.VisualStudio.TestTools.UnitTesting;
using robot_rover;

namespace robot_rover_test
{

    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var basic = new Basic();
            Assert.AreEqual(3, basic.Add(1, 2));
        }
    }
}