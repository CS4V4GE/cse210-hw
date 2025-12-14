using System;
using System.Collections.Generic;

namespace HabitTrackerApp
{
    public class HabitLog
    {
        private List<DateTime> _entries = new List<DateTime>();

        public void AddEntry()
        {
            _entries.Add(DateTime.Now);
        }

        public List<DateTime> GetEntries()
        {
            return _entries;
        }
    }
}
