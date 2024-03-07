using System;
using System.Diagnostics;

public class Die
{
    private Random random;

    public int CurrentValue { get; private set; }

    public Die()
    {
        random = new Random(); 
        CurrentValue = 0; // Setting the initial value of the dice.
    }

    public int Roll()
    {
        CurrentValue = random.Next(1, 7); // Generating a random number between 1 and 6.
        return CurrentValue; 
    }
}

public class Game
{
    public Die[] Dice { get; private set; }

    public Game()
    {
        Dice = new Die[3]; // Creating an arry for the values of all 3 dice.
        for (int i = 0; i < Dice.Length; i++)
        {
            Dice[i] = new Die();
        }
    }

    public int RollDice()
    {
        int Total = 0; // Varaible to store the total of all three dice rolls 
        int[] Rolls = new int[Dice.Length]; // Array to store all the dice rolls invidually
        for (int i = 0; i < Dice.Length; i++) // Looping through each die in the array
        {
            Rolls[i] = Dice[i].Roll(); // Rolling the dice and storing the results
            Total += Rolls[i]; // Adding the dice roll to the total
        }
        Console.WriteLine("Dice rolls: [" + string.Join(", ", Rolls) + "]");
        Console.WriteLine("Total of all the dice rolls: " + Total);
        return Total; // Returning the total of all the dice rolls.
    }
}

public class Testing
{
    public static void RunTests()
    {
        Game Game = new Game(); // Creating the game object
        int Total = Game.RollDice(); // Rolling all the dice and storing the total

        // Testing if all the dice rolls are between 1 and 6.
        foreach (Die Die in Game.Dice) // Looping through all the dices in the current game
        {
            Debug.Assert(Die.CurrentValue >= 1 && Die.CurrentValue <= 6, "Die roll is out of bounds."); // Checking if the die roll is within the range
        }

        // Testing if the sum of the three values is as expected
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
            Testing.RunTests(); //Running the Testing class on the game
        }
        catch (Exception e) // Catching any exceptions that occur while testing
        { 
            Console.WriteLine("Assertion Error: " + e.Message); //Outputing the error code
            Environment.Exit(1); // Exiting the program 
        }
    }
}
