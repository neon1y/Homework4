using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements (N): ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }

        int[] randomNumbers = new int[N];
        Random random = new Random();

        for (int i = 0; i < N; i++)
        {
            randomNumbers[i] = random.Next(1, 27);
        }

        int[] evenNumbers = Array.FindAll(randomNumbers, x => x % 2 == 0);
        int[] oddNumbers = Array.FindAll(randomNumbers, x => x % 2 != 0);

        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int i = 0; i < evenNumbers.Length; i++)
        {
            evenNumbers[i] = GetAlphabetOrdinal(evenNumbers[i], true);
        }

        for (int i = 0; i < oddNumbers.Length; i++)
        {
            oddNumbers[i] = GetAlphabetOrdinal(oddNumbers[i], false);
        }

        Console.WriteLine("Even Array: " + string.Join(" ", evenNumbers));
        Console.WriteLine("Odd Array: " + string.Join(" ", oddNumbers));

        int countUpperCaseEven = CountUpperCaseLetters(evenNumbers);
        int countUpperCaseOdd = CountUpperCaseLetters(oddNumbers);

        Console.WriteLine($"Uppercase letters count - Even Array: {countUpperCaseEven}");
        Console.WriteLine($"Uppercase letters count - Odd Array: {countUpperCaseOdd}");

        if (countUpperCaseEven > countUpperCaseOdd)
        {
            Console.WriteLine("Even Array contains more uppercase letters.");
        }
        else if (countUpperCaseEven < countUpperCaseOdd)
        {
            Console.WriteLine("Odd Array contains more uppercase letters.");
        }
        else
        {
            Console.WriteLine("Both arrays contain the same number of uppercase letters.");
        }
    }

    static int GetAlphabetOrdinal(int number, bool isUpperCase)
    {
        char letter = (char)(number + 96); 

        if (isUpperCase && "aeidhj".Contains(letter))
        {
            letter = char.ToUpper(letter);
        }

        return (int)letter;
    }

    static int CountUpperCaseLetters(int[] array)
    {
        return Array.FindAll(array, x => x >= 'A' && x <= 'Z' || x >= 'a' && x <= 'z' && char.IsUpper((char)(x + 96))).Length;
    }
}
