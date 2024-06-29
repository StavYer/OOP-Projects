using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class GameLogic<T>
    {
        private Board<T> m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private bool m_Quit = false;

        public GameLogic()
        {
            start();
        }

        private void start()
        {
            string playerName1 = GameUI<T>.GetPlayerName("1");
            m_Player1 = new Player(playerName1);
            bool againstComputer = GameUI<T>.GetComputerPlayer();

            if (againstComputer)
            {
                m_Player2 = new Player("Computer", true);
            }

            else
            {
                string playerName2 = GameUI<T>.GetPlayerName("2");
                m_Player2 = new Player(playerName2);
            }

            (int rows, int columns) = GameUI<T>.GetRowsAndColumns();
            m_Board = new Board<T>(rows, columns);

            m_Board.InitializeBoard();

            playGame();
        }

        private void playGame()
        {
            Player currentPlayer = m_Player1;

            while (!m_Board.IsGameOver())
            {
                displayInfo(currentPlayer.Name);
                
                Cell<T> firstCell = currentPlayer.IsComputer ? computerPlay() : GameUI<T>.GetPlayerCellChoice(m_Board);

                if (firstCell == null)
                {
                    m_Quit = true;
                    break;
                }

                displayInfo(currentPlayer.Name);

                Cell<T> secondCell = currentPlayer.IsComputer ? computerPlay() : GameUI<T>.GetPlayerCellChoice(m_Board);

                if (secondCell == null)
                {
                    m_Quit = true;
                    break;
                }

                displayInfo(currentPlayer.Name);

                if (firstCell.Content.Equals(secondCell.Content))
                {
                    currentPlayer.Score++;
                }

                else
                {
                    currentPlayer = currentPlayer == m_Player1 ? m_Player2 : m_Player1;

                    System.Threading.Thread.Sleep(2000);
                    m_Board.HideCell(firstCell);
                    m_Board.HideCell(secondCell);
                }
            }

            if (!m_Quit)
            {
                displayInfo(currentPlayer.Name);
                bool proceed = GameUI<T>.DisplayWinner(m_Player1.Name, m_Player2.Name, m_Player1.Score, m_Player2.Score);

                if (proceed)
                {
                    start();
                }
            }
        }

        private void displayInfo(string io_CurrentPlayerName)
        {
            GameUI<T>.ClearScreen();
            GameUI<T>.DisplayGameBoard(m_Board, m_Player1, m_Player2);
            GameUI<T>.DisplayCurrentPlayerTurn(io_CurrentPlayerName);
        }

        private Cell<T> computerPlay()
        {     
            Cell<T> cell = m_Board.GetRandomUnflippedTile();

            m_Board.RevealCell(cell);
            System.Threading.Thread.Sleep(2000);

            return cell;
        }  
    }
}
