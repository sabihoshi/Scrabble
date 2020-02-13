using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Scrabble.Events;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel
        : INotifyPropertyChanged, IHandle<TilePressedEvent<BoardTile>>, IHandle<TilePressedEvent<RackTile>>
    {
        private readonly IContainer _ioc;

        private ITile? _selectedRackTile;

        private ITile? _selectedBoardTile;

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
            SelectTile(ref _selectedBoardTile, message.TilePressed);

            if (_selectedRackTile != null)
                PlaceTile();
        }

        public void Handle(TilePressedEvent<RackTile> message)
        {
            SelectTile(ref _selectedRackTile, message.TilePressed);

            if (_selectedBoardTile != null)
                PlaceTile();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void DeselectTile(ref ITile? tile)
        {
            if (tile != null)
                tile.IsHighlighted = false;
            tile = null;
        }

        public void SelectTile(ref ITile? target, ITile selected)
        {
            if (target == selected)
            {
                DeselectTile(ref target);
                return;
            }
            target = selected;
            target.IsHighlighted = true;
        }

        public void ConfirmMove() { }

        public void CancelMove() { }

        public void PlaceTile()
        {
            if (_selectedRackTile is null || _selectedBoardTile is null)
                return;

            _selectedBoardTile.PlacedLetter = _selectedRackTile.PlacedLetter;
            ((RackTile)_selectedRackTile).Player.Rack.Tiles.Remove(_selectedRackTile);

            DeselectTile(ref _selectedBoardTile);
            DeselectTile(ref _selectedRackTile);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}