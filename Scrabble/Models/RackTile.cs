using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Scrabble.Models
{
    public class RackTile : TileBase
    {
        public RackTile() : base("#EDBD11") { PlacedLetter = LetterBag.GetLetter(); }

        public Color ForegroundColor { get ; set; }


    }
}
