using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Position
    {
        public int id { get; set; }
        public int map_id { get; set; }
        public string name { get; set; }
        public List<Strat> strats { get; set; }

        public Position(int id, int map_id, string name, List<Strat> strats)
        {
            this.id = id;
            this.map_id = map_id;
            this.name = name;
            this.strats = strats;
        }
    }
}
