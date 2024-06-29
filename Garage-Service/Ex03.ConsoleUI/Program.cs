using Ex03.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GarageManager manager = new GarageManager();
            manager.Manage();
        }
    }
}
