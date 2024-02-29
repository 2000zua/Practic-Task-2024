using System;

class Program
{
    static bool Check(string s)
    {
        int index = 0;
        while (index < s.Length)
        {
            switch (s.Substring(index, Math.Min(9, s.Length - index)))
            {
                case "outputone":
                    index += 9;
                    break;
                case "inputone":
                    index += 8;
                    break;
                case "outputon":
                    index += 8;
                    break;
                case "inputon":
                    index += 7;
                    break;
                case "output":
                    index += 6;
                    break;
                case "input":
                    index += 5;
                    break;
                case "puton":
                    index += 5;
                    break;
                case "one":
                    index += 3;
                    break;
                case "out":
                    index += 3;
                    break;
                case "in":
                    index += 2;
                    break;
                default:
                    return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.WriteLine("The word: [INPUT].");
        Console.Write("Number of Tentative: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("=> ");
            string s = Console.ReadLine();

            if (Check(s))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
