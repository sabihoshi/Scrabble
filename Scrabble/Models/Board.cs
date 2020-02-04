using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Scrabble.ViewModels;

namespace Scrabble.Models
{
    public class Board
    {
        public const int Size = 15;

        public void ResetTiles()
        {

        }

        public TileViewModel[][] Tiles { get; set; }


    }
}
