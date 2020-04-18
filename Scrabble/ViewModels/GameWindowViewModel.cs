using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Scrabble.Events;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using StyletIoC;
using static System.Windows.Controls.Orientation;
using static Scrabble.Models.Tile.SearchNode;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel
        : Screen,
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

            Players.Add(new Player(ioc, Color.Aqua, Horizontal));
            Players.Add(new Player(ioc, Color.DarkBlue, Horizontal));
            Players.First().Rack.Tiles.ToggleTiles(true);
            CurrentPlayer = Players.First();
        }

        private Player CurrentPlayer { get; set;  }

        public BoardViewModel Board { get; set; }

        public List<(BoardTile boardTile, RackTile rackTile)> PlacedTiles { get; set; } =
            new List<(BoardTile, RackTile)>();

        public List<Player> Players { get; } = new List<Player>();

        public void Handle(TilePressedEvent<BoardTile> message)
        {
            SelectTile(ref _selectedBoardTile, message.TilePressed);
        }

        public void Handle(TilePressedEvent<RackTile> message)
        {
            SelectTile(ref _selectedRackTile, message.TilePressed);
        }

        private static void DeselectTile(ref ITile? tile)
        {
            if (tile != null)
                tile.IsHighlighted = false;
            tile = null;
        }

        private void SelectTile(ref ITile? target, ITile selected)
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
            RemoveTilesFromPlayer();
            Board.EnableAdjacentTiles();
            CurrentPlayer.Rack.Tiles.ToggleTiles();
            CurrentPlayer = Players[(Players.IndexOf(CurrentPlayer) + 1) % Players.Count];
            CurrentPlayer.Rack.Tiles.ToggleTiles();
        }

        public void CancelMove()
        {
            foreach (var (boardTile, rackTile) in PlacedTiles)
            {
                rackTile.Letter = boardTile.Letter;
                rackTile.Player.AddTile(rackTile);
                boardTile.Reset();
            }
            Board.EnableAdjacentTiles();
            PlacedTiles.Clear();
        }

        private void RemoveTilesFromPlayer()
        {
            CurrentPlayer.Rack.FillRack(PlacedTiles.Count);
            CurrentPlayer.Rack.Tiles.ToggleTiles(true);
            PlacedTiles.Clear();
        }

        public void TilePlacement()
        {
            var boardTile = (BoardTile)_selectedBoardTile!;
            var rackTile = (RackTile)_selectedRackTile!;

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

            rackTile.Player.Rack.Tiles.Remove(_selectedRackTile!);

            if (PlacedTiles.Count == 0)
            {
                Board.Tiles.ToggleTiles(false);
                Board.ToggleTiles(Orientation.Both, boardTile.Position, true);
            }
            else if (PlacedTiles.Count == 1)
            {
                var first = PlacedTiles[0].boardTile.Position;
                var second = boardTile.Position;
                var orientation = DetermineOrientation(first, second);

                Board.Tiles.ToggleTiles(false);
                Board.ToggleTiles(orientation, first, true);
            }

            // Disable tiles that have a letter already
            Board.Tiles
                .SelectMany(t => t)
                .Where(t => t.HasLetter)
                .ToggleTiles(false);
            
            // Re-enable placed tiles
            PlacedTiles.Add((boardTile, rackTile));
            PlacedTiles.Select(t => t.boardTile)
                       .ToggleTiles(true);
        }

        private static void SwapTile(BoardTile boardTile, RackTile rackTile)
        {
            (rackTile.Letter, boardTile.Letter) = (boardTile.Letter, rackTile.Letter);
        }

        public Orientation DetermineOrientation(Point first, Point second) =>
            first.Equals(second) ? Orientation.Both :
            first.X == second.X  ? Orientation.Vertical :
            first.Y == second.Y  ? Orientation.Horizontal :
                                   Orientation.None;
    }
}
