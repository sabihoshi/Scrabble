using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Scrabble.ViewModels;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.Models
{
    public class Player : INotifyPropertyChanged
    {
        public Player(IContainer ioc)
        {
            Color = Color.Aqua;
            Rack = new RackViewModel();
            Rack.Orientation = Orientation.Horizontal;
            Rack.Tiles.AddRange(new []
            {
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>(), 
                ioc.Get<RackTile>()
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