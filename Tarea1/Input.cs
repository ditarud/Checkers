using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Tarea1.Utility;
using System.Text.RegularExpressions;

namespace Tarea1
{
    public class Input
    {
        Random rand = new Random();      
       
        public void SelectTokenPlayer(GameBoard gameBoard,Game game)
        {
            Console.Write("\n");
            Console.Write("Escriba la posición de la ficha que desea mover: ");
            game.SelectToken = Console.ReadLine();
            try
            {
                if (game.Tokens.OTokens.Contains(game.SelectToken))
                {
                    string[] numbers = Regex.Split(game.SelectToken, @"\D+");
                    foreach (string value in numbers)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            game.XPositionOfToken = int.Parse(value);
                            
                        }
                    }
                    //xPositionOfToken = (int)Char.GetNumericValue(selectToken[0]);
                    if (game.SelectToken.Length == 2)
                    {
                        game.YPositionOfToken = ConvertLetterToNumber(game.SelectToken[1]);
                    }
                    else
                    {
                        game.YPositionOfToken = ConvertLetterToNumber(game.SelectToken[2]);
                    }
                    
                    Console.Write("Pieza seleccionada correctamente, donde desea moverla? ");
                    game.Destination = Console.ReadLine();

                    DestinationTokenPlayer(gameBoard, game);                   
                }
                else
                {
                    throw new InvalidPositionException();                    
                }
            }
            catch (InvalidPositionException exception)
            {
                Console.WriteLine(exception.Advice);             
            }              
        }
        public void DestinationTokenPlayer(GameBoard gameBoard, Game game)
        {
            try
            {
                if (game.Tokens.Positions.Contains(game.Destination))
                {
                    
                        string[] numbers = Regex.Split(game.Destination, @"\D+");
                        foreach (string value in numbers)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                game.XDestination = int.Parse(value);

                            }
                        }
                        //xDestination = (int)Char.GetNumericValue(destination[0]);
                        if (game.Destination.Length == 2)
                        {
                            game.YDestination = ConvertLetterToNumber(game.Destination[1]);
                        }
                        else
                        {
                            game.YDestination = ConvertLetterToNumber(game.Destination[2]);
                        }
                        //yDestination = ConvertLetterToNumber(destination[1]);
                        game.PlayPlayer(gameBoard);
                    
                }
                else
                {
                    throw new InvalidDestinationException();
                }
            }
            catch (InvalidDestinationException exception)
            {
                Console.WriteLine(exception.Advice);
            }
        }
        public void CpuInput(GameBoard gameBoard, Game game)
        {
            int tokenRandom = rand.Next(0,game.Tokens.XTokens.Count);
            int destinationRandom = rand.Next(0, game.Tokens.Positions.Count);

            if (game.Tokens.XTokens.Count == 0)
            {
                game.CanMove = false;
                game.CheckWinner();
            }
            else
            {
                game.CpuToken = game.Tokens.XTokens[tokenRandom];
            }
           
            game.XPositionOfTokenCpu = (int)Char.GetNumericValue(game.CpuToken[0]);
            game.YPositionOfTokenCpu = ConvertLetterToNumber(game.CpuToken[1]);                  

            game.CpuDestination = game.Tokens.Positions[destinationRandom];

            game.XDestinationCpu = (int)Char.GetNumericValue(game.CpuDestination[0]);
            game.YDestinationCpu = ConvertLetterToNumber(game.CpuDestination[1]);
            game.CanMove = false;

            game.PlayCpu(gameBoard);            
        }          
        

        
    }
}
