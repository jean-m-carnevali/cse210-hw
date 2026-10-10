using System;
//I added levels where the player levels up every 1,000 points. The program displays a message every time the player reaches a new level.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}