using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserMines
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau p = new Plateau();
            p.AjouterJeton(2, 3, Type.joueur1);
            p.AjouterJeton(0, 0, Type.bloc);
            p.AjouterJeton(2, 5, Type.joueur2);
            p.AjouterJeton(8, 3, Type.neutre);


            Console.WriteLine(p.ToString());

            Console.Read();
        }
    }
}
