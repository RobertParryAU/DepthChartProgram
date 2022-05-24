namespace DepthChartProgram.Model {
    public class Player {
        public Player(){
            Name = "";
            PlayerNumber = 0;
        }

        public Player(string name, int playerNumber){
            Name = name;
            PlayerNumber = playerNumber;
        }

        public string Name {get; set;}

        public int PlayerNumber {get; set;}
    }
}