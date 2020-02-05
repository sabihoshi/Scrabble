﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Scrabble.ViewModels;

namespace Scrabble.Models
{
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

        public SearchNode(Tile origin, Board board, Orientation searchOrientation)
        {
            Origin = origin;
            Board = board;
            SearchOrientation = searchOrientation;
        }

        public static List<SearchNode> Nodes { get; } = new List<SearchNode>();

        public Tile Origin { get; set; }

        public Board Board { get; set; }

        public Orientation SearchOrientation { get; set; }

        public Point Start { get; set; }

        public Point End { get; set; }

        public SearchNode InverseNode(Point start)
        {
            return new SearchNode(Board.Tiles[start.Y][start.X], Board, Inverse(SearchOrientation));
        }

        public void Search()
        {
            if (SearchOrientation == Orientation.Horizontal)
            {
                Start = Seek(Direction.Up);
                End = Seek(Direction.Down);
            }
            else
            {
                Start = Seek(Direction.Left);
                End = Seek(Direction.Right);
            }
        }

        public Point Seek(Direction direction)
        {
            var result = Origin.Position;
            foreach (var position in SearchGenerator(direction))
            {
                if (!Nodes.Any(n => n.Origin.Position == position && n.SearchOrientation == Inverse(SearchOrientation)))
                    Nodes.Add(InverseNode(position));

                if (position.IsEmpty)
                    break;

                result = position;
            }

            return result;
        }

        public Orientation Inverse(Orientation orientation)
        {
            return orientation == Orientation.Horizontal ? Orientation.Vertical : Orientation.Horizontal;
        }

        // This does not include the starting position, as we already know
        // It is a guaranteed letter.
        public IEnumerable<Point> SearchGenerator(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (var i = Origin.Position.Y - 1; i >= 0; i--)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Down:
                    for (var i = Origin.Position.Y + 1; i < Board.Size; i++)
                        yield return new Point(Origin.Position.X, i);

                    break;
                case Direction.Left:
                    for (var i = Origin.Position.X - 1; i >= 0; i--)
                        yield return new Point(i, Origin.Position.Y);

                    break;

                case Direction.Right:
                    for (var i = Origin.Position.X + 1; i < Board.Size; i++)
                        yield return new Point(i, Origin.Position.Y);

                    break;
                case Direction.None: break;
                default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}