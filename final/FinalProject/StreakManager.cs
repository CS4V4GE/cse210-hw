using System;

namespace HabitTrackerApp
{
    public class StreakManager
    {
        public int CurrentStreak { get; private set; }
        public int LongestStreak { get; private set; }
        public DateTime? LastCompletionDate { get; private set; }

        public void RegisterCompletion(DateTime date)
        {
            DateTime day = date.Date;

            if (LastCompletionDate == null)
            {
                CurrentStreak = 1;
                LongestStreak = CurrentStreak;
                LastCompletionDate = day;
                return;
            }

            DateTime lastDay = LastCompletionDate.Value.Date;

            if (day == lastDay)
            {
                return;
            }

            if (day == lastDay.AddDays(1))
            {
                CurrentStreak++;
            }
            else
            {
                CurrentStreak = 1;
            }

            if (CurrentStreak > LongestStreak)
            {
                LongestStreak = CurrentStreak;
            }

            LastCompletionDate = day;
        }

        public void Reset()
        {
            CurrentStreak = 0;
            LastCompletionDate = null;
        }
    }
}
