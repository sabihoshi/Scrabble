using System.Drawing;
using Scrabble.Events;
using Scrabble.Models.Letter;
using Stylet;
using StyletIoC;

namespace Scrabble.Models.Tile
{
    public class RackTile : TileBase
    {
        public RackTile(Player player, IContainer ioc) : base("#EDBD11")
        {
            Aggregator = ioc.Get<IEventAggregator>();
            Letter = LetterBag.GetLetter();
            Player = player;
        }

        public Player Player { get; set; }

        public Color ForegroundColor { get; set; }

        public override void PublishEvent() { Aggregator.Publish(new TilePressedEvent<RackTile>(this)); }
    }
}