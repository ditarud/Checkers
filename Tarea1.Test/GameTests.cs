using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tarea1;

namespace Tarea1.Test
{
    [TestFixture]
    class GameTests
    {
        [TestCase]
        public void CheckWinner_ZeroXTokensLeft_IsWinnerTrue()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();            
            Game game = new Game(gameBoard);

            // Act          
            game.CheckWinner();
            
            
            // Assert
            Assert.IsTrue(game.IsWinner);
        }

        [TestCase]
        public void CheckWinner_IsWinner_CanMoveFalse()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();            
            Game game = new Game(gameBoard);

            // Act       
            game.IsWinner = true;   
            game.CheckWinner();

            // Assert
            Assert.IsFalse(game.CanMove);
        }
                

        [TestCase]
        public void CheckWinner_ZeroOTokensLeft_IsWinnerTrue()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();            
            Game game = new Game(gameBoard);

            // Act          
            game.CheckWinner();


            // Assert
            Assert.IsTrue(game.IsWinner);
        }
    }
}
