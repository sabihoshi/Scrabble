using System.Collections.Generic;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel
    {
        public GameWindowViewModel()
        {
            Tile.PlacedLetter = "B";
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public Tile Tile { get; set; } = new Tile();
    }
}