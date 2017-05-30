using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserMines
{
    public enum Type
    {
        joueur1,    // bleu
        joueur2,    // rouge
        neutre,     // blanc
        bloc,       // noir
        vide,       // rien
    }

    class Plateau
    {
        // ATTRIBUTS
        public const uint largeur = Parametres.LARGEUR_GRILLE;
        public const uint hauteur = Parametres.HAUTEUR_GRILLE;
        private Jeton[,] grille { get; set; } = new Jeton[largeur, hauteur];

        // CONSTRUCTEUR
        public Plateau()
        {
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    grille[i, j] = new Jeton(Type.vide);
                }
            }
        }

        // METHODES
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

        public void clear()
        {
            for (int i = 0; i < largeur; i++)
            {
                for(int j = 0; j < hauteur; j++)
                {
                    grille[i, j].setType(Type.vide); 
                }
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
                    res += " ";
                }

                res += "\n";              
            }

            return res;
        }
        
        public List<Tuple<uint, uint>> Transformer(Tuple<uint, uint> coord, Type type)
        {
            List<Tuple<uint, uint>> listeFake = new List<Tuple<uint, uint>>();
            return listeFake;   
        }

        public bool continuerAJouer()
        {
            bool b;
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    if (grille[i, j].getType() == Type.vide)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool caseLibre(Pair<uint, uint> c)
        {
            if (c.First < largeur && c.Second < hauteur)
            {
                return (grille[c.First, c.Second].getType() == Type.vide);
            }
            else
            {
                return false;
            }
        }
    }
}
