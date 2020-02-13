namespace Scrabble.Models
{
    public class Letter
    {
        public Letter(char character, int points)
        {
            Character = character;
            Points = points;
        }

        public char Character { get; set; }

        public int Points { get; set; }
    }
}