using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Scrim
    {
        public int id { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public string time { get; set; }
        public string opponent_name { get; set; }
        public int team_id { get; set; }
        public int? map_1_id { get; set; }
        public int? map_2_id { get; set; }
        public int? map_3_id { get; set; }
        public int typ { get; set; }
        public int creator_id { get; set; }
        public string creation_date { get; set; }

    }
}
