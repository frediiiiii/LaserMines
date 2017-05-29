using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserMines
{
    public enum Type
    {
        joueur1,    //bleu
        joueur2,    //rouge
        neutre,     //blanc
        bloc,       //noir
    }

    class Plateau
    {
        public const uint largeur = 15;
        public const uint hauteur = 15;

        private Jeton[,] grille { get; set; } = new Jeton[largeur, hauteur];

        public int AjouterJeton(uint x, uint y, Type t)
        {
            if(x > largeur - 1 || y > hauteur -1)
            {
                Console.WriteLine("AjouterJeton : mauvaises coordonnées.");
                return -1;
            }

            grille[x, y] = new Jeton(t);

            if(grille[x, y] != null)
                return 0;
            else
            {
                Console.WriteLine("AjouterJeton : échec de l'ajout.");
                return -2;
            }
        }

        override public String ToString()
        {
            String res = "";

            for(int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < largeur; j++)
                {
                    Jeton jeton = grille[j, i];

                    if (jeton != null)
                    {
                        res += jeton.ToString();
                    }
                    else
                        res += ".";
                }

                res += "\n";              
            }

            return res;
        }
    }
}
