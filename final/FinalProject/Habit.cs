namespace HabitTrackerApp
{
    public class Habit
    {
        public string Name { get; private set; }
        public int WeeklyTarget { get; private set; }
        public int TimesCompletedThisWeek { get; private set; }

        public Habit(string name, int weeklyTarget)
        {
            Name= name;
            WeeklyTarget =weeklyTarget;
            TimesCompletedThisWeek = 0;
        }
        public void AddCompletion()
        {
            TimesCompletedThisWeek++;
        }

        public void ResetWeek()
        {
            TimesCompletedThisWeek = 0;
        }

        public string GetProgress()
        {
            return $"{TimesCompletedThisWeek}/{WeeklyTarget} completions this week";
        }

        public override string ToString()
        {
            return $"{Name}(Target: {WeeklyTarget} per week) - {GetProgress()}";
        }
    }
}
