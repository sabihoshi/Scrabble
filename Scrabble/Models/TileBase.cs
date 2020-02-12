using System.ComponentModel;

namespace Scrabble.Models
{
    public abstract class TileBase : INotifyPropertyChanged
    {
        public enum Type
        {
            Blue,
            DarkBlue,
            Pink,
            Red,
            Star
        }

        public TileBase(string tileColor) => TileColor = tileColor;

        public string TileColor { get; set; }

        public string PlacedLetter { get; set; } = "A";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}