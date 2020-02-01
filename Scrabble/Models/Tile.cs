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

        public IEnumerable<Point> SearchGenerator(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int i = Origin.Position.Y; i >= 0; i--)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Down:
                    for (int i = Origin.Position.Y; i < Board.Size; i++)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Left:
                    for (int i = Origin.Position.X; i >= 0; i--)
                        yield return new Point(i, Origin.Position.Y);

                    break;

                case Direction.Right:
                    for (int i = Origin.Position.X; i < Board.Size; i++)
                        yield return new Point(i, Origin.Position.Y);

                    break;
                case Direction.None: break;
                default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public IEnumerable<Point> SearchGeneratorLinq(Direction direction)
        {
            return direction switch
            {
                Direction.Up => Enumerable.Range(0, Origin.Position.Y)
                   .Reverse()
                   .Select(y => new Point(Origin.Position.X, y)),
                Direction.Down => Enumerable.Range(Origin.Position.Y, Board.Size)
                   .Select(y => new Point(Origin.Position.X, y)),
                Direction.Left => Enumerable.Range(0, Origin.Position.X)
                   .Reverse()
                   .Select(x => new Point(x, Origin.Position.Y)),
                Direction.Right => Enumerable.Range(Origin.Position.X, Board.Size)
                   .Select(x => new Point(x, Origin.Position.Y)),
                _ => Enumerable.Empty<Point>()
            };
        }
    }
}