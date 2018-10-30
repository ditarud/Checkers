using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Tarea1.Utility;

namespace Tarea1
{
    public class Game
    {
        #region Generic Fields
        private bool isCpu;
        private bool canMove;
        private bool isWinner;
        private bool isMultipleMovement = false;
        private int MAX_INDEX_TOKEN_LIST;
        private const int MIN_INDEX_TOKEN_LIST = 0;
        private Token _tokens;
        #endregion

        #region Player Fields
        private int xPositionOfToken;
        private int yPositionOfToken;
        private int xDestination;
        private int yDestination;
        private string destination;
        private string selectToken;
        private const string PLAYER_TAG = "O";
        #endregion

        #region CPU Fields
        private int xPositionOfTokenCpu;
        private int yPositionOfTokenCpu;
        private int xDestinationCpu;
        private int yDestinationCpu;
        private string cpuDestination;
        private string cpuToken;
        private const string CPU_TAG = "X";
        #endregion

        #region Properties
        public bool IsCpu
        {
            get
            {
                return isCpu;
            }

            set
            {
                isCpu = value;
            }
        }

        public string SelectToken
        {
            get
            {
                return selectToken;
            }

            set
            {
                selectToken = value;
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }

            set
            {
                destination = value;
            }
        }

        public Token Tokens
        {
            get
            {
                return _tokens;
            }

            set
            {
                _tokens = value;
            }
        }

        public int XPositionOfToken
        {
            get
            {
                return xPositionOfToken;
            }

            set
            {
                xPositionOfToken = value;
            }
        }

        public int YPositionOfToken
        {
            get
            {
                return yPositionOfToken;
            }

            set
            {
                yPositionOfToken = value;
            }
        }

        public int XDestination
        {
            get
            {
                return xDestination;
            }

            set
            {
                xDestination = value;
            }
        }

        public int YDestination
        {
            get
            {
                return yDestination;
            }

            set
            {
                yDestination = value;
            }
        }

        public string CpuToken
        {
            get
            {
                return cpuToken;
            }

            set
            {
                cpuToken = value;
            }
        }

        public int YPositionOfTokenCpu
        {
            get
            {
                return yPositionOfTokenCpu;
            }

            set
            {
                yPositionOfTokenCpu = value;
            }
        }

        public int XPositionOfTokenCpu
        {
            get
            {
                return xPositionOfTokenCpu;
            }

            set
            {
                xPositionOfTokenCpu = value;
            }
        }

        public string CpuDestination
        {
            get
            {
                return cpuDestination;
            }

            set
            {
                cpuDestination = value;
            }
        }

        public int XDestinationCpu
        {
            get
            {
                return xDestinationCpu;
            }

            set
            {
                xDestinationCpu = value;
            }
        }

        public int YDestinationCpu
        {
            get
            {
                return yDestinationCpu;
            }

            set
            {
                yDestinationCpu = value;
            }
        }

        public bool CanMove
        {
            get
            {
                return canMove;
            }

            set
            {
                canMove = value;
            }
        }

        public bool IsWinner
        {
            get
            {
                return isWinner;
            }

            set
            {
                isWinner = value;
            }
        }

        #endregion


        public Game(GameBoard gameBoard)
        {
            _tokens = new Token();
            _tokens.CreateOTokens(gameBoard);
            _tokens.CreateXTokens(gameBoard);
            _tokens.CreateAllPositions(gameBoard);
            MAX_INDEX_TOKEN_LIST = _tokens.OTokens.Count - 1;
        }
        public void Play(GameBoard gameBoard,Input input)
        {
            
            Console.WriteLine("Sus fichas son las O y del computador las X");
            isCpu = false;
            while (true)
            {
                if (isCpu && !isMultipleMovement)
                {
                    input.CpuInput(gameBoard, this);
                }
                else if (isWinner)
                {
                    break;
                }
                else
                {
                    input.SelectTokenPlayer(gameBoard, this);
                    Console.WriteLine("Verificando si puede comer nuevamente..");
                    if (VerifyEatValidationsPlayer(gameBoard) == true)
                    {
                        Console.WriteLine("Si es posible");
                        //input.DestinationTokenPlayer(gameBoard, this);
                        isMultipleMovement = true;
                    }
                    else
                    {
                        isMultipleMovement = false;
                    }
                }
            }
            Console.ReadKey();
        }
        public void MovePlayer(GameBoard gameBoard)
        {
            canMove = true;
            _tokens.OTokens.Remove(selectToken);
            gameBoard.Board[xDestination - 1, yDestination] = PLAYER_TAG;
            _tokens.OTokens.Add(destination);
            gameBoard.UpdateGameBoard(xPositionOfToken - 1, yPositionOfToken);
            isCpu = true;
            CheckWinner();
        }
        public void MoveCpu(GameBoard gameBoard)
        {
            canMove = true;
            CheckWinner();
            if (_tokens.Positions.Contains(cpuDestination))
            {
                _tokens.XTokens.Remove(cpuToken);
                _tokens.XTokens.Add(cpuDestination);
                gameBoard.Board[xDestinationCpu - 1, yDestinationCpu] = CPU_TAG;
                Console.WriteLine("-------------------------");
                Console.WriteLine("Jugada de la computadora");
                gameBoard.UpdateGameBoard(xPositionOfTokenCpu - 1, yPositionOfTokenCpu);
                isCpu = false;
            }
        }
        public void EatToken(GameBoard gameBoard)
        {
            canMove = true;
            Console.WriteLine("COMER");
            _tokens.OTokens.Remove(selectToken);
            gameBoard.Board[xDestination - 1, yDestination] = PLAYER_TAG;
            _tokens.OTokens.Add(destination);
            _tokens.XTokensDeleted.Add(CPU_TAG);
            if (yDestination == 0)
            {
                yDestination = 1;
            }
            if (gameBoard.Board[xDestination, yDestination - 1] == CPU_TAG)
            {
                string deletedToken = (Char)xDestination + 1 + ConvertNumberToLetter(yDestination - 1);
                _tokens.XTokens.Remove(deletedToken);
                Console.WriteLine("Pieza capturada: " + deletedToken);
                gameBoard.Board[xDestination, yDestination - 1] = " ";
            }
            else if (gameBoard.Board[xDestination, yDestination + 1] == CPU_TAG)
            {
                string deletedToken = (Char)xDestination + 1 + ConvertNumberToLetter(yDestination + 1);
                _tokens.XTokens.Remove(deletedToken);
                Console.WriteLine("Pieza capturada: " + deletedToken);
                gameBoard.Board[xDestination, yDestination + 1] = " ";
            }
            gameBoard.UpdateGameBoard(xPositionOfToken - 1, yPositionOfToken);
            isCpu = true;
            CheckWinner();
        }
        public void EatTokenCpu(GameBoard gameBoard)
        {
            canMove = true;
            Console.WriteLine("COMER");
            _tokens.XTokens.Remove(cpuToken);
            _tokens.XTokens.Add(cpuDestination);

            gameBoard.Board[xDestinationCpu - 1, yDestinationCpu] = CPU_TAG;
            _tokens.OTokensDeleted.Add(PLAYER_TAG);
            if (gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu - 1] == PLAYER_TAG)
            {
                string deletedToken = (Char)xPositionOfTokenCpu + 1 + ConvertNumberToLetter(yDestinationCpu - 1);
                Console.WriteLine("Has perdido la pieza: " + deletedToken);
                _tokens.OTokens.Remove(deletedToken);
                gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu - 1] = " ";
            }
            else if (gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu + 1] == PLAYER_TAG)
            {
                string deletedToken = (Char)xPositionOfTokenCpu + 1 + ConvertNumberToLetter(yDestinationCpu + 1);
                Console.WriteLine("Has perdido la pieza: " + deletedToken);
                _tokens.OTokens.Remove(deletedToken);
                gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu + 1] = " ";
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Jugada de la computadora");
            gameBoard.UpdateGameBoard(xPositionOfTokenCpu - 1, yPositionOfTokenCpu);
            isCpu = false;
            CheckWinner();
        }
        public void CheckWinner()
        {
            if (!canMove)
            {
                isWinner = true;
                Console.WriteLine("Jugador no puede mover mas piezas, se procederá a contar piezas.");
                if (_tokens.OTokens.Count > _tokens.XTokens.Count)
                {
                    Console.WriteLine("Has ganado la partida");
                    Console.WriteLine("Piezas Jugador: ", _tokens.OTokens.Count);
                    Console.WriteLine("Piezas Cpu: ", _tokens.XTokens.Count);
                }
                else if (_tokens.OTokens.Count == _tokens.XTokens.Count)
                {
                    Console.WriteLine("Empate");
                    Console.WriteLine("Piezas Jugador: ", _tokens.OTokens.Count);
                    Console.WriteLine("Piezas Cpu: ", _tokens.XTokens.Count);
                }
                else
                {
                    Console.WriteLine("Has perdido la partida");
                    Console.WriteLine("Piezas Jugador: ", _tokens.OTokens.Count);
                    Console.WriteLine("Piezas Cpu: ", _tokens.XTokens.Count);
                }
            }
            else if (_tokens.XTokens.Count == 0)
            {
                isWinner = true;
                Console.WriteLine("Has ganado la partida!");

            }
            else if (_tokens.OTokens.Count == 0)
            {
                isWinner = true;
                Console.WriteLine("Has perdido la partida");

            }
        }       
        public bool VerifyEatValidationsPlayer(GameBoard gameBoard)
        {
           
            if (yDestination < MAX_INDEX_TOKEN_LIST && yDestination >= MIN_INDEX_TOKEN_LIST && xPositionOfToken - xDestination == 2 && (yPositionOfToken - yDestination == 2 || yPositionOfToken - yDestination == -2)
                        && (gameBoard.Board[xDestination, yDestination + 1] == CPU_TAG || gameBoard.Board[xDestination, yDestination - 1] == CPU_TAG))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerifyEatValidationsCpu(GameBoard gameBoard)
        {
            if (xDestinationCpu < MAX_INDEX_TOKEN_LIST && yDestinationCpu < MAX_INDEX_TOKEN_LIST && yDestinationCpu > MIN_INDEX_TOKEN_LIST && xDestinationCpu > MIN_INDEX_TOKEN_LIST && xPositionOfTokenCpu - xDestinationCpu == -2 && (yPositionOfTokenCpu - yDestinationCpu == 2 || yPositionOfTokenCpu - yDestinationCpu == -2)
                && (gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu + 1] == PLAYER_TAG || gameBoard.Board[xPositionOfTokenCpu, yDestinationCpu - 1] == PLAYER_TAG) && (gameBoard.Board[xPositionOfTokenCpu + 1, yDestinationCpu] == " " || gameBoard.Board[xPositionOfTokenCpu + 1, yDestinationCpu + 1] == " "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerifyMovementValidationsPlayer(GameBoard gameBoard)
        {
            if (xPositionOfToken - xDestination == 1 && (yPositionOfToken - yDestination == 1 || yPositionOfToken - yDestination == -1)
                 && (gameBoard.Board[xDestination - 1, yDestination] == " "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerifyMovementValidationsCpu(GameBoard gameBoard)
        {
            if (xPositionOfTokenCpu - xDestinationCpu == -1 && (yPositionOfTokenCpu - yDestinationCpu == 1 || yPositionOfTokenCpu - yDestinationCpu == -1)
                && (gameBoard.Board[xDestinationCpu - 1, yDestinationCpu] == " "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PlayPlayer(GameBoard gameBoard)
        {
            try
            {
                if (VerifyEatValidationsPlayer(gameBoard))
                {
                    EatToken(gameBoard);
                }
                else if (VerifyMovementValidationsPlayer(gameBoard))
                {
                    MovePlayer(gameBoard);
                }
                else
                {
                    canMove = false;
                    throw new InvalidDestinationException();
                }
            }
            catch (InvalidDestinationException exception)
            {
                Console.WriteLine(exception.Advice);
            }
        }
        public void PlayCpu(GameBoard gameBoard)
        {
            if (VerifyEatValidationsCpu(gameBoard))
            {
                EatTokenCpu(gameBoard);
            }
            else if (VerifyMovementValidationsCpu(gameBoard))
            {
                MoveCpu(gameBoard);
            }
        }
    }
}
