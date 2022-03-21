using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Floor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int map_id { get; set; }

        public Floor(int id, string name, string image, int map_id)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.map_id = map_id;
        }
    }
}
