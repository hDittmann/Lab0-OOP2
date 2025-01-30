namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable creation
            int lowerNumber, higherNumber;

            // Lower Number
            Console.Write("Enter a low number greater than zero: ");
            lowerNumber = Convert.ToInt32(Console.ReadLine());
            while (lowerNumber < 0)
            {
                Console.WriteLine($"{lowerNumber} is not greater than 0.");
                Console.Write("Enter a low number greater than zero: ");
                lowerNumber = Convert.ToInt32(Console.ReadLine());
            }
            // Loop to keep number above 0 
            

            // Greater Number
            Console.Write($"Enter a number greater than {lowerNumber}: ");
            higherNumber = Convert.ToInt32(Console.ReadLine());
            // Loop to keep number above lowerNumber
            while (higherNumber < lowerNumber)
            {
                Console.WriteLine($"{higherNumber} is not greater than {lowerNumber}.");
                Console.Write($"Enter a number greater than {lowerNumber}: ");
                lowerNumber = Convert.ToInt32(Console.ReadLine());
            }

            // Array to hold every number in between the two inputted numbers
            // Enumberable.Range(start, count): Goes through numbers begining at "start", but only running "count" times
            // ToArray: Configures the results to enable them to be stored in the array
            int[] numbersBetween = Enumerable.Range(lowerNumber + 1, (higherNumber - lowerNumber - 1)).ToArray();
            // Converts above array to a string, because you cannot write ints to a file
            string numbersBetween_String = string.Join(", ", numbersBetween.Reverse());
            // Writing numbersBetween_String to a file in reverse order
            /* Checks if file already exists. This is to allow the appending of data, instead of
               completely overwriting all entries once the program starts again */
            if (File.Exists("numbers.txt"))
            {
                // Appends the data if the file exists
                using StreamWriter writer = new("numbers.txt", append: true);
                {
                    writer.WriteLine(numbersBetween_String);
                }
            }
            else
            {
                // Simply creates the file if it doesn't exist, and writes the data
                using StreamWriter writer = new("numbers.txt", append: false);
                {
                    writer.WriteLine(numbersBetween_String);
                }
            }

            // Final Output
            Console.WriteLine("==> data has been saved to numbers.txt <==\n");
            Console.WriteLine($"The difference between {lowerNumber} and {higherNumber} is: \n{(higherNumber - lowerNumber)}.\n");

            // Reading from file and adding all numbers together
            int numbersBetween_Sum = 0;
            foreach (var line in File.ReadAllLines("numbers.txt")) {
                numbersBetween_Sum += line.Split(',').Select(num => int.Parse(num.Trim())).Sum();
                
            }
            Console.WriteLine($"Sum of all numbers in between {lowerNumber} and {higherNumber}: \n{numbersBetween_Sum}");
            Console.Write("Would you like to erase the file? (Y for yes, any input for no): \n> ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                File.WriteAllText("numbers.txt", " ");
                Console.WriteLine("File erased"); 
            }
        }
    }
}

/*
Additional Tasks:
    Use methods get and validate the users input.
    Read the numbers back from the file and print out the sum of the numbers.
    Use a List instead of an array variable to store the numbers.
    Use the double data type instead of the int data type.
    Print out the prime numbers between low and high.
    Write a method that takes in a number and returns true if it is a prime number.
    You may need to use the modulus operator.
    Upload your solution to GitHub.
*/