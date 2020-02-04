using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class TileViewModel : INotifyPropertyChanged
    {
        public Player PlacedBy { get; set; }

        public string PlacedLetter { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(PlacedLetter);

        public Point Position { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}