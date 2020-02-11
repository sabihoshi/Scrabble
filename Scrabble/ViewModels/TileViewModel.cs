using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class TileViewModel : INotifyPropertyChanged
    {
        public enum Type
        {
            Blue,
            DarkBlue,
            Pink,
            Red,
            Star
        }

        public TileViewModel(string tileColor, int letterMultiplier, int wordMultiplier)
        {
            TileColor = tileColor;
            LetterMultiplier = letterMultiplier;
            WordMultiplier = wordMultiplier;
        }

        public TileViewModel(Color color, int letterMultiplier, int wordMultiplier) : this(color.Name, letterMultiplier, wordMultiplier) { }

        public int LetterMultiplier { get; set; }

        public int WordMultiplier { get; set; }

        public string TileColor { get; set; }

        public Player PlacedBy { get; set; }

        public string PlacedLetter { get; set; } = "A";

        public bool HasLetter => string.IsNullOrWhiteSpace(PlacedLetter);

        public Point Position { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TileViewModel Create(Type? type = null)
        {
            return type switch
            {
                Type.Blue     => new TileViewModel("#90C2E5", 1, 2),
                Type.DarkBlue => new TileViewModel("#3187C2", 1, 2),
                Type.Pink     => new TileViewModel("#DB8298", 2, 1),
                Type.Red      => new TileViewModel("#B3172C", 2, 1),
                Type.Star     => new TileViewModel(Color.Yellow, 2, 1),
                _             => new TileViewModel(Color.White, 1, 1)
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}