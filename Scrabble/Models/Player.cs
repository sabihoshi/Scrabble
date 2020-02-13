using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Scrabble.ViewModels;

namespace Scrabble.Models
{
    public class Player : INotifyPropertyChanged
    {
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