using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {
        public GameWindowViewModel()
        {
            Board.ResetTiles();
            Players.Add(new Player());
        }

        public BoardTile PressedBoardTile { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public Player PlayerOne => Players[0];
        public Player PlayerTwo => Players[1];
        public Player PlayerThree => Players[2];
        public Player PlayerFour => Players[3];

        public bool HasPlayerOne => Players.Count >= 1;
        public bool HasPlayerTwo => Players.Count >= 2;
        public bool HasPlayerThree => Players.Count >= 3;
        public bool HasPlayerFour => Players.Count >= 4;

        public BoardViewModel Board { get; set; } = new BoardViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}