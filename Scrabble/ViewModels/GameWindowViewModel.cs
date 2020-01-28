using System.Collections.Generic;
using Scrabble.Models;

namespace Scrabble.ViewModels
{
    public class GameWindowViewModel
    {
        public List<Player> Players { get; set; } = new List<Player>();
    }
}