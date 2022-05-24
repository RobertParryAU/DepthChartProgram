namespace Model {
    public class DepthChart {
        public DepthChart(){
            Chart = new Dictionary<string, List<Player>>();
        }

        public Dictionary<string, List<Player>> Chart{get;}

        public void addPlayerToDepthChart(string Position, Player player, int? depth = null){
            if(this.Chart.ContainsKey(Position)){
                List<Player> playerList = this.Chart[Position];
                
                //Remove duplicates and assume new position is correct
                if(playerList.Contains(player)){
                    playerList.Remove(player);
                }

                if(depth is not null){
                    playerList.Insert(depth.Value, player);
                }else{
                    playerList.Append(player);
                }

                this.Chart[Position] = playerList;
            }else{
                this.Chart.Add(Position, new List<Player>(){player});
            }
        }

        public void removePlayerFromDepthChart(string Position, Player player){
            if(this.Chart.ContainsKey(Position)){
                List<Player> playerList = this.Chart[Position];

                if(playerList.Contains(player)){
                    Console.WriteLine("#{0} - {1}", player.PlayerNumber, player.Name);
                    playerList.Remove(player);

                    this.Chart[Position] = playerList;
                }
            }
        }

        public void getBackups(string Position, Player player){
            if(this.Chart.ContainsKey(Position)){
                List<Player> playerList = this.Chart[Position];

                //If players list contains the player and the players list is more than just this player
                if(playerList.Contains(player) && playerList.Count > 1){
                    List<Player> backups = playerList.Skip(playerList.IndexOf(player) + 1).Take(playerList.Count).ToList();

                    foreach(Player backup in backups){
                        Console.WriteLine("#{0} - {1}", backup.PlayerNumber, backup.Name);
                    }
                }
            }
        }

        public void getFullDepthChart(){
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