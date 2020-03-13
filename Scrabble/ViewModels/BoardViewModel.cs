using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Scrabble.Models.Tile;
using Stylet;
using static Scrabble.Models.Tile.BoardTile;
using static Scrabble.Models.Tile.SearchNode;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public const int Size = 15;
        private readonly IContainer _ioc;
        private readonly Point[] _adjacentPositions = new[]
        {
            new Point(-1,-1),
            new Point(-1,0),
            new Point(-1,1),
            new Point(0,-1),
            new Point(0,1),
            new Point(1,-1),
            new Point(1,0),
            new Point(1,1)
        };

        public BoardViewModel(IContainer ioc) => _ioc = ioc;

        public BoardTile[][] Tiles { get; set; } = new BoardTile[Size][];

        public BindableCollection<ITile> Board => new BindableCollection<ITile>(Tiles.SelectMany(x => x));

        public event PropertyChangedEventHandler PropertyChanged;

        public BoardTile Create(Type? type = null)
        {
            BoardTile tile = type switch
            {
                Type.Blue     => new BoardTile("#90C2E5", 1, 2),
                Type.DarkBlue => new BoardTile("#3187C2", 1, 2),
                Type.Pink     => new BoardTile("#DB8298", 2, 1),
                Type.Red      => new BoardTile("#B3172C", 2, 1),
                Type.Star     => new BoardTile(Color.Yellow, 2, 1),
                _             => new BoardTile(Color.White, 1, 1)
            };
            _ioc.BuildUp(tile);

            return tile;
        }

        public void ResetTiles()
        {
            Tiles[0] = new[]
            {
                Create(Type.Red),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Red),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(Type.Red)
            };

            Tiles[1] = new[]
            {
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create()
            };

            Tiles[2] = new[]
            {
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create()
            };

            Tiles[3] = new[]
            {
                Create(Type.Blue),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(Type.Blue)
            };

            Tiles[4] = new[]
            {
                Create(),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create()
            };

            Tiles[5] = new[]
            {
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create()
            };

            Tiles[6] = new[]
            {
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create()
            };

            Tiles[7] = new[]
            {
                Create(Type.Red),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Star),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(Type.Red)
            };

            Tiles[8] = new[]
            {
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create()
            };

            Tiles[9] = new[]
            {
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create()
            };

            Tiles[10] = new[]
            {
                Create(),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create()
            };

            Tiles[11] = new[]
            {
                Create(Type.Blue),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(Type.Blue)
            };

            Tiles[12] = new[]
            {
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create(),
                Create()
            };

            Tiles[13] = new[]
            {
                Create(),
                Create(Type.Pink),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Pink),
                Create()
            };

            Tiles[14] = new[]
            {
                Create(Type.Red),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(),
                Create(Type.Red),
                Create(),
                Create(),
                Create(),
                Create(Type.Blue),
                Create(),
                Create(),
                Create(Type.Red)
            };

            // Make sure player can place first tile in the middle
            Tiles[Size / 2][Size / 2].IsEnabled = true;
            
            for (int y = 0; y < Tiles.Length; y++)
            {
                for (int x = 0; x < Tiles[y].Length; x++)
                {
                    Tiles[y][x].Position = new Point(x, y);
                }
            }
        }

        /// <summary>
        /// This will enable tiles that have a letter adjacent to them
        /// </summary>
        public void EnableAdjacentTiles()
        {
            ToggleAllTiles(false);

            var letterCount = Tiles.SelectMany(t => t)
               .Count(t => t.HasLetter);

            if (letterCount == 0)
            {
                Tiles[Size / 2][Size / 2].IsEnabled = true;
                return;
            }

            foreach (var tile in Tiles.SelectMany(t => t))
            {
                foreach (var adjacent in GetAdjacentTiles(tile.Position))
                {
                    if (!adjacent.HasLetter)
                        adjacent.IsEnabled = true;
                }
            }
        }

        public IEnumerable<BoardTile> GetAdjacentTiles(Point index)
        {
            foreach (var position in _adjacentPositions)
            {
                // Get the adjacent position of the current tile
                var x = index.X + position.X;
                var y = index.Y + position.Y;

                if (x < 0 || x > Size - 1)
                    continue;
                if (y < 0 || y > Size - 1)
                    continue;

                if (!Tiles[y][x].HasLetter)
                    yield return Tiles[y][x];
            }
        }

        public void ToggleTiles(Orientation orientation, Point index, bool? toggle = null)
        {
            foreach (var point in GetPoints(orientation, index))
            {
                var tile = Tiles[point.Y][point.X];
                tile.IsEnabled = toggle ?? !tile.IsEnabled;
            }
        }

        public IEnumerable<Point> GetPoints(Orientation orientation, Point index)
        {
            return orientation switch
            {
                Orientation.Both =>
                           GeneratePoints(Orientation.Horizontal, index)
                   .Concat(GeneratePoints(Orientation.Vertical, index)),
                Orientation.Horizontal => GeneratePoints(Orientation.Horizontal, index),
                Orientation.Vertical   => GeneratePoints(Orientation.Vertical, index),
                _                      => Enumerable.Empty<Point>()
            };
        } 

        private IEnumerable<Point> GeneratePoints(Orientation orientation, Point index)
        {
            for (int i = 0; i < Size; i++)
            {
                yield return orientation switch
                {
                    Orientation.Horizontal => new Point(i, index.Y),
                    Orientation.Vertical   => new Point(index.X, i)
                };
            }
        }

        public void ToggleTiles(IEnumerable<ITile> tiles, bool? toggle = null)
        {
            foreach (var tile in tiles)
                tile.IsEnabled = toggle ?? !tile.IsEnabled;
        }

        public void ToggleAllTiles(bool? toggle = null)
        {
            foreach (var tiles in Tiles)
            {
                ToggleTiles(tiles, toggle);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}