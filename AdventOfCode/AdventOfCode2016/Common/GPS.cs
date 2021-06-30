namespace AdventOfCode2016.Common
{
    using System;
    using System.Collections.Generic;

    public class GPS
    {
        private readonly Compass _compass;
        private int _xPos;
        private int _yPos;
        private List<string> _posHistory;

        public GPS(Compass compass)
        {
            _compass = compass;
            _posHistory = new List<string> { "0,0" };
        }

        public void Go(string next)
        {
            var turn = next.Substring(0, 1).ToUpperInvariant();
            var direction = turn == "R"
                ? _compass.TurnRight()
                : _compass.TurnLeft();

            var distance = int.Parse(next.Substring(1));
            switch (direction)
            {
                case Direction.North:
                    for (var i = 0; i < distance; i++)
                    {
                        _yPos++;
                        _posHistory.Add($"{_xPos},{_yPos}");
                    }
                    break;
                case Direction.East:
                    for (var i = 0; i < distance; i++)
                    {
                        _xPos++;
                        _posHistory.Add($"{_xPos},{_yPos}");
                    }
                    break;
                case Direction.South:
                    for (var i = 0; i < distance; i++)
                    {
                        _yPos--;
                        _posHistory.Add($"{_xPos},{_yPos}");
                    }
                    break;
                case Direction.West:
                    for (var i = 0; i < distance; i++)
                    {
                        _xPos--;
                        _posHistory.Add($"{_xPos},{_yPos}");
                    }
                    break;
            }
        }

        public int GetDistance(int? x = null, int? y = null)
        {
            x ??= _xPos;
            y ??= _yPos;
            return Math.Abs(x.Value) + Math.Abs(y.Value);
        }

        public string GetPlaceRevisited()
        {
            if (_posHistory.Count < 2)
            {
                return null;
            }
            
            for (var i = 0; i < _posHistory.Count - 1; i++)
            {
                for (var j = i + 1; j < _posHistory.Count; j++)
                {
                    if (_posHistory[i] == _posHistory[j])
                    {
                        return _posHistory[i];
                    }
                }
            }

            return null;
        }
    }
}