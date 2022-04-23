using System;

namespace xstrat.Calendar
{
    public interface ICalendarEvent
    {
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
        string Label { get; set; }

        /// <summary>
        /// 0 = scrim / blue
        /// 1 = offday / red
        /// 2 = ??? / purple
        /// </summary>
        int typ { get; set; }

    }
}
