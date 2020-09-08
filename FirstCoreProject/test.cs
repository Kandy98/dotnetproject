using System;
using Xunit;
using FirstLib;

namespace FirstCoreProject {
    public class test{

        [Fact]
        public void testName() {
            var ob = new Addition();
            Assert.Equal("ok", ob.display());
        }
    }
}