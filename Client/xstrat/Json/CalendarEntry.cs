using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xstrat.Calendar;

namespace xstrat.Json
{
    public class CalendarEntry : ICalendarEvent
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Label { get; set; }

        /// <summary>
        /// 0 = scrim / blue
        /// 1 = offday / red
        /// 2 = ??? / purple
        /// </summary>
        public int typ { get; set; }

    }
}
