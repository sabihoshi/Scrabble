using System;
using System.Collections.Generic;
using System.Linq;
using Scrabble.Extensions;

namespace Scrabble.Models.Letter
{
    public static class LetterBag
    {
        static LetterBag()
        {
            AddLetters('A', 9, 1);
            AddLetters('B', 2, 3);
            AddLetters('C', 2, 3);
            AddLetters('D', 4, 2);
            AddLetters('E', 12, 1);
            AddLetters('F', 2, 4);
            AddLetters('G', 3, 2);
            AddLetters('H', 2, 4);
            AddLetters('I', 9, 1);
            AddLetters('J', 1, 8);
            AddLetters('K', 5, 5);
            AddLetters('L', 4, 1);
            AddLetters('M', 2, 3);
            AddLetters('N', 6, 1);
            AddLetters('O', 8, 1);
            AddLetters('P', 2, 3);
            AddLetters('Q', 1, 10);
            AddLetters('R', 6, 1);
            AddLetters('S', 4, 1);
            AddLetters('T', 6, 1);
            AddLetters('U', 4, 1);
            AddLetters('V', 2, 4);
            AddLetters('W', 2, 4);
            AddLetters('X', 1, 8);
            AddLetters('Y', 2, 4);
            AddLetters('Z', 1, 10);

            // Shuffle the collection
            AvailableLetters = AvailableLetters.OrderBy(x => new Random().Next()).ToList();

            void AddLetters(char letter, int amount, int points)
            {
                for (var i = 0; i < amount; i++)
                    AvailableLetters.Add(new Letter(letter, points));
            }
        }

        public static List<Letter> AvailableLetters { get; set; } = new List<Letter>();

        public static Letter GetLetter() => AvailableLetters.Pop();
    }
}