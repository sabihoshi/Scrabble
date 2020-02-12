using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class BoardTileViewModel : TileViewModel
    {
        public BoardTileViewModel(string tileColor, int letterMultiplier, int wordMultiplier) : base(tileColor)
        {
            LetterMultiplier = letterMultiplier;
            WordMultiplier = wordMultiplier;
        }

        public BoardTileViewModel(Color color, int letterMultiplier, int wordMultiplier) : this(color.Name,
            letterMultiplier, wordMultiplier) { }

        public int LetterMultiplier { get; set; }

        public int WordMultiplier { get; set; }

        public Player PlacedBy { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(TileViewModel.PlacedLetter);

        public Point Position { get; set; }

        public TileViewModel TileViewModel { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static BoardTileViewModel Create(Type? type = null)
        {
            return type switch
            {
                Type.Blue     => new BoardTileViewModel("#90C2E5", 1, 2),
                Type.DarkBlue => new BoardTileViewModel("#3187C2", 1, 2),
                Type.Pink     => new BoardTileViewModel("#DB8298", 2, 1),
                Type.Red      => new BoardTileViewModel("#B3172C", 2, 1),
                Type.Star     => new BoardTileViewModel(Color.Yellow, 2, 1),
                _             => new BoardTileViewModel(Color.White, 1, 1)
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}