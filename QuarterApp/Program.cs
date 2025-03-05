namespace Supplement_P1_9;
class Program
{
    static List<Quarter> quarters = new List<Quarter>();

    static void Main()
    {
        Console.WriteLine("Welcome!");

        int consecutiveBelowThreshold = 0;

        while (true)
        {
            Console.Write("\nEnter a floating-point number between 0.0 and 1.0 (or type 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }

            if (double.TryParse(input, out double value))
            {
                if (value <= 0.5)
                    consecutiveBelowThreshold++;
                else
                    consecutiveBelowThreshold = 0;

                if (consecutiveBelowThreshold >= 3)
                {
                    throw new InvalidSequenceException();
                }

                try
                {
                    Quarter newQuarter = new Quarter(value);
                    quarters.Add(newQuarter);

                    Console.WriteLine("\nCurrent Quarters (Grouped by Quarter):");
                    DisplayQuarters();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"\nERROR: {ex.Message} (Invalid value: {value})");
                    Console.WriteLine("Closing application...");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid floating-point number.");
            }
        }
    }

    static void DisplayQuarters()
    {
        var groupedQuarters = quarters.GroupBy(q => q.GetQuarter());

        foreach (var group in groupedQuarters.OrderBy(g => g.Key))
        {
            string values = string.Join(", ", group.Select(q => q.Value.ToString("F2")));
            Console.WriteLine($"Quarter {group.Key}: {values}");
        }
    }
}