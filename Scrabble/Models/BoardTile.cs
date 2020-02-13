using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class BoardTile : TileBase
    {
        public BoardTile(string tileColor, int letterMultiplier, int wordMultiplier) : base(tileColor)
        {
            LetterMultiplier = letterMultiplier;
            WordMultiplier = wordMultiplier;
        }

        public BoardTile(Color color, int letterMultiplier, int wordMultiplier) : this(color.Name,
            letterMultiplier, wordMultiplier) { }

        public int LetterMultiplier { get; set; }

        public int WordMultiplier { get; set; }

        public Player PlacedBy { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(TileBase.PlacedLetter.Character.ToString());

        public Point Position { get; set; }

        public TileBase TileBase { get; }

        public static BoardTile Create(Type? type = null)
        {
            return type switch
            {
                Type.Blue     => new BoardTile("#90C2E5", 1, 2),
                Type.DarkBlue => new BoardTile("#3187C2", 1, 2),
                Type.Pink     => new BoardTile("#DB8298", 2, 1),
                Type.Red      => new BoardTile("#B3172C", 2, 1),
                Type.Star     => new BoardTile(Color.Yellow, 2, 1),
                _             => new BoardTile(Color.White, 1, 1)
            };
        }
    }
}