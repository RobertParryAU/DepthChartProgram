using Model;

namespace DepthChartProgram {
    public static class Program {
        public static void Main(string[] args) {

            var depthChart = new DepthChart();

            var TomBrady = new Player("Tom Brady", 12);
            var BlaineGabbert = new Player("Blaine Gabbert", 11);
            var KyleTrask = new Player("Kyle Trask", 2);

            var MikeEvans = new Player("Mike Evans", 13);
            var JaelonDarden = new Player("Jaelon Darden", 1);
            var ScottMiller = new Player("Scott Miller", 10);


            depthChart.addPlayerToDepthChart("QB", TomBrady, 0);
            depthChart.addPlayerToDepthChart("QB", BlaineGabbert, 1);
            depthChart.addPlayerToDepthChart("QB", KyleTrask, 2);

            depthChart.addPlayerToDepthChart("LWR", MikeEvans, 0);
            depthChart.addPlayerToDepthChart("LWR", JaelonDarden, 1);
            depthChart.addPlayerToDepthChart("LWR", ScottMiller, 2);

            depthChart.getBackups("QB", TomBrady);
            depthChart.getBackups("LWR", JaelonDarden);
            depthChart.getBackups("QB", MikeEvans);
            depthChart.getBackups("QB", BlaineGabbert);
            depthChart.getBackups("QB", KyleTrask);

            depthChart.getFullDepthChart();

            depthChart.removePlayerFromDepthChart("LWR", MikeEvans);

            depthChart.getFullDepthChart();

            Console.Read();
        }
    }
}