using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Desk desk = new Desk(4);
            desk.PlayGame();
            Console.WriteLine(desk);
        }
    }
}
