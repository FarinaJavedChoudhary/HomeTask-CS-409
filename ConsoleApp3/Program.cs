// See https://aka.ms/new-console-template for more information
using System;

namespace HomeAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("=== Assignment 1: Profile Summary ===");
            Assignment1_ProfileSummary();

            Console.WriteLine("\n=== Assignment 2: Temperature Logger ===");
            Assignment2_TemperatureLogger();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Assignment 1 - Profile Summary (CLI)
        static void Assignment1_ProfileSummary()
        {
            string name, city;
            int age;

            // Step 1: Prompt and read name and city; validate not empty or whitespace
            while (true)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name.Trim(); // Use TryParse equivalent - trim whitespace
                    break;
                }
                // Step 3: If any input is invalid, print a message and stop
                Console.WriteLine("Invalid input. Name cannot be empty or whitespace.");
            }

            while (true)
            {
                Console.Write("Enter your city: ");
                city = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(city))
                {
                    city = city.Trim(); // Use TryParse equivalent - trim whitespace  
                    break;
                }
                Console.WriteLine("Invalid input. City cannot be empty or whitespace.");
            }

            // Step 2: Prompt and read age; use int.TryParse and check sensible range
            while (true)
            {
                Console.Write("Enter your age: ");
                string ageText = Console.ReadLine();

                if (int.TryParse(ageText, out age) && age >= 0 && age <= 120)
                {
                    break;
                }
                // Step 3: If any input is invalid, print a message and stop
                Console.WriteLine("Invalid input. Age must be a number between 0 and 120.");
            }

            // Step 4: Print the three labeled lines using interpolation
            Console.WriteLine();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"City: {city}");

            // Stretch Ideas: Add initials next to the name
            string initials = "";
            string[] nameParts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in nameParts)
            {
                if (part.Length > 0)
                {
                    initials += part[0].ToString().ToUpper();
                }
            }
            Console.WriteLine($"Initials: {initials}");

            // Stretch Ideas: Add a greeting sentence using string interpolation
            Console.WriteLine($"Hello {name}, welcome from {city}!");
        }

        // Assignment 2 - Temperature Logger
        static void Assignment2_TemperatureLogger()
        {
            int N;

            // Step 1: Read and validate N > 0
            while (true)
            {
                Console.Write("Enter number of temperature readings (N > 0): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out N) && N > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. N must be a positive integer greater than 0.");
            }

            // Step 2: Create int[] temps = new int[N]
            int[] temps = new int[N];

            // Step 3: Loop i = 0..N-1; prompt temps[i], re-prompt on invalid input  
            for (int i = 0; i < N; i++)
            {
                while (true)
                {
                    Console.Write($"Enter temperature reading {i + 1}: ");
                    string tempInput = Console.ReadLine();

                    if (int.TryParse(tempInput, out temps[i]))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid integer temperature.");
                }
            }

            // Step 4: Initialize min=max=temps[0]; sum=0; loop to update stats
            int min = temps[0];
            int max = temps[0];
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                if (temps[i] < min)
                    min = temps[i];
                if (temps[i] > max)
                    max = temps[i];
                sum += temps[i];
            }

            // Step 5: Compute avg = sum / (double)N; print results
            double avg = sum / (double)N;

            Console.WriteLine();
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Average: {avg:F2}");

            // Step 6: Build a histogram: either exact values or bucketed ranges; print '*' per count
            Console.WriteLine();
            Console.WriteLine("Simple Text Histogram:");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Reading {i + 1} ({temps[i]}°): ");

                // Print '*' characters - use absolute value to handle negative temps
                int starCount = Math.Abs(temps[i]);
                // Limit to reasonable display (max 50 stars)
                if (starCount > 50) starCount = 50;

                for (int j = 0; j < starCount; j++)
                {
                    Console.Write("*");
                }

                // Show actual value if truncated
                if (Math.Abs(temps[i]) > 50)
                {
                    Console.Write($" (truncated from {Math.Abs(temps[i])})");
                }
                Console.WriteLine();
            }

            // Stretch Ideas: Show values in both °C and °F
            Console.WriteLine();
            Console.WriteLine("Temperature Conversions:");
            Console.WriteLine("°C\t°F");
            Console.WriteLine("--------");
            for (int i = 0; i < N; i++)
            {
                int fahrenheit = (temps[i] * 9 / 5) + 32;
                Console.WriteLine($"{temps[i]}\t{fahrenheit}");
            }

            // Stretch Ideas: Let the user choose bucket width
            Console.WriteLine();
            Console.Write("Enter bucket width for histogram (or press Enter for default): ");
            string bucketInput = Console.ReadLine();
            int bucketWidth = 10; // default

            if (!string.IsNullOrWhiteSpace(bucketInput) && int.TryParse(bucketInput, out int userBucket) && userBucket > 0)
            {
                bucketWidth = userBucket;
            }

            Console.WriteLine($"\nBucketed Histogram (width: {bucketWidth}):");

            // Find range for buckets
            int range = max - min;
            int bucketCount = (range / bucketWidth) + 1;

            // Count temperatures in each bucket
            int[] buckets = new int[bucketCount];
            for (int i = 0; i < N; i++)
            {
                int bucketIndex = (temps[i] - min) / bucketWidth;
                if (bucketIndex >= bucketCount) bucketIndex = bucketCount - 1; // Handle edge case
                buckets[bucketIndex]++;
            }

            // Display bucketed histogram
            for (int i = 0; i < bucketCount; i++)
            {
                int rangeStart = min + (i * bucketWidth);
                int rangeEnd = rangeStart + bucketWidth - 1;
                Console.Write($"[{rangeStart}-{rangeEnd}]: ");

                for (int j = 0; j < buckets[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine($" ({buckets[i]})");
            }
        }
    }
}