using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Board<T>
    {
        private Cell<T>[,] cells;
       
        public int Rows
        {
            get;
            private set;
        }

        public int Columns
        {
            get;
            private set;
        }

        private Random m_Random;

        private T[] contentArray;

        private List<Cell<T>> unflippedTiles;  

        public Board(int io_Rows, int io_Columns)
        {
            Rows = io_Rows;
            Columns = io_Columns;
            cells = new Cell<T>[io_Rows, io_Columns];
            unflippedTiles = new List<Cell<T>>();
            m_Random = new Random();
        }

        public void InitializeBoard()
        {
            
            char startLetter = 'A';
            contentArray = new T[Rows * Columns / 2];

            for (int i = 0; i < contentArray.Length; i++)
            {
                contentArray[i] = (T)(object)startLetter;
                startLetter++;
            }

            for (int i = 0; i < Rows * Columns / 2; i++)
            {
                PlaceRandomly(contentArray[i]);
                PlaceRandomly(contentArray[i]);
            }
        }

        private void PlaceRandomly(T io_Content)
        {
            int row, column;

            do
            {
                row = m_Random.Next(Rows);
                column = m_Random.Next(Columns);
            } while (cells[row, column] != null);

            cells[row, column] = new Cell<T>(io_Content, column, row);

            unflippedTiles.Add(cells[row, column]);  
        }

        public Cell<T> GetRandomUnflippedTile()
        {           
            int randomUnflippedIndex = m_Random.Next(unflippedTiles.Count);
            Cell<T> unflippedTile = unflippedTiles[randomUnflippedIndex];

            return unflippedTile;
        }
       

        public T GetCellContent(int io_Row, int io_Column)
        {
            
            return cells[io_Row, io_Column].Content;
        }

        public bool IsCellRevealed(int io_Row, int io_Column)
        {

            return cells[io_Row, io_Column].IsRevealed;
        }

        public void RevealCell(Cell<T> io_Cell)
        {
            io_Cell.IsRevealed = true;
            unflippedTiles.Remove(io_Cell); 
        }

        public void HideCell(Cell<T> io_Cell)
        {
            io_Cell.IsRevealed = false;
            unflippedTiles.Add(io_Cell);
        }

        public Cell<T> GetSpecificCell(int io_Row, int io_Column)
        {
            Cell<T> resultCell = null;

            if ((io_Row >= 0 && io_Row < Rows) && (io_Column >= 0 && io_Column < Columns))
            {
                resultCell = cells[io_Row, io_Column];
            }

            return resultCell;
        }

        public bool IsGameOver()
        {
            bool gameOver = true;
            foreach (var cell in cells)
            {
                if (!cell.IsRevealed)
                {
                    gameOver = false;
                    break;
                }
            }

            return gameOver;
        }
    }
}
