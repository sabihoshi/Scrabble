using System.Drawing;

namespace Scrabble.Models
{
    public class Tile
    {
        public Player PlacedBy { get; set; }

        public string PlacedLetter { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(PlacedLetter);

        public Point Position { get; set; }
    }
}