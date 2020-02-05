using System;
using System.Text.RegularExpressions;

public class Program
{

    private static Regex Regex = new Regex(@"(?<short>\w+)-(?<full>.+)\n?",
        RegexOptions.Compiled | RegexOptions.Multiline);

    public static void Main()
    {
        var text = Prompt("Please enter the original input. Press enter twice to stop.");
        var names = Prompt("Please enter the replacement names. Format: SHORT-FULL NAME Press enter twice to stop.");
    }

    public static string Prompt(string question)
    {
        Console.WriteLine(question);
        var text = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(text))
        {
            text += Console.ReadLine();
        }
        return text;
    }
}