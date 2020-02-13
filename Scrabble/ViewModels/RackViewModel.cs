using System.Windows.Controls;
using Scrabble.Models;
using Stylet;

namespace Scrabble.ViewModels
{
    public abstract class RackViewModel : TileBase
    {
        protected RackViewModel(string tileColor) : base(tileColor) { }

        public BindableCollection<ITile> Tiles { get; set; }

        public Player Player { get; set; }

        public Orientation Orientation { get; set; }
    }
}