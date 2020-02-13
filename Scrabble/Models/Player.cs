using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Scrabble.ViewModels;

namespace Scrabble.Models
{
    public class Player : INotifyPropertyChanged
    {
        public Player()
        {
            Color = Color.Aqua;
            Rack = new RackViewModel();
            Rack.Orientation = Orientation.Horizontal;
            Rack.Tiles.AddRange(new []
            {
                new RackTile(), 
                new RackTile(), 
                new RackTile(), 
                new RackTile(), 
                new RackTile(), 
                new RackTile(), 
                new RackTile()
            });
        }

        public int Score { get; set; }

        public Color Color { get; set; }

        public RackViewModel Rack { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}