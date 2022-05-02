using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class CalendarFilterType
    {
        public string name { get; set; }
        public int id { get; set; }

        public CalendarFilterType(int id, string name)
        {
            this.name = name;
            this.id = id;
        }
    }
}
