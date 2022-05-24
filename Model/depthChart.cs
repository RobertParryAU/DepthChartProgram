namespace Model {
    public class DepthChart {
        public DepthChart(){
            Chart = new Dictionary<string, List<Player>>();
        }

        public Dictionary<string, List<Player>> Chart{get;}

        public void addPlayerToDepthChart(string position, Player player, int? depth = null){
            if(this.Chart.ContainsKey(position)){
                List<Player> playerList = this.Chart[position];
                
                //Remove duplicates and assume new position is correct
                if(playerList.Contains(player)){
                    playerList.Remove(player);
                }

                if(depth is not null){
                    playerList.Insert(depth.Value, player);
                }else{
                    playerList.Append(player);
                }

                this.Chart[position] = playerList;
            }else{
                this.Chart.Add(position, new List<Player>(){player});
            }
        }

        public List<Player> removePlayerFromDepthChart(string position, Player player){
            if(!this.Chart.ContainsKey(position)){
                return new List<Player>();
            }

            List<Player> playerList = this.Chart[position];

            if(!playerList.Contains(player)){
                return new List<Player>();
            }

            playerList.Remove(player);
            this.Chart[position] = playerList;

            return new List<Player>(){player};
        }

        public List<Player> getBackups(string position, Player player){
            if(!this.Chart.ContainsKey(position)){
                return new List<Player>();
            }

            List<Player> playerList = this.Chart[position];

            //If players list does not contains the player or the players list is just this player or empty
            if(!playerList.Contains(player) || playerList.Count <= 1){
                return new List<Player>();
            }

            return playerList.Skip(playerList.IndexOf(player) + 1).ToList();
        }

        public void getFullDepthChart(){
            if(!this.Chart.Any()){
                Console.WriteLine("## No output");
                return;
            }

            Console.WriteLine("## Start output");

            foreach(KeyValuePair<string, List<Player>> position in this.Chart){
                string playersInPosition = "";
                foreach(Player player in position.Value){
                    if(!string.IsNullOrEmpty(playersInPosition)){
                        playersInPosition += ", ";
                    }
                    playersInPosition += $"(#{player.PlayerNumber}, {player.Name})";
                }
                Console.WriteLine("{0} - {1}", position.Key, playersInPosition);
            } 
        }
    }
}