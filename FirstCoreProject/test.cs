using System;
using Xunit;
using FirstLib;

namespace FirstCoreProject {
    public class test{

        [Fact]
        public void test1() {
            var ob = new Addition();
            Assert.Equal("less than 10", ob.display(2,3));
        }

        [Fact]
        public void test2() {
            var ob = new Addition();
            Assert.Equal("greater than 10", ob.display(6,6));
        }
    }
}