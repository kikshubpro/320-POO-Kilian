using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public sealed class Tests1
    {
        [TestClass]
        public void TestTheSumOfTenAndTenIsTwenty()
        {
            //Arrange
            int x = 10;
            int y = 10;
            int z = -15;

            //Act
            int res = MyMath.Somme(x, y);
            int res2 = MyMath.Somme(z, x);

            //Assert
            Assert.AreEqual(10, res);
            Assert.AreEqual(-5, res2);
        }
    }
}
