using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class Tile : INotifyPropertyChanged
    {
        public enum Type
        {
            Blue,
            DarkBlue,
            Pink,
            Red,
            Star
        }

        public Tile(Color color, int letterMultiplier, int wordMultiplier)
        {
            Color = color;
            LetterMultiplier = letterMultiplier;
            WordMultiplier = wordMultiplier;
        }

        public Tile(string color, int letterMultiplier, int wordMultiplier) : this(StringToColor(color),
            letterMultiplier, wordMultiplier) { }

        public int LetterMultiplier { get; set; }

        public int WordMultiplier { get; set; }

        public Color Color { get; set; }

        public Player PlacedBy { get; set; }

        public string PlacedLetter { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(PlacedLetter);

        public Point Position { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static Tile Create(Type? type = null)
        {
            return type switch
            {
                Type.Blue     => new Tile("#90C2E5", 1, 2),
                Type.DarkBlue => new Tile("#3187C2", 1, 2),
                Type.Pink     => new Tile("#DB8298", 2, 1),
                Type.Red      => new Tile("#B3172C", 2, 1),
                Type.Star     => new Tile(Color.Yellow, 2, 1),
                _             => new Tile(Color.White, 1, 1)
            };
        }

        private static Color StringToColor(string color)
        {
            int argb = int.Parse(color.Replace("#", ""), NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}