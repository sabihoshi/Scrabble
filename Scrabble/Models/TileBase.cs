using System.ComponentModel;
using Scrabble.Events;
using Stylet;
using StyletIoC;

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

        [Inject]
        public IEventAggregator Aggregator { get; set;  }

        public TileBase(string tileColor) => TileColor = tileColor;

        public string TileColor { get; set; }

        public Letter PlacedLetter { get; set; } = new Letter(' ', 0);

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void PublishEvent();
    }
}