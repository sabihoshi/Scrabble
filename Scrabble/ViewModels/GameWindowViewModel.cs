using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Scrabble.Events;
using Scrabble.Models.Player;
using Scrabble.Models.Tile;
using Stylet;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel
        : INotifyPropertyChanged, IHandle<TilePressedEvent<BoardTile>>, IHandle<TilePressedEvent<RackTile>>
    {
        private readonly IContainer _ioc;
        private RackTile? _selectedRackTile;
        private BoardTile? _selectedBoardTile;

        public GameWindowViewModel(IEventAggregator eventAggregator, IContainer ioc)
        {
            _ioc = ioc;
            Board = _ioc.Get<BoardViewModel>();
            eventAggregator.Subscribe(this);
            Board.ResetTiles();
            Players.Add(ioc.Get<Player>());
            CurrentPlayer = PlayerOne;
        }

        private Player CurrentPlayer { get; }

        public BoardViewModel Board { get; set; }

        public RackTile? SelectedRackTile
        {
            get => _selectedRackTile;
            set => _selectedRackTile = _selectedRackTile == value ? null : value;
        }

        public BoardTile? SelectedBoardTile
        {
            get => _selectedBoardTile;
            set => _selectedBoardTile = _selectedBoardTile == value ? null : value;
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public Player PlayerOne => HasPlayerOne ? Players[0] : null;
        public Player PlayerTwo => HasPlayerTwo ? Players[1] : null;
        public Player PlayerThree => HasPlayerThree ? Players[2] : null;
        public Player PlayerFour => HasPlayerFour ? Players[3] : null;

        public bool HasPlayerOne => Players.Count >= 1;
        public bool HasPlayerTwo => Players.Count >= 2;
        public bool HasPlayerThree => Players.Count >= 3;
        public bool HasPlayerFour => Players.Count >= 4;

        public void Handle(TilePressedEvent<BoardTile> message)
        {
            SelectedBoardTile = (BoardTile?)message.TilePressed;
            if (SelectedRackTile != null)
                PlaceTile();
        }

        public void Handle(TilePressedEvent<RackTile> message)
        {
            SelectedRackTile = (RackTile?)message.TilePressed;
            if (SelectedBoardTile != null)
                PlaceTile();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ConfirmMove() { }

        public void CancelMove() { }

        public void PlaceTile()
        {
            if (SelectedRackTile is null || SelectedBoardTile is null)
                return;

            SelectedBoardTile.PlacedLetter = SelectedRackTile.PlacedLetter;
            SelectedRackTile = null;
            SelectedBoardTile = null;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}