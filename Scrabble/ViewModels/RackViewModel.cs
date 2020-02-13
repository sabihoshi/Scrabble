using System.Windows.Controls;
using Scrabble.Models;
using Stylet;

namespace Scrabble.ViewModels
{
    public class RackViewModel
    {
        public BindableCollection<ITile> Tiles { get; set; } = new BindableCollection<ITile>();

        public Player Player { get; set; }

        public Orientation Orientation { get; set; }
    }
}