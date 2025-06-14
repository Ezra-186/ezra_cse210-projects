using System;

// Creative Extras:
// Daily Streak Bonus: awards extra points when you record at least one goal on consecutive days (7-day and 30-day milestones).

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}