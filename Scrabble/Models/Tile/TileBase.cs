using System.ComponentModel;
using System.Drawing;
using Stylet;
using StyletIoC;

namespace Scrabble.Models.Tile
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

        private string _tileColor;

        public TileBase(string tileColor) => TileColor = tileColor;

        [Inject]
        public IEventAggregator Aggregator { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string TileColor
        {
            get => IsHighlighted ? Color.MediumAquamarine.Name : _tileColor;
            set => _tileColor = value;
        }

        public bool IsHighlighted { get; set; }

        public Letter.Letter Letter { get; set; }

        public abstract void PublishEvent();
    }
}