using System.ComponentModel;
using System.Drawing;
using Stylet;
using StyletIoC;

namespace Scrabble.Models.Tile
{
    public abstract class TileBase : INotifyPropertyChanged, ITile
    {
        private string _tileColor;

        public TileBase(string tileColor) => TileColor = tileColor;

        [Inject] public IEventAggregator Aggregator { get; set; }

        public string TileColor
        {
            get => IsHighlighted ? Color.MediumAquamarine.Name : _tileColor;
            set => _tileColor = value;
        }

        public bool IsEnabled { get; set; } = false;

        public bool IsHighlighted { get; set; }

        public Point Position { get; set; }

        public Letter.Letter Letter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void PublishEvent();
    }
}