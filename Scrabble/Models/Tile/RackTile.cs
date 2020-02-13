using System.Drawing;
using Scrabble.Events;
using Scrabble.Models.Letter;
using Stylet;

namespace Scrabble.Models.Tile
{
    public class RackTile : TileBase
    {
        public RackTile(Player player) : base("#EDBD11")
        {
            PlacedLetter = LetterBag.GetLetter();
            Player = player;
        }

        public Player Player { get; set; }

        public Color ForegroundColor { get; set; }

        public override void PublishEvent() { Aggregator.Publish(new TilePressedEvent<RackTile>(this)); }
    }
}