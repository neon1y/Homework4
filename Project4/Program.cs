using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість елементів: ");
        int N = int.Parse(Console.ReadLine());
        var rand = new Random();
        var array1 = Enumerable.Range(0, N).Select(x => rand.Next(1, 27)).Where(x => x % 2 == 0).ToArray();
        var array2 = Enumerable.Range(0, N).Select(x => rand.Next(1, 27)).Where(x => x % 2 != 0).ToArray();

        char[] ConvertToAlphabet(int[] numbers)
        {
            return numbers.Select(n => n >= 1 && n <= 26 ? (char)(n + 'a' - 1) : ' ').ToArray();
        }

        char[] array1Chars = ConvertToAlphabet(array1);
        char[] array2Chars = ConvertToAlphabet(array2);

        string UppercaseLetters(char[] arr)
        {
            return new string(arr.Select(c => "aeidhj".Contains(c) ? char.ToUpper(c) : c).ToArray());
        }

        Console.WriteLine(UppercaseLetters(array1Chars));
        Console.WriteLine(UppercaseLetters(array2Chars));

    }
}
