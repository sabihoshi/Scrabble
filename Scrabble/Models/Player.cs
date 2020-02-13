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
        public Player(IContainer ioc)
        {
            Color = Color.Aqua;
            Rack = ioc.Get<RackViewModel>();
            Rack.AddPlayer(this);
            Rack.Orientation = Orientation.Horizontal;
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