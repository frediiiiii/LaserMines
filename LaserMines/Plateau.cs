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

            if (grille[x, y] != null)
            {
                //Transformer();
                return 0;
            }
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
            if (c.first < largeur && c.second < hauteur)
            {
                return (grille[c.first, c.second].getType() == Type.vide);
            }
            else
            {
                return false;
            }
        }

        public List<Pair<uint, uint>> CalculerTransformations(Pair<uint, uint> coord, Type t)
        {
            var restantes = new List<Pair<uint, uint>>();
            var sortie = new List<Pair<uint, uint>>();
            restantes.Add(coord);

            int[] directions = new int[3] { -1, 0, 1 };

            //on a rien aux coordonnees specifiees
            if (grille[coord.first, coord.second].type == Type.vide)
                return sortie;

            while (restantes.Count != 0)
            {
                foreach (Pair<uint, uint> actuel in restantes)
                {
                    //test dans toutes les directions
                    foreach (int i in directions)
                    {
                        foreach (int j in directions)
                        {
                            if (i == 0 && j == 0) continue; //jeton actuel

                            Type voisin1 = TypeVoisin(actuel, i, j);    //voisin le plus proche
                            Type voisin2 = TypeVoisin(actuel, 2 * i, 2 * j);    //voisin le plus proche +1
                            Type voisin3 = TypeVoisin(actuel, 3 * i, 3 * j);    //voisin le plus proche +2

                            if ((voisin1 != Type.vide
                                && (voisin1 != t && voisin1 != Type.bloc && voisin1 != Type.neutre))    //voisin1 de type "autre joueur"
                            && (voisin2 != Type.vide
                                && (voisin2 != t && voisin2 != Type.bloc && voisin2 != Type.neutre))    //voisin2 de type "autre joueur"
                            && (voisin3 != Type.vide
                                && (voisin3 == t || voisin3 == Type.neutre)))                                //voisin3 de type "meme joueur" ou neutre
                            {
                                //ajout des coordonnees des jetons a tester puis transformer
                            }
                        }
                    }

                    sortie.Add(actuel);
                }

            }
        }

        private Type TypeVoisin(Pair<uint, uint> j, int directionX, int directionY)
        {
            return grille[j.first + directionX, j.second + directionY].type;
        }
    }
}
