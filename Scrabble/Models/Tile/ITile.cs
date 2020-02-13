namespace Scrabble.Models.Tile
{
    public interface ITile
    {
        string TileColor { get; set; }

        Letter.Letter PlacedLetter { get; set; }

        public bool IsHighlighted { get; set; }
    }
}