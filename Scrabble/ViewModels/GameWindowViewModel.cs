using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {
        public GameWindowViewModel() { Board.ResetTiles(); }

        public BoardTileViewModel PressedBoardTile { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public BoardViewModel Board { get; set; } = new BoardViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}