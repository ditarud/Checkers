using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarea1.Utility;


namespace Tarea1
{
    public class Token
    {

        #region Fields
        private List<string> positions = new List<string>();      
        private List<string> oTokens = new List<string>();        
        private List<string> xTokens = new List<string>();
        private List<string> oTokensDeleted = new List<string>();
        private List<string> xTokensDeleted = new List<string>();

        #endregion

        #region Constants
        private const string PLAYER_TAG = "O";
        private const string CPU_TAG = "X";
        private const string BLACK_SPACE = " ";
        private const string WHITE_SPACE = ".";
        #endregion

        public List<string> Positions
        {
            get
            {
                return positions;
            }

            set
            {
                positions = value;
            }
        }

        public List<string> OTokens
        {
            get
            {
                return oTokens;
            }

            set
            {
                oTokens = value;
            }
        }

        public List<string> XTokens
        {
            get
            {
                return xTokens;
            }

            set
            {
                xTokens = value;
            }
        }

        public List<string> XTokensDeleted
        {
            get
            {
                return xTokensDeleted;
            }

            set
            {
                xTokensDeleted = value;
            }
        }

        public List<string> OTokensDeleted
        {
            get
            {
                return oTokensDeleted;
            }

            set
            {
                oTokensDeleted = value;
            }
        }
       
        public void CreateOTokens(GameBoard gameBoard)
        {
            for (int j = gameBoard.Rows - 2 ; j < gameBoard.Rows; j++)
            {
                for (int i = 0; i < gameBoard.Rows; i++)
                {                   
                        if (IsOdd(j) && IsEven(i))
                        {
                            string token = (Char)j + 1 + ConvertNumberToLetter(i);
                            oTokens.Add(token);
                        }

                        if (IsOdd(i) && IsEven(j))
                        {
                            string token = (Char)j + 1 + ConvertNumberToLetter(i);
                            oTokens.Add(token);
                        }  
                }
            }   
        }
        public void CreateXTokens(GameBoard gameBoard)
        {                 
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < gameBoard.Rows; i++)
                {                   
                        if (IsOdd(j) && IsEven(i))
                        {                               
                            string token = (Char)j + 1 + ConvertNumberToLetter(i);
                            xTokens.Add(token);
                        }

                        if (IsOdd(i) && IsEven(j))
                        {
                            string token = (Char)j + 1 + ConvertNumberToLetter(i);
                            xTokens.Add(token);
                        }    
                }
            }
         }
        public void CreateAllPositions(GameBoard gameBoard)
        {
            for (int j = 0; j < gameBoard.Rows; j++)
            {
                for (int i = 0; i < gameBoard.Columns; i++)
                {
                    if (gameBoard.Board[i, j] == CPU_TAG || gameBoard.Board[i, j] == PLAYER_TAG || gameBoard.Board[i, j] != WHITE_SPACE)
                    {
                        string position = (Char)j + 1 + ConvertNumberToLetter(i);
                        positions.Add(position);
                    }
                }
            } 
        }
    }    
}
