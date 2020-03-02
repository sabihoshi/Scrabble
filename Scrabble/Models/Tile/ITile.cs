namespace Scrabble.Models.Tile
{
    public interface ITile
    {
        string TileColor { get; set; }

        Letter.Letter Letter { get; set; }

        public bool IsHighlighted { get; set; }

        public bool IsEnabled { get; set; }
    }
}