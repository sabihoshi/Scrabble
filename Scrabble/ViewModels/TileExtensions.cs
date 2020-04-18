using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Scrabble.Models.Tile;
using static Scrabble.Models.Tile.SearchNode;

namespace Scrabble.ViewModels
{
    internal static class TileExtensions
    {
        private static readonly Point[] AdjacentPositions =
        {
            new Point(-1, -1),
            new Point(-1, 0),
            new Point(-1, 1),
            new Point(0, -1),
            new Point(0, 1),
            new Point(1, -1),
            new Point(1, 0),
            new Point(1, 1)
        };

        public static void ToggleTiles(this IEnumerable<ITile> tiles, bool? toggle = null)
        {
            foreach (var tile in tiles)
                tile.IsEnabled = toggle ?? !tile.IsEnabled;
        }

        public static void ToggleTiles(this IEnumerable<IEnumerable<ITile>> tiles, bool? toggle = null)
        {
            tiles.SelectMany(t => t).ToggleTiles(toggle);
        }

        public static IEnumerable<BoardTile> GetAdjacentTiles(this BoardTile[][] boardTiles, Point index,
            IReadOnlyList<BoardTile[]> tiles)
        {
            foreach (var position in AdjacentPositions)
            {
                // Get the adjacent position of the current tile
                var x = index.X + position.X;
                var y = index.Y + position.Y;

                if (x < 0 || x > boardTiles[y].Length - 1)
                    continue;
                if (y < 0 || y > boardTiles.Length - 1)
                    continue;

                if (!boardTiles[y][x].HasLetter)
                    yield return tiles[y][x];
            }
        }

        public static IEnumerable<Point> GetPoints(this Orientation orientation, Point index)
        {
            return orientation switch
            {
                Orientation.Both =>
                GeneratePoints(Orientation.Horizontal, index).Concat(GeneratePoints(Orientation.Vertical, index)),
                Orientation.Horizontal => GeneratePoints(Orientation.Horizontal, index),
                Orientation.Vertical => GeneratePoints(Orientation.Vertical, index),
                _ => Enumerable.Empty<Point>()
            };
        }

        private static IEnumerable<Point> GeneratePoints(this Orientation orientation, Point index)
        {
            for (var i = 0; i < BoardViewModel.Size; i++)
            {
                yield return orientation switch
                {
                    Orientation.Horizontal => new Point(i, index.Y),
                    Orientation.Vertical => new Point(index.X, i)
                };
            }
        }
    }
}