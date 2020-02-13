using Scrabble.Models.Tile;

namespace Scrabble.Events
{
    public class TilePressedEvent<T> where T : TileBase
    {
        public TilePressedEvent(TileBase tilePressed) => TilePressed = tilePressed;

        public TileBase TilePressed { get; set; }
    }
}