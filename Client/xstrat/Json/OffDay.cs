using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class OffDay
    {
        public int? Id { get; set; }
        public int? user_id { get; set; }
        public string creation_date { get; set; }

        /// <summary>
        /// types:
        /// 0 exactly
        /// 1 entire day
        /// 2 weekly
        /// 3 every second week
        /// 4 monthly
        /// </summary>
        public int typ { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }

        public OffDay(int id, int user_id, string creation_date, int typ, string title, string start, string end)
        {
            Id = id;
            this.user_id = user_id;
            this.creation_date = creation_date;
            this.typ = typ;
            this.title = title;
            this.start = start;
            this.end = end;
        }
    }
}
