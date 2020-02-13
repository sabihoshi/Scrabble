using System.Drawing;
using Scrabble.Events;
using Scrabble.Models.Letter;
using Stylet;

namespace Scrabble.Models.Tile
{
    public class RackTile : TileBase
    {
        public RackTile() : base("#EDBD11") => PlacedLetter = LetterBag.GetLetter();

        public Color ForegroundColor { get; set; }

        public override void PublishEvent() { Aggregator.Publish(new TilePressedEvent<RackTile>(this)); }
    }
}