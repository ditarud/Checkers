using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarea1.Utility;

namespace Tarea1
{
    public class GameBoard
    {
        #region Fields        
        private int columns;
        private int rows;
       
        private int preLastRow;
        private int lastRow;
        private bool isEvenBoard;
      
        private List<int> numbers = new List<int>();
        private List<string> letters = new List<string>();        
        private string[,] board;
        #endregion

        #region Constants
        private const int FIRST_ROW = 0;
        private const int SECOND_ROW = 1;
        private const string PLAYER_TAG = "O";
        private const string CPU_TAG = "X";
        private const string BLACK_SPACE = " ";
        private const string WHITE_SPACE = ".";
        #endregion

        #region Properties
        public string[,] Board
        {
            get
            {
                return board;
            }

            set
            {
                board = value;
            }
        }

        public List<int> Numbers
        {
            get
            {
                return numbers;
            }

            set
            {
                numbers = value;
            }
        }      

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }

        public bool IsEvenBoard
        {
            get
            {
                return isEvenBoard;
            }

            set
            {
                isEvenBoard = value;
            }
        }

        public List<string> Letters
        {
            get
            {
                return letters;
            }

            set
            {
                letters = value;
            }
        }

        #endregion
        public void InitializeBoard()
        {
           
            preLastRow = Rows - 2;
            lastRow = Rows - 1;
            for (int j = 0; j < rows; j++)
            {                                
                for (int i = 0; i < columns; i++)
                {                    
                    if (IsEvenBoard)
                    {
                        // Si tablero es par (ej: 8x8)
                        CreateEvenBoard(i, j);
                    }
                    else
                    {
                        // Si tablero es impar (ej: 7x7)
                        CreateOddBoard(i, j);                        
                    }
                    
                    if (board[i,j] != CPU_TAG && board[i, j] != PLAYER_TAG && board[i, j] != WHITE_SPACE)
                    {
                        board[i, j] = BLACK_SPACE;                       
                    }
                }
            }                
        }

        public void CreateEvenBoard(int columns, int rows)
        {
            if (IsOdd(columns) && IsOdd(rows))
            {
                board[FIRST_ROW, columns] = CPU_TAG;
                board[preLastRow, columns] = PLAYER_TAG;
                board[columns, rows] = WHITE_SPACE;
            }

            if (IsEven(columns) && IsEven(rows))
            {
                board[SECOND_ROW, columns] = CPU_TAG;
                board[lastRow, columns] = PLAYER_TAG;
                board[columns, rows] = WHITE_SPACE;
            }
        }

        public void CreateOddBoard(int columns, int rows)
        {
            if (IsOdd(columns) && IsOdd(rows))
            {
                board[FIRST_ROW, columns] = CPU_TAG;
                board[lastRow, columns] = PLAYER_TAG;
                board[columns, rows] = WHITE_SPACE;
            }

            if (IsEven(columns) && IsEven(rows))
            {
                board[SECOND_ROW, columns] = CPU_TAG;
                board[preLastRow, columns] = PLAYER_TAG;
                board[columns, rows] = WHITE_SPACE;
            }
        }
        public void CreateGameBoard()
        {
            Console.WriteLine("Selección de tamaño de tablero (Máximo 26x26)");

            Console.Write("Ingrese numero de columnas: ");          
            int numberOfColumns;
            while (!int.TryParse(Console.ReadLine(), out numberOfColumns))
            {
                Console.WriteLine("Debe ingresar un numero");
            }

            Console.Write("Ingrese numero de filas: ");
            int numberOfRows;
            while (!int.TryParse(Console.ReadLine(), out numberOfRows))
            {
                Console.WriteLine("Debe ingresar un numero");
            }

            Columns = numberOfColumns;
            Rows = numberOfRows;
            Board = new string[Columns, Rows];
            if (IsEven(columns))
            {
                IsEvenBoard = true;
            }

            AddNumbers();
            AddLetters();
            DisplayGameBoard();
          
        }
      

        public void DisplayGameBoard()
        {
            Console.Write(string.Format("    {0}", letters[0]));
            for (int i = 1; i < letters.Count-1; i++)
            {
                
                Console.Write(string.Format("  {0}", letters[i]));
            }
            
            for (int i = 0; i < columns; i++)
            {
                Console.Write("\n");
                Console.Write(string.Format("{0,2}" ,numbers[i]));
                for (int j = 0; j < rows; j++)
                {                    
                    InitializeBoard();
                    Console.Write(string.Format(" |{0}", board[i, j]));                  
                }
                Console.Write(" |");
            }
            Console.Write("\n");
        }
        public void UpdateGameBoard(int positionX, int positionY)
        {
            Console.Write(string.Format("    {0}", letters[0]));
            for (int i = 1; i < letters.Count - 1; i++)
            {

                Console.Write(string.Format("  {0}", letters[i]));
            }
            for (int i = 0; i < columns; i++)
            {
                Console.Write("\n");
                Console.Write(string.Format("{0,2}", numbers[i]));
                for (int j = 0; j < rows; j++)
                {                   
                    board[positionX, positionY] = BLACK_SPACE;
                    Console.Write(string.Format(" |{0}", board[i, j]));
                }
                Console.Write(" |");
            }

            Console.Write("\n");            
            
        }

        public void AddLetters()
        {
            int lettersToAdd = 1;

            for (int i = 0; i <= Columns; i++)
            {               
                letters.Add(ConvertNumberToLetter(i));
                lettersToAdd++;
            }
        }

        public void AddNumbers()
        {
            int numbersToAdd = 1;

            for (int i = 0; i < Rows; i++)
            {
                numbers.Add(numbersToAdd);
                numbersToAdd++;
            }
        }

       
    }
}
