using System.ComponentModel;

namespace Scrabble.Models
{
    public abstract class TileViewModel : INotifyPropertyChanged
    {
        public enum Type
        {
            Blue,
            DarkBlue,
            Pink,
            Red,
            Star
        }

        public TileViewModel(string tileColor) => TileColor = tileColor;

        public string TileColor { get; set; }

        public string PlacedLetter { get; set; } = "A";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}