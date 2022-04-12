﻿using System;

namespace xstrat.Calendar
{
    public interface ICalendarEvent
    {
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
        string Label { get; set; }
    }
}