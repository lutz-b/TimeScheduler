using System;
using System.Collections.Generic;

namespace TimeScheduler.Models
{
    public class Day
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public TimeRange TimeRange { get; set; }

    }

    public class TimeRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }


}
