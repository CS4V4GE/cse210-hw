using System;

namespace HabitTrackerApp
{
    public class Habit
    {
        public string Name { get; private set; }
        public int WeeklyTarget { get; private set; }
        public int TimesCompletedThisWeek { get; private set; }

        private StreakManager _streakManager;

        public Habit(string name, int weeklyTarget)
        {
            Name = name;
            WeeklyTarget = weeklyTarget;
            TimesCompletedThisWeek = 0;
            _streakManager = new StreakManager();
        }

        public void AddCompletion()
        {
            TimesCompletedThisWeek++;
            _streakManager.RegisterCompletion(DateTime.Now);
        }

        public string GetProgress()
        {
            return $"{TimesCompletedThisWeek}/{WeeklyTarget}";
        }

        public override string ToString()
        {
            return $"{Name} | Weekly: {GetProgress()} | Streak: {_streakManager.CurrentStreak} | Best: {_streakManager.LongestStreak}";
        }
    }
}
