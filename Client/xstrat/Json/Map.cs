using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Map
    {
        public int id { get; set; }
        public string name { get; set; }
        public int game_id { get; set; }

        public Map(int id, string name, int game_id)
        {
            this.id = id;
            this.name = name;
            this.game_id = game_id;
        }
    }
}
