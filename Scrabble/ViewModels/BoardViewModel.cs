using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Stylet;
using static Scrabble.ViewModels.Tile;

namespace Scrabble.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public const int Size = 15;

        public Tile[][] Tiles { get; set; } = new Tile[Size][];

        public BindableCollection<Tile> Board => new BindableCollection<Tile>(Tiles.SelectMany(x => x));

        public event PropertyChangedEventHandler PropertyChanged;

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
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}