using Scrabble.Models.Tile;

namespace Scrabble.Events
{
    public class TilePressedEvent<T> where T : ITile
    {
        public TilePressedEvent(ITile tilePressed) => TilePressed = tilePressed;

        public ITile TilePressed { get; set; }
    }
}