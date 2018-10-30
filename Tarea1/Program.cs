using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            GameBoard gameBoard = new GameBoard();
            gameBoard.CreateGameBoard();

            Game game = new Game(gameBoard);

            Input IO = new Input();
            game.Play(gameBoard,IO);
        }
    }
}
