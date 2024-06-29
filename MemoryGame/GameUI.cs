using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal static class GameUI<T>
    {
        public static string GetPlayerName(string i_PlayerNumber)
        {
            Console.WriteLine(String.Format("Enter player {0}'s name (no spaces, max 20 chars): ", i_PlayerNumber));
            string playerName = Console.ReadLine();

            return playerName;
        }

        public static bool GetComputerPlayer()
        {
            string response = "";
            Console.WriteLine("Do you want to play against a computer (Y/N)? ");
            while (true)
            {
                response = Console.ReadLine();   
                
                if (response == "Y" || response == "N") {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter Y or N:");
            }

            return response == "Y";
        }

        public static (int, int) GetRowsAndColumns()
        {
            int rows, columns;

            do
            {
                Console.WriteLine("Enter the board size (minimum 4x4, maximum 6x6, even number of cells): ");
                Console.Write("Rows: ");
                rows = int.Parse(Console.ReadLine());
                Console.Write("Columns: ");
                columns = int.Parse(Console.ReadLine());
                if ((rows * columns) % 2 != 0)
                {
                    Console.WriteLine("Please enter rows and columns that result in an even number of cells.");
                }

                else if (rows < 4 || columns < 4 || rows > 6 || columns > 6)
                {
                    Console.WriteLine("Please enter row or column size in requested range.");
                }

            } while ((rows * columns) % 2 != 0 || rows < 4 || columns < 4 || rows > 6 || columns > 6);

            return (rows, columns);
        }

        public static void DisplayCurrentPlayerTurn(string io_CurrentPlayer)
        {
            Console.WriteLine(String.Format("{0}'s turn: ", io_CurrentPlayer));
        }

        public static void ClearScreen()
        {
            Screen.Clear();
        }

        public static void DisplayGameBoard(Board<T> io_Board, Player io_Player1, Player io_Player2)
        {
            Console.WriteLine("    " + string.Join("   ", getColumnHeaders(io_Board)));
            Console.WriteLine("  " + new string('=', io_Board.Columns * 4) + '=');
            for (int row = 0; row < io_Board.Rows; row++)
            {
                Console.Write((row + 1) + " ");
                for (int col = 0; col < io_Board.Columns; col++)
                {
                    T content = io_Board.GetCellContent(row, col);
                    bool isRevealed = io_Board.IsCellRevealed(row, col);

                    Console.Write("| " + (isRevealed ? content.ToString() : " ") + " ");
                }

                Console.WriteLine("|");
                Console.WriteLine("  " + new string('=', io_Board.Columns * 4) + '=');
            }

            Console.WriteLine(String.Format("{0}'s score: {1}, {2}'s score: {3}", io_Player1.Name, io_Player1.Score, io_Player2.Name, io_Player2.Score));
        }

        private static string[] getColumnHeaders( Board<T> io_Board) 
        {
            string[] headers = new string[io_Board.Columns];

            for (int i = 0; i < io_Board.Columns; i++)
            {
                headers[i] = ((char)('A' + i)).ToString();
            }

            return headers;
        }

        public static Cell<T> GetPlayerCellChoice(Board<T> io_Board)
        {
            Cell<T> requestedCell = null;
            
            while(true) 
            {
                Console.WriteLine("Enter the cell (e.g., A1): ");
                String input = Console.ReadLine();

                if (input == "Q")
                {
                    requestedCell = null;
                    break;
                }

                else if (input.Length != 2)
                {
                    Console.WriteLine("Invalid Input! Please enter an input of the form 'Column''Row' in valid range.");
                    continue;
                }
                
                int column = input[0] - 'A';
                int row = input[1] - '1';

                requestedCell = io_Board.GetSpecificCell(row, column);

                if (requestedCell == null)
                {
                     Console.WriteLine("Invalid Input! Please enter an input of the form 'Column''Row' in valid range.");
                }

                else if (requestedCell.IsRevealed)
                {
                    Console.WriteLine("Please select an un-flipped cell.");
                }

                else
                {
                    io_Board.RevealCell(requestedCell);
                    break;                 
                }              
            }

            return requestedCell;
        }

        public static bool DisplayWinner(string io_Player1Name, string io_Player2Name, int io_Player1Score, int io_Player2Score) 
        {
            Console.WriteLine("Game Over!");
            if (io_Player1Score > io_Player2Score)
            {
                Console.WriteLine(String.Format("{0} wins with {1} points!", io_Player1Name, io_Player1Score));
            }

            else if (io_Player2Score > io_Player1Score)
            {
                Console.WriteLine(String.Format("{0} wins with {1} points!", io_Player2Name, io_Player2Score));
            }

            else
            {
                Console.WriteLine("It's a tie!");
            }

            Console.WriteLine("Do you want to play another round (Y/N)? ");
            string response = Console.ReadLine();

            return response.ToUpper() == "Y";
        }
    }
}
