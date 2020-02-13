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

        public string PlacedLetter { get; set; } = " ";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}