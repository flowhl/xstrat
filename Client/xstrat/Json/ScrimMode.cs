using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class ScrimMode
    {
        public int id { get; set; }
        public string name { get; set; }

        public ScrimMode(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
