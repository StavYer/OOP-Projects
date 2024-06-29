using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Player
    {
        public string Name {
            get;
            private set;
        }
        public int Score { 
            get;
            set;
        }
        public bool IsComputer 
        { 
            get;
            private set;
        }

        public Player(string io_Name, bool io_IsComputer = false)
        {
            Name = io_Name;
            Score = 0;
            IsComputer = io_IsComputer;
        }
    }
}
