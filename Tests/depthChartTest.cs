using Microsoft.VisualStudio.TestTools.UnitTesting;
using DepthChartProgram.Model;

namespace DepthChartProgram.Tests
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

            depthChart.addPlayerToDepthChart(position, TomBrady);

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
        public void addPlayerToDepthChartNoDepth_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";

            depthChart.addPlayerToDepthChart(position, TomBrady);
            depthChart.addPlayerToDepthChart(position, BlaineGabbert);

            Assert.AreEqual(BlaineGabbert, depthChart.Chart[position].Last());
        }

        [TestMethod]
        public void removePlayerFromDepthChart_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var position = "QB";
            var returnedPlayers = new List<Player>();

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            returnedPlayers = depthChart.removePlayerFromDepthChart(position, TomBrady);

            Assert.AreEqual(TomBrady, returnedPlayers.First());
        }

        [TestMethod]
        public void removePlayerFromDepthChartEmpty_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";
            var returnedPlayers = new List<Player>();
            var expectedCount = 0;

            depthChart.addPlayerToDepthChart(position, TomBrady);
            returnedPlayers = depthChart.removePlayerFromDepthChart(position, BlaineGabbert);

            Assert.AreEqual(expectedCount, returnedPlayers.Count());
        }

        [TestMethod]
        public void getbackups_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";
            var returnedPlayers = new List<Player>();

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            depthChart.addPlayerToDepthChart(position, BlaineGabbert, 1);
            returnedPlayers = depthChart.getBackups(position, TomBrady);

            Assert.AreEqual(BlaineGabbert, returnedPlayers.First());
        }

        [TestMethod]
        public void getbackupsNoBackups_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";
            var returnedPlayers = new List<Player>();
            var expectedCount = 0;

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            depthChart.addPlayerToDepthChart(position, BlaineGabbert, 1);
            returnedPlayers = depthChart.getBackups(position, BlaineGabbert);

            Assert.AreEqual(expectedCount, returnedPlayers.Count());
        }

        [TestMethod]
        public void getbackupsPlayerNotInList_Success()
        {
            var depthChart = new DepthChart();
            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var position = "QB";
            var returnedPlayers = new List<Player>();
            var expectedCount = 0;

            depthChart.addPlayerToDepthChart(position, TomBrady, 0);
            returnedPlayers = depthChart.getBackups(position, BlaineGabbert);

            Assert.AreEqual(expectedCount, returnedPlayers.Count());
        }
    }
}