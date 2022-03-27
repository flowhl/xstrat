using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class XMap
    {
        public string Name { get; set; }
        public int game_id { get; set; }
        public List<Floor> floors { get; set; } = new List<Floor>();
        public List<Position> positions { get; set; } = new List<Position>();

        public XMap(string name, int game_id, List<Floor> floors, List<Position> positions)
        {
            Name = name;
            this.game_id = game_id;
            this.floors = floors;
            this.positions = positions;
        }

        public XMap()
        {
            floors.Add(new Floor(0, "basement", @"https://xstrat.app/wp-content/uploads/2022/03/DZ-consulate-basement.png", 0,0));
            floors.Add(new Floor(1, "first floor", @"https://xstrat.app/wp-content/uploads/2022/03/DZ-consulate-groundfloor.png", 0,1));
            var stratlist = new List<Strat>();
            stratlist.Add(new Strat());
            positions.Add(new Position(0, 0, "1", stratlist));
            positions.Add(new Position(1, 0, "2", stratlist));
            Name = "Bank";
            game_id = 0;
        }

    }
}
