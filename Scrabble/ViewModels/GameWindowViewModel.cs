using System;
using System.Collections.Generic;
using System.Linq;
using Scrabble.Events;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using StyletIoC;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel : Screen, 
        IHandle<TilePressedEvent<BoardTile>>,
        IHandle<TilePressedEvent<RackTile>>
    {
        private ITile? _selectedBoardTile;

        private ITile? _selectedRackTile;

        public GameWindowViewModel(IEventAggregator eventAggregator, IContainer ioc)
        {
            Board = ioc.Get<BoardViewModel>();
            eventAggregator.Subscribe(this);
            Board.ResetTiles();

            Players.Add(ioc.Get<Player>());
            Players.First().Rack.ToggleRack(true);
            CurrentPlayer = Players.First();
        }

        private Player CurrentPlayer { get; }

        public BoardViewModel Board { get; set; }

        public List<(BoardTile boardTile, RackTile rackTile)> PlacedTiles { get; set; } =
            new List<(BoardTile, RackTile)>();

        public List<Player> Players { get; set; } = new List<Player>();

        public void Handle(TilePressedEvent<BoardTile> message)
        {
            SelectTile(ref _selectedBoardTile, message.TilePressed);
        }

        public void Handle(TilePressedEvent<RackTile> message)
        {
            SelectTile(ref _selectedRackTile, message.TilePressed);
        }

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

            if (target != null)
                target.IsHighlighted = false;

            target = selected;
            target.IsHighlighted = true;

            if (_selectedRackTile != null && _selectedBoardTile != null)
                TilePlacement();
        }

        public void ConfirmMove()
        {
            foreach (var tile in PlacedTiles) { }
        }

        public void CancelMove()
        {
            foreach (var tile in PlacedTiles)
            {
                tile.rackTile.Letter = tile.boardTile.Letter;
                tile.rackTile.Player.Rack.Tiles.Add(tile.rackTile);
                tile.boardTile.Reset();
            }
            PlacedTiles.Clear();
        }

        public void TilePlacement()
        {
            var boardTile = (BoardTile)_selectedBoardTile;
            var rackTile = (RackTile)_selectedRackTile;

            // Check if there is a tile placed already
            if (boardTile.HasLetter)
                SwapTile(boardTile, rackTile);
            else
                PlayerTilePlacement(boardTile, rackTile);

            DeselectTile(ref _selectedBoardTile);
            DeselectTile(ref _selectedRackTile);
        }

        private void PlayerTilePlacement(BoardTile boardTile, RackTile rackTile)
        {
            boardTile.Letter = rackTile.Letter;
            boardTile.PlacedBy = CurrentPlayer;

            rackTile.Player.Rack.Tiles.Remove(_selectedRackTile);
        }

        private void SwapTile(BoardTile boardTile, RackTile rackTile)
        {
            (rackTile.Letter, boardTile.Letter) = (boardTile.Letter, rackTile.Letter);
        }

        public Orientation DetermineOrientation(Point first, Point second) =>
            first.Equals(second) ? Orientation.Both :
            first.X == second.X  ? Orientation.Horizontal :
            first.Y == second.Y  ? Orientation.Vertical :
    }
}