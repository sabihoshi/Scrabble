using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Scrabble.Events;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using IContainer = StyletIoC.IContainer;

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

        public List<(BoardTile boardTile, RackTile rackTile)> PlacedTiles { get; set; } = new List<(BoardTile, RackTile)>();

        public List<Player> Players { get; set; } = new List<Player>();

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
        }

        public void ConfirmMove()
        {
            foreach (var tile in PlacedTiles)
            {

            }
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

        public void PlaceTile()
        {
            if (_selectedRackTile is null || _selectedBoardTile is null)
                return;

            var boardTile = (BoardTile)_selectedBoardTile;
            var rackTile = (RackTile)_selectedRackTile;

            // Check if there is a tile placed already
            if (boardTile.HasLetter) { SwapTile(rackTile, boardTile); }
            else { PlayerPlacedTile(boardTile, rackTile); }

            PlacedTiles.Add((boardTile, rackTile));

            DeselectTile(ref _selectedBoardTile);
            DeselectTile(ref _selectedRackTile);
        }

        private void PlayerPlacedTile(BoardTile boardTile, RackTile rackTile)
        {
            boardTile.Letter = rackTile.Letter;
            boardTile.PlacedBy = CurrentPlayer;

            rackTile.Player.Rack.Tiles.Remove(_selectedRackTile);
        }

        private void SwapTile(RackTile rackTile, BoardTile boardTile)
        {
            var temp = rackTile.Letter;
            rackTile.Letter = boardTile.Letter;
            boardTile.Letter = temp;

            var original = 
                PlacedTiles.Single(x => x.boardTile == boardTile);
            PlacedTiles.Remove(original);
        }
    }
}