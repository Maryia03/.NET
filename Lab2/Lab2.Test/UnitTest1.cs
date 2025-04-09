namespace Lab2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperString()
        {
            var data = 0.05M;
            var result = MyFormatter.FormatUsdPrice(data);
            Assert.StartsWith("$0", result);
            Assert.Contains(".05", result);
        }

        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperString1()
        {
            var data = .12M;
            var result = MyFormatter.FormatUsdPrice(data);
            Assert.StartsWith("$0", result);
            Assert.Contains(".12", result);
        }

        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperString2()
        {
            var data = 0.001M;
            var result = MyFormatter.FormatUsdPrice(data);
            Assert.StartsWith("$0", result);
            Assert.Contains(".00", result);
        }

        [Fact]
        public void FormatUsdPrice_ProperFormat_ShouldReturnProperString3()
        {
            var data = 1.123M;
            var result = MyFormatter.FormatUsdPrice(data);
            Assert.StartsWith("$1", result);
            Assert.Contains(".12", result);
        }
    }
}