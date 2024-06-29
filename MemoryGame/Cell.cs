using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Cell<T>
    {
        public T Content 
        { 
            get; 
            private set; 
        }
        public bool IsRevealed 
        { 
            get; 
            set; 
        }
        public int Row
        {
            get; private set;
        }
        public int Column
        {
            get; private set;
        }

        public Cell(T content, int column, int row)
        {
            Row = row;
            Column = column;
            Content = content;
            IsRevealed = false;
        }

        public override string ToString()
        {

            return IsRevealed ? Content.ToString() : " ";
        }
    }
}
