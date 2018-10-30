using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tarea1;

namespace Tarea1.Test
{   [TestFixture]
    public class GameBoardTests
    {        
       [TestCase]
       public void AddLetters_Board4X4_Return4()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();           
           
            // Act  
            gameBoard.Columns = 3;
            gameBoard.AddLetters();
            
            // Assert
            Assert.AreEqual(4, gameBoard.Letters.Count);
        }

        [TestCase]
        public void AddNumbers_Board5X5_Return5()
        {
            // Arrange            
            GameBoard gameBoard = new GameBoard();            
            
            // Act  
            gameBoard.Rows = 5;
            gameBoard.AddNumbers();

            // Assert
            Assert.AreEqual(5, gameBoard.Numbers.Count);
        }

        
    }
}
