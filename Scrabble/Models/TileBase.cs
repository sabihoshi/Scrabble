using System.ComponentModel;

namespace Scrabble.Models
{
    public abstract class TileBase : INotifyPropertyChanged, ITile
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

        public Letter PlacedLetter { get; set; } = new Letter(' ', 0);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}