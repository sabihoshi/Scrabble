using System.Drawing;
using Scrabble.Events;
using Stylet;
using StyletIoC;

namespace Scrabble.Models
{
    public class RackTile : TileBase
    {
        public RackTile() : base("#EDBD11") => PlacedLetter = LetterBag.GetLetter();

        public Color ForegroundColor { get; set; }

        public override void PublishEvent() { Aggregator.Publish(new TilePressedEvent<RackTile>(this)); }
    }
}