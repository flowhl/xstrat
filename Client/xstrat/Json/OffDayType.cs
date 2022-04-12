using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class OffDayType
    {
        public int id { get; set; }
        public string name { get; set; }

        /// <summary>
        /// type:
        /// 0 - exakt
        /// 1 - ganztägig
        /// 2 - wöchentlich
        /// 3 - jede 2. woche
        /// 4 - monatlich
        /// </summary>
        public OffDayType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
