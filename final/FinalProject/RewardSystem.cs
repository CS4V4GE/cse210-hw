namespace HabitTrackerApp
{
    public class RewardSystem
    {
        public int Points { get; private set; }

        public void AddPoints(int amount)
        {
            Points += amount;
        }

        public string GetStatus()
        {
            return $"Points: {Points}";
        }
    }
}
