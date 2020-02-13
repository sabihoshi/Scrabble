namespace Scrabble.Models {
    public interface ITile {
        string TileColor { get; set; }

        string PlacedLetter { get; set; }
    }
}