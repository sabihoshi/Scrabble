using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Scrabble.Models
{
    public class Tile
    {
        public Player PlacedBy { get; set; }

        public string PlacedLetter { get; set; }

        public bool HasLetter => string.IsNullOrWhiteSpace(PlacedLetter);

        public Point Position { get; set; }
    }

    public class SearchNode
    {
        public enum Direction
        {
            None,
            Up,
            Down,
            Left,
            Right
        }

        public enum Orientation
        {
            None,
            Vertical,
            Horizontal
        }

        public Tile Origin { get; set; }

        public Board Board { get; set; }

        public void Search() { }

        // This does not include the starting position, as we already know
        // It is a guaranteed letter.
        public IEnumerable<Point> SearchGenerator(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int i = Origin.Position.Y - 1; i >= 0; i--)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Down:
                    for (int i = Origin.Position.Y + 1; i < Board.Size; i++)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Left:
                    for (int i = Origin.Position.X - 1; i >= 0; i--)
                        yield return new Point(i, Origin.Position.Y);

                    break;

                case Direction.Right:
                    for (int i = Origin.Position.X + 1; i < Board.Size; i++)
                        yield return new Point(i, Origin.Position.Y);

                    break;
                case Direction.None: break;
                default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}