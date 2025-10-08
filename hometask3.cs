using System;

// Week 3 Home Assignments - Combined Version
// All three assignments in one file with main menu

while (true)
{
    Console.WriteLine("\n========================================");
    Console.WriteLine("    Week 3 Home Assignments Menu");
    Console.WriteLine("========================================");
    Console.WriteLine("1) Assignment 1: Menu Dispatcher");
    Console.WriteLine("2) Assignment 2: Ticket Price Calculator");
    Console.WriteLine("3) Assignment 3: String Classifier");
    Console.WriteLine("Q) Quit");
    Console.WriteLine("========================================");
    Console.Write("Choose assignment to run: ");

    string? mainChoice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(mainChoice) ||
        mainChoice.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("\nGoodbye! Thank you for using the assignment program.");
        break;
    }

    switch (mainChoice.Trim())
    {
        case "1":
            RunAssignment1();
            break;
        case "2":
            RunAssignment2();
            break;
        case "3":
            RunAssignment3();
            break;
        default:
            Console.WriteLine("\nInvalid choice. Please select 1-3 or Q.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// ============================================
// Assignment 1: Menu Dispatcher
// ============================================
static void RunAssignment1()
{
    Console.WriteLine("\n===== Menu Dispatcher =====");
    Console.WriteLine("1) Display Welcome Message");
    Console.WriteLine("2) Calculate Square of Number");
    Console.WriteLine("3) Convert Temperature (C to F)");
    Console.WriteLine("4) Check Even/Odd");
    Console.WriteLine("5) Display Current Date & Time");
    Console.WriteLine("Q) Quit");
    Console.WriteLine("===========================");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    // Guard clause for null or quit
    if (string.IsNullOrWhiteSpace(choice) ||
        choice.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Returning to main menu...");
        return;
    }

    // Switch statement to dispatch actions
    switch (choice.Trim())
    {
        case "1":
            Console.WriteLine("\n*** Welcome Message ***");
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Hello, Guest! Welcome to the Menu Dispatcher.");
            }
            else
            {
                Console.WriteLine($"Hello, {name.Trim()}! Welcome to the Menu Dispatcher.");
            }
            break;

        case "2":
            Console.WriteLine("\n*** Calculate Square ***");
            Console.Write("Enter a number: ");
            if (!double.TryParse(Console.ReadLine(), out double num))
            {
                Console.WriteLine("Invalid number.");
                break;
            }
            double square = num * num;
            Console.WriteLine($"The square of {num} is {square:F2}");
            break;

        case "3":
            Console.WriteLine("\n*** Temperature Converter (C to F) ***");
            Console.Write("Enter temperature in Celsius: ");
            if (!double.TryParse(Console.ReadLine(), out double celsius))
            {
                Console.WriteLine("Invalid temperature.");
                break;
            }
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"{celsius:F2}°C = {fahrenheit:F2}°F");
            break;

        case "4":
            Console.WriteLine("\n*** Even/Odd Checker ***");
            Console.Write("Enter an integer: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid integer.");
                break;
            }
            string result = (number % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine($"{number} is {result}");
            break;

        case "5":
            Console.WriteLine("\n*** Current Date & Time ***");
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current Date: {now:dddd, MMMM dd, yyyy}");
            Console.WriteLine($"Current Time: {now:HH:mm:ss}");
            break;

        default:
            Console.WriteLine("Invalid choice. Please select 1-5 or Q.");
            break;
    }
}

// ============================================
// Assignment 2: Ticket Price Calculator
// ============================================
static void RunAssignment2()
{
    Console.WriteLine("\n===== Ticket Price Calculator =====");
    Console.Write("Enter base ticket price: $");

    // Validate base price
    if (!double.TryParse(Console.ReadLine(), out double basePrice) || basePrice < 0)
    {
        Console.WriteLine("Invalid price. Please enter a valid positive number.");
        return;
    }

    Console.Write("Enter age: ");

    // Validate age
    if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
    {
        Console.WriteLine("Invalid age. Please enter a valid age.");
        return;
    }

    Console.Write("Are you a student? (Y/N): ");
    string? studentIn = Console.ReadLine();
    bool isStudent = !string.IsNullOrWhiteSpace(studentIn) &&
                     char.ToUpperInvariant(studentIn.Trim()[0]) == 'Y';

    // Decision table logic
    double discountRate;
    string category;

    if (age < 12)
    {
        // Child discount
        discountRate = 0.50;
        category = "Child";
    }
    else if (age >= 65)
    {
        // Senior discount
        discountRate = 0.40;
        category = "Senior";
    }
    else if (isStudent && age >= 12 && age <= 17)
    {
        // Teen student discount
        discountRate = 0.30;
        category = "Student (Teen)";
    }
    else if (isStudent && age >= 18 && age <= 64)
    {
        // Adult student discount
        discountRate = 0.20;
        category = "Student (Adult)";
    }
    else
    {
        // Regular adult - no discount
        discountRate = 0.0;
        category = "Regular Adult";
    }

    // Calculate final price
    double discountAmount = basePrice * discountRate;
    double finalPrice = basePrice - discountAmount;

    // Print breakdown
    Console.WriteLine("\n===== Ticket Price Breakdown =====");
    Console.WriteLine($"Category: {category}");
    Console.WriteLine($"Age: {age}");
    Console.WriteLine($"Student: {(isStudent ? "Yes" : "No")}");
    Console.WriteLine($"Base Price: ${basePrice:F2}");
    Console.WriteLine($"Discount Rate: {discountRate * 100:F0}%");
    Console.WriteLine($"Discount Amount: ${discountAmount:F2}");
    Console.WriteLine($"Final Price: ${finalPrice:F2}");
    Console.WriteLine("==================================");
}

// ============================================
// Assignment 3: String Classifier
// ============================================
static void RunAssignment3()
{
    Console.WriteLine("\n===== String Classifier =====");
    Console.WriteLine("Enter a line of text to classify:");
    Console.Write("> ");

    string? input = Console.ReadLine();

    // Guard clause for null input
    if (input == null)
    {
        Console.WriteLine("\nClassification: Empty");
        Console.WriteLine("Reason: No input was provided (null).");
        return;
    }

    // Classification using if/else ladder
    if (input.Length == 0)
    {
        Console.WriteLine("\nClassification: Empty");
        Console.WriteLine("Reason: The string has zero length.");
    }
    else if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("\nClassification: Whitespace");
        Console.WriteLine($"Reason: The string contains only whitespace ({input.Length} character(s)).");
    }
    else
    {
        // Trim and measure actual content length
        string trimmed = input.Trim();
        int contentLength = trimmed.Length;

        if (contentLength <= 10)
        {
            Console.WriteLine("\nClassification: Short");
            Console.WriteLine($"Reason: Content length is {contentLength} character(s) (≤ 10).");
            Console.WriteLine($"Content: \"{trimmed}\"");
        }
        else if (contentLength <= 50)
        {
            Console.WriteLine("\nClassification: Medium");
            Console.WriteLine($"Reason: Content length is {contentLength} character(s) (11-50).");
            Console.WriteLine($"Content: \"{trimmed}\"");
        }
        else
        {
            Console.WriteLine("\nClassification: Long");
            Console.WriteLine($"Reason: Content length is {contentLength} character(s) (> 50).");
            Console.WriteLine($"Preview: \"{trimmed.Substring(0, 50)}...\"");
        }

        // Additional statistics
        Console.WriteLine($"\nStatistics:");
        Console.WriteLine($"  Total Length: {input.Length}");
        Console.WriteLine($"  Trimmed Length: {contentLength}");
        Console.WriteLine($"  Leading Whitespace: {input.Length - input.TrimStart().Length}");
        Console.WriteLine($"  Trailing Whitespace: {input.Length - input.TrimEnd().Length}");
    }
}