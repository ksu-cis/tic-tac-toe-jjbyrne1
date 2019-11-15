using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Checkers
{
    public class Checker
    {
        public Color Color;
        public bool isKing = false;

        public Checker(Color color, bool king=false)
        {
            Color = color;
            isKing = king;
        }
    }
}
