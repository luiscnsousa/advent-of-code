namespace AdventOfCode2016.Common
{
    using System;
    using System.Collections.Generic;

    public class Compass
    {
        private LinkedList<Direction> _directions;

        public Direction Direction { get; private set; }
        
        public Compass()
        {
            _directions = new LinkedList<Direction>();
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                _directions.AddLast(direction);
            }

            Direction = Direction.North;
        }

        public Direction TurnRight()
        {
            var current = _directions.Find(Direction);
            var next = current.Next ?? current.List.First;
            Direction = next.Value;
            return Direction;
        }

        public Direction TurnLeft()
        {
            var current = _directions.Find(Direction);
            var next = current.Previous ?? current.List.Last;
            Direction = next.Value;
            return Direction;
        }
    }
}