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
    class TokenTests
    {
        [TestCase]
        public void CreateXToken_AddingRows_RetrunsRowsEqualToXTokens()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();
            Token token = new Token();            

            // Act  
            gameBoard.Rows = 3;
            token.CreateXTokens(gameBoard);            
            int xTokens = token.XTokens.Count;

            // Assert
            Assert.AreEqual(gameBoard.Rows, xTokens);
        }
        [TestCase]
        public void CreateOToken_AddingRows_RetrunsRowsEqualToOTokens()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();
            Token token = new Token();            

            // Act  
            gameBoard.Rows = 10;
            token.CreateOTokens(gameBoard);
            int OTokens = token.OTokens.Count;

            // Assert
            Assert.AreEqual(gameBoard.Rows, OTokens);
        }
        [TestCase]
        public void CreateAllPositions_Board8x8_Returns32()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();
            Token token = new Token();            

            // Act              
            gameBoard.Rows = 8;
            gameBoard.Columns = 8;
            gameBoard.Board = new string[gameBoard.Rows, gameBoard.Columns];
            token.CreateAllPositions(gameBoard);
            int positions = token.Positions.Count;

            // Assert
            Assert.AreEqual(gameBoard.Rows * gameBoard.Columns, positions);
        }

        [TestCase]
        public void CreateAllPositions_Board10x10_Returns100()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();
            Token token = new Token();           

            // Act              
            gameBoard.Rows = 10;
            gameBoard.Columns = 10;
            gameBoard.Board = new string[gameBoard.Rows, gameBoard.Columns];
            token.CreateAllPositions(gameBoard);
            int positions = token.Positions.Count;

            // Assert
            Assert.AreEqual(gameBoard.Rows * gameBoard.Columns, positions);
        }

    }
}
