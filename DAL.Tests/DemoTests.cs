using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
        [TestFixture]
        public class DemoTests
        {
            [Test]
            public void SampleTest()
            {
                Assert.IsTrue(1 == 1, "1 does not equal 1");
            }
        }
    
}
