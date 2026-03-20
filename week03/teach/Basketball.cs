/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // Dictionary (Map)
        // key   = playerId(string)
        // Value = total points scored (int)
        var players = new Dictionary<string, int>();

        // Open the CSV file
        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");

        // Skip the header row (column titles)
        reader.ReadFields();

        // Loop through each row in the file
        while (!reader.EndOfData)
        {
            // Read the current row
            var fields = reader.ReadFields()!;
            // Extract playerId (Column 0)
            var playerId = fields[0];
            // Extract point scored that year (column 8)
            var points = int.Parse(fields[8]);

            // Check id player already exists in dictionary
            if (players.ContainsKey(playerId))
                // Add points to existing total
                players[playerId] += points;
            else
                // Add new player with initial points
                players[playerId] = points;
           
        }

        Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // Convert dictionary to a list of key-value pairs
        var sortedPlayers = players.ToList();

        // Sort players by total points in descending order
        sortedPlayers.Sort((a, b) => b.Value.CompareTo(a.Value));

        // Create array to store top 10 players
        var topPlayers = new string[10];

        Console.WriteLine("\nTop 10 Players by Total Points:\n");

        // Loop through top 10 players
        for (int i = 0; i < 10 && i < sortedPlayers.Count; i++)
        {
            var player = sortedPlayers[i];

            // Store formatted result
            topPlayers[i] = $"{player.Key} - {player.Value}";

            // Print to console
            Console.WriteLine($"{i + 1}. PlayerID: {player.Key}, Total Points: {player.Value}");
        }
    }
}
