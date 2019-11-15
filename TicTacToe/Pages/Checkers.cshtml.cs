using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicTacToe.Checkers;

namespace TicTacToe.Pages
{
    public class CkeckersModel : PageModel
    {
        public Game Game;

        public void OnGet()
        {
            Game = new Game();
        }

        public void onPost(string state, int fromX, int fromY, int toX, int toY)
        {
            Game = new Game(state);
            Checker checker = Game.Board[fromX, fromY];
            if (Game.Turn == checker.Color)
            {
                Game.Board[toX, toY] = checker;
                Game.Board[fromX, fromY] = null;
                Game.Turn = Game.Turn == Color.black ? Color.red : Color.black;
            }
        }
    }
}