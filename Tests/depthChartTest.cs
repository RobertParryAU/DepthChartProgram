using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Tests
{
    [TestClass]
    public class DepthChartTest
    {
        [TestMethod]
        public void addPlayerToDepthChart_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var position = "QB";
            var expectedCount = 1;

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);

            Assert.AreEqual(expectedCount, depthChart.Chart[position].Count());
        }

        [TestMethod]
        public void addPlayerToDepthChartAtDepth_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";
            var expectedDepth = 0;

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            depthChart.addPlayerToDepthChart(position, BlaineGabbert, 0);

            Assert.AreEqual(expectedDepth, depthChart.Chart[position].FindIndex(x => x == BlaineGabbert));
        }

        [TestMethod]
        public void removePlayerFromDepthChart_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var position = "QB";
            var expectedCount = 0;

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            depthChart.removePlayerFromDepthChart(position, TomBrady);

            Assert.AreEqual(expectedCount, depthChart.Chart[position].Count());
        }
    }
}