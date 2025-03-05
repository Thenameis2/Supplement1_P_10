namespace Supplement_P1_9;
class Program
{
    static List<Quarter> quarters = new List<Quarter>();

    static void Main()
    {
        Console.WriteLine("Welcome!");

        
        int consecutiveBelowThreshold = 0; // Counter to track how many consecutive values are <= 0.5

        while (true)
        {
            Console.Write("\nEnter a floating-point number between 0.0 and 1.0 (or type 'exit' to quit): ");
            ///
            string input = Console.ReadLine(); // Get user input

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }

            if (double.TryParse(input, out double value))
            {
                // If value is <= 0.5, increment the counter; otherwise, reset the counter to 0
                if (value <= 0.5)
                    consecutiveBelowThreshold++;
                else
                    consecutiveBelowThreshold = 0;

                if (consecutiveBelowThreshold >= 3)
                {
                    throw new InvalidSequenceException(); // exception for invalid sequence
                }

                try
                {
                    // a new Quarter object with the valid value
                    Quarter newQuarter = new Quarter(value);
                    quarters.Add(newQuarter); // Adding the new quarter to the list

                    Console.WriteLine("\nCurrent Quarters (Grouped by Quarter):");
                    DisplayQuarters();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // If an ArgumentOutOfRangeException is thrown (invalid quarter value), show an error and exit
                    Console.WriteLine($"\nERROR: {ex.Message} (Invalid value: {value})");
                    Console.WriteLine("Closing application...");
                    break;
                }
            }
            else
            {
                // If the input is not a valid floating-point number, inform the user
                Console.WriteLine("Invalid input! Please enter a valid floating-point number.");
            }
        }
    }

    /// <summary>
    /// This method groups the quarters by their quarter range and displays them.
    /// </summary>
    static void DisplayQuarters()
    {
        // Group quarters by their quarter range (1, 2, 3, 4)
        var groupedQuarters = quarters.GroupBy(q => q.GetQuarter());

        // Loops through each group and print the quarters in that group
        foreach (var group in groupedQuarters.OrderBy(g => g.Key))
        {
            string values = string.Join(", ", group.Select(q => q.Value.ToString("F2")));
            Console.WriteLine($"Quarter {group.Key}: {values}");
        }
    }
}