using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Scrabble.Models.Tile;
using Stylet;
using static Scrabble.Models.Tile.BoardTile;
using IContainer = StyletIoC.IContainer;

namespace Scrabble.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public const int Size = 15;
        private readonly IContainer _ioc;

        public BoardViewModel(IContainer ioc) => _ioc = ioc;

        public ITile[][] Tiles { get; set; } = new ITile[Size][];

        public BindableCollection<ITile> Board => new BindableCollection<ITile>(Tiles.SelectMany(x => x));

        public event PropertyChangedEventHandler PropertyChanged;

        public ITile Create(Type? type = null)
        {
            ITile tile = type switch
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

            Tiles[Size / 2][Size / 2].IsEnabled = true;
        }

        public void ToggleTiles(Orientation orientation, int index, bool? toggle = null)
        {
            foreach (var point in GetPoints(orientation, index))
            {
                var tile = Tiles[point.Y][point.X];
                tile.IsEnabled = toggle ?? !tile.IsEnabled;
            }
        }

        public IEnumerable<Point> GetPoints(Orientation orientation, int index)
        {        
            for (int i = 0; i < Size; i++)
            {
                yield return orientation switch
                {
                    Orientation.Horizontal => new Point(i, index),
                    Orientation.Vertical => new Point(index, i)
                };
            }
        }

        public void ToggleTiles(ITile[] tiles, bool? toggle = null)
        {
            foreach (var tile in tiles) { tile.IsEnabled = toggle ?? !tile.IsEnabled; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}