using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Checkers
{
    public class Game
    {
        public Color Turn;

        public Checker[,] Board = new Checker[8, 8];

        public Game()
        {
            for (int i = 0; i < 8; i+=2)
            {
                // Black checkers
                Board[i, 0] = new Checker(Color.black);
                Board[i+1, 1] = new Checker(Color.black);
                Board[i, 2] = new Checker(Color.black);

                // Red checkers
                Board[i+1, 5] = new Checker(Color.red);
                Board[i, 6] = new Checker(Color.red);
                Board[i+1, 7] = new Checker(Color.red);
            }
        }

        public Game(string state)
        {
            string[] lines = state.Split("\r\n");
            Turn = (Color) Enum.Parse(typeof(Color),lines[0]);
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] parts = lines[i].Split(",");
                Color color = parts[0].Equals("black") ? Color.black : Color.red;
                bool king = bool.Parse(parts[1]);
                int x = int.Parse(parts[2]);
                int y = int.Parse(parts[3]);
                Board[x, y] = new Checker(color, king);
            }
        }

        public string Serialize()
        {
            string state = Turn.ToString() + "\n";
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if(Board[x,y] != null)
                    {
                        Checker checker = Board[x, y];
                        state += $"{checker.Color},{checker.isKing},{x},{y}\n";
                    }
                }
            }
            return state;
        }
    }
}
