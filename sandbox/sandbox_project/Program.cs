using sandbox.sandbox_project.seedGame;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        // Create and fill the array
        var numbers = new int[3];
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        // Display the numbers
        Display(numbers);

        var nameList = new List<string> { "Alice", "Bobby", "Charlie" };

        // Call method
        bool found = FindBob(nameList);
        Console.WriteLine(found);

        var game = new SeedBasketGame();
        game.Run();
    }

    static void Display(int[] numbers)
    {
        Console.WriteLine("Numbers in the array:");
        foreach(var number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    static bool FindBob(List<string> nameList)
    {
        foreach (var name in nameList)
        {
            if (name == "Bob")
            {
                return true;
            }
        }
        return false;
    }
}

