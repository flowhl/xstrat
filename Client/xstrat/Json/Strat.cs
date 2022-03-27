using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Strat
    {
        public int strat_id { get; set; }
        public string name { get; set; }
        public int team_id { get; set; }
        public int game_id { get; set; }
        public int map_id { get; set; }
        public int position_id { get; set; }
        public int version { get; set; }
        public string content { get; set; }

        public Strat(int strat_id, string name, int team_id, int game_id, int map_id, int position_id, int version, string walls, string items)
        {
            this.strat_id = strat_id;
            this.name = name;
            this.team_id = team_id;
            this.game_id = game_id;
            this.map_id = map_id;
            this.position_id = position_id;
            this.version = version;
            this.content = walls;
        }
        public Strat()
        {
            this.strat_id = 0;
            this.name = "strat 1";
            this.team_id = 0;
            this.game_id = 0;
            this.map_id = 0;
            this.position_id = 0;
            this.version = 1;
            this.content = "";
        }
    }
}
