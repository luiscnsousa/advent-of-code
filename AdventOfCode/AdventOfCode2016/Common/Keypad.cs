namespace AdventOfCode2016.Common
{
    public class Keypad
    {
        private readonly string[,] _keys;
        private int _column;
        private int _row;
        
        public string Code { get; private set; }

        public Keypad(KeypadType type = KeypadType.Normal)
        {
            if (type == KeypadType.Normal)
            {
                _keys = new [,]
                {
                    { "1", "2", "3" },
                    { "4", "5", "6" },
                    { "7", "8", "9" }
                };
            
                _row = 1;
                _column = 1;
            }
            else
            {
                _keys = new [,]
                {
                    { " ", " ", "1", " ", " " },
                    { " ", "2", "3", "4", " " },
                    { "5", "6", "7", "8", "9" },
                    { " ", "A", "B", "C", " " },
                    { " ", " ", "D", " ", " " }
                };
            
                _row = 2;
                _column = 0;
            }
            
            Code = string.Empty;
        }

        public void PressNextKey(string input)
        {
            foreach (var direction in input)
            {
                switch (direction)
                {
                    case 'U':
                        if (_row - 1 >= 0 && !string.IsNullOrWhiteSpace(_keys[_row - 1, _column]))
                        {
                            _row--;
                        }
                        break;
                    
                    case 'D':
                        if (_row + 1 < _keys.GetLength(0) && !string.IsNullOrWhiteSpace(_keys[_row + 1, _column]))
                        {
                            _row++;
                        }
                        break;
                    
                    case 'L':
                        if (_column - 1 >= 0 && !string.IsNullOrWhiteSpace(_keys[_row, _column - 1]))
                        {
                            _column--;
                        }
                        break;
                    
                    case 'R':
                        if (_column + 1 < _keys.GetLength(0) && !string.IsNullOrWhiteSpace(_keys[_row, _column + 1]))
                        {
                            _column++;
                        }
                        break;
                }
            }

            Code += _keys[_row, _column];
        }

        public enum KeypadType
        {
            Normal, 
            Complex
        }
    }
}