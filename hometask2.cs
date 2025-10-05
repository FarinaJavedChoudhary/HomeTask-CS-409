using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.NewFolder
{
    internal class hometask2
    {
        // Exercise 1 — Echo Trim
        static void Exercise1()
        {
            // Read one line of text and display common string transformations.
            // Notes:
            // - ReadLine() can return null; always check for null/empty.
            // - Trim() removes leading/trailing whitespace but leaves inner spaces intact.
            // - ToUpperInvariant()/ToLowerInvariant() are culture-agnostic and predictable for grading.
            Console.Write("Enter text: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No text entered.");
            }
            else
            {
                string trimmed = input.Trim();
                Console.WriteLine($"Trimmed     : {trimmed}");
                Console.WriteLine($"UPPER       : {trimmed.ToUpperInvariant()}");
                Console.WriteLine($"lower       : {trimmed.ToLowerInvariant()}");
                Console.WriteLine($"Length (raw): {input.Length}");
                Console.WriteLine($"Length (trim): {trimmed.Length}");
            }
        }

        // Exercise 2 — Safe Average (3 numbers)
        static void Exercise2()
        {
            // Read exactly three numeric inputs safely and compute the average.
            // Tips:
            // - Use double for fractional math; avoid integer division when averaging.
            // - Repeat prompt on invalid input; do not crash or proceed with bad data.
            double[] values = new double[3];

            for (int i = 0; i < values.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter number #{i + 1}: ");
                    string? s = Console.ReadLine();
                    if (double.TryParse(s, out double n))
                    {
                        values[i] = n;
                        break;
                    }
                    Console.WriteLine("Invalid number. Try again.");
                }
            }

            double sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            double avg = sum / values.Length;
            Console.WriteLine($"Average = {avg:F2}");
        }

        // Exercise 3 — Mini Calculator (single‑run)
        static void Exercise3()
        {
            // Single-run calculator demonstrating menu, parsing, arithmetic, and error handling.
            // Extension for homework: wrap in a loop until the user quits.
            Console.WriteLine("1) Add  2) Sub  3) Mul  4) Div  Q) Quit");
            Console.Write("Choose: ");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice) ||
                choice.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye.");
                return;
            }

            Console.Write("A: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Bad A (not a number).");
                return;
            }

            Console.Write("B: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("Bad B (not a number).");
                return;
            }

            double result;
            switch (choice.Trim())
            {
                case "1": result = a + b; break;
                case "2": result = a - b; break;
                case "3": result = a * b; break;
                case "4":
                    if (b == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return;
                    }
                    result = a / b; break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine($"Result = {result:F2}");
        }

        // Assignment 1 — Calculator+ Loop
        static void Assignment1()
        {
            // A looped calculator. Continues to accept choices until the user quits.
            // This version keeps logic simple and readable for Week 2.
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Calculator+ ===");
                Console.WriteLine("1) Add  2) Sub  3) Mul  4) Div  Q) Quit");
                Console.Write("Choose: ");
                string? pick = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pick) ||
                    pick.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }

                Console.Write("A: ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Bad A (not a number).");
                    continue;
                }

                Console.Write("B: ");
                if (!double.TryParse(Console.ReadLine(), out double b))
                {
                    Console.WriteLine("Bad B (not a number).");
                    continue;
                }

                double result;
                switch (pick.Trim())
                {
                    case "1": result = a + b; break;
                    case "2": result = a - b; break;
                    case "3": result = a * b; break;
                    case "4":
                        if (b == 0) { Console.WriteLine("Cannot divide by zero."); continue; }
                        result = a / b; break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                Console.WriteLine($"Result = {result:F2}");
            }
        }

        // Assignment 2 — Grades Normalizer
        static void Assignment2()
        {
            // Read N (positive integer), then N marks in the 0..100 range with validation.
            int n;
            while (true)
            {
                Console.Write("How many marks (N): ");
                string? s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) break;
                Console.WriteLine("Enter a positive whole number.");
            }

            int[] marks = new int[n];
            long sum = 0;
            int min = int.MaxValue, max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Mark #{i + 1} (0..100): ");
                    string? s = Console.ReadLine();
                    if (int.TryParse(s, out int m) && m >= 0 && m <= 100)
                    {
                        marks[i] = m;
                        sum += m;
                        if (m < min) min = m;
                        if (m > max) max = m;
                        break;
                    }
                    Console.WriteLine("Invalid mark. Enter 0..100.");
                }
            }

            double avg = sum / (double)n;
            Console.WriteLine();
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg:F2}");
            Console.WriteLine("Chart (each * = 1 point above Min):");

            for (int i = 0; i < n; i++)
            {
                int stars = marks[i] - min;
                if (stars < 0) stars = 0;
                Console.Write($"M{i + 1} ({marks[i]}): ");
                for (int k = 0; k < stars; k++) Console.Write('*');
                Console.WriteLine();
            }
        }

        // Assignment 3 — String Reporter
        static void Assignment3()
        {
            // Read a full name and city, then compute initials and a simple ID.
            // ID format example: CITY_INITIALS_LEN  (e.g., LAHORE_SK_12)
            Console.Write("Full name: ");
            string? fullNameIn = Console.ReadLine();

            Console.Write("City: ");
            string? cityIn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullNameIn) || string.IsNullOrWhiteSpace(cityIn))
            {
                Console.WriteLine("Both name and city are required.");
                return;
            }

            string fullName = fullNameIn.Trim();
            string city = cityIn.Trim();

            string[] parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char firstInitial = char.ToUpperInvariant(parts[0][0]);
            char lastInitial = (parts.Length > 1)
                ? char.ToUpperInvariant(parts[parts.Length - 1][0])
                : '_';

            string initials = (lastInitial == '_')
                ? $"{firstInitial}."
                : $"{firstInitial}.{lastInitial}.";

            int nameLength = fullName.Length;

            string id = $"{city.ToUpperInvariant()}_{firstInitial}{(lastInitial == '_' ? "" : lastInitial)}_{nameLength}";

            Console.WriteLine($"Hello, {fullName} ({initials}) from {city}");
            Console.WriteLine($"Name length: {nameLength}");
            Console.WriteLine($"ID: {id}");
        }

        static void Main(string[] args)
        {
            // Uncomment the method you want to run:

            // Exercise1();
            // Exercise2();
            // Exercise3();
            // Assignment1();
            // Assignment2();
            Assignment3();
        }
    }
}