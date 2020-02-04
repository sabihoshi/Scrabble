using Scrabble.ViewModels;

namespace Scrabble.Models
{
    public class Board
    {
        public const int Size = 15;

        public TileViewModel[][] Tiles { get; set; }

        public void ResetTiles()
        {
        }
    }
}