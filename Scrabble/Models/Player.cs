using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Scrabble.Models.Tile;
using Scrabble.ViewModels;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.Models
{
    public class Player : INotifyPropertyChanged
    {
        public Player(IContainer ioc, Color color, Orientation orientation)
        {
            Color = color;
            Rack = new RackViewModel(this, ioc)
            {
                Orientation = orientation
            };
        }

        public int Score { get; set; }

        public Color Color { get; }

        public RackViewModel Rack { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddTile(RackTile rack) => Rack.Tiles.Add(rack);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}