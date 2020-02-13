namespace Scrabble.Models
{
    public interface ITile
    {
        string TileColor { get; set; }

        Letter PlacedLetter { get; set; }
    }
}