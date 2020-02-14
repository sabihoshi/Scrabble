using System.Drawing;
using Scrabble.Events;
using Stylet;

namespace Scrabble.Models.Tile
{
    public class BoardTile : TileBase
    {
        public BoardTile(string tileColor, int letterMultiplier, int wordMultiplier) : base(tileColor)
        {
            LetterMultiplier = letterMultiplier;
            WordMultiplier = wordMultiplier;
        }

        public BoardTile(Color color, int letterMultiplier, int wordMultiplier) : this(color.Name,
            letterMultiplier, wordMultiplier) { }

        public void Reset()
        {
            PlacedBy = null;
            Letter = null;
        }

        public int LetterMultiplier { get; set; }

        public int WordMultiplier { get; set; }

        public Player PlacedBy { get; set; }

        public bool HasLetter => !string.IsNullOrWhiteSpace(Letter?.Character.ToString());

        public Point Position { get; set; }

        public override void PublishEvent() { Aggregator.Publish(new TilePressedEvent<BoardTile>(this)); }
    }
}