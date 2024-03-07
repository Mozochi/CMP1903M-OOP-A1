using System;
using System.Diagnostics;

public class Die
{
    private Random random;

    public int CurrentValue { get; private set; }

    public Die()
    {
        random = new Random();
        CurrentValue = 0;
    }

    public int Roll()
    {
        CurrentValue = random.Next(1, 7); 
        return CurrentValue;
    }
}

public class Game
{
    public Die[] Dice { get; private set; }

    public Game()
    {
        Dice = new Die[3];
        for (int i = 0; i < Dice.Length; i++)
        {
            Dice[i] = new Die();
        }
    }

    public int RollDice()
    {
        int Total = 0;
        int[] Rolls = new int[Dice.Length];
        for (int i = 0; i < Dice.Length; i++)
        {
            Rolls[i] = Dice[i].Roll();
            Total += Rolls[i];
        }
        Console.WriteLine("Dice rolls: [" + string.Join(", ", Rolls) + "]");
        Console.WriteLine("Total of all the dice rolls: " + Total);
        return Total;
    }
}

public class Testing
{
    public static void RunTests()
    {
        Game Game = new Game();
        int Total = Game.RollDice();

        foreach (Die Die in Game.Dice)
        {
            Debug.Assert(Die.CurrentValue >= 1 && Die.CurrentValue <= 6, "Die roll is out of bounds.");
        }

        int ExpectedTotal = 0;
        foreach (Die Die in Game.Dice)
        {
            ExpectedTotal += Die.CurrentValue;
        }
        Debug.Assert(Total == ExpectedTotal, "Total sum is mismatch.");

        Console.WriteLine("All tests have passed successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Testing.RunTests();
        }
        catch (Exception e)
        {
            Console.WriteLine("Assertion Error: " + e.Message);
            Environment.Exit(1);
        }
    }
}
