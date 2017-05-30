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
            menuPrincipal();
        }

        static void menuPrincipal()
        {
            Plateau p = new Plateau();
            Joueur[] tabJoueurs = new Joueur[2];
            tabJoueurs[0] = new Joueur(Type.joueur1);
            tabJoueurs[1] = new Joueur(Type.joueur2);
            uint choix;

            do
            {
                // affichage menu
                Console.WriteLine("1. Nouvelle partie");
                Console.WriteLine("2. Quitter");

                // choix
                do
                {
                    uint.TryParse(Console.ReadLine(), out choix);
                } while (choix != 1 && choix != 2);

                // lancement partie
                if (choix == 1)
                {
                    lancerPartie(p, tabJoueurs);
                }
            } while (choix != 2); // quitter
        }

        static void lancerPartie(Plateau plateau, Joueur[] tabJoueurs)
        {
            Joueur joueurActif = tabJoueurs[0];
            Type typeJeton;
            Pair<uint, uint> coordonnees;
            plateau.clear();

            // 1 - JEUX
            while (plateau.continuerAJouer())
            {
                typeJeton = joueurActif.choisirJeton(); // lecture type de jeton
                do
                {
                    coordonnees = joueurActif.choisirCoordonnees(); // lecture coordonnées
                } while (!plateau.caseLibre(coordonnees)); // recommencer tant qu'on a pas choisi une case libre  
                plateau.AjouterJeton(coordonnees.First, coordonnees.Second, typeJeton); // placement jeton
            }

            // 2 - COMPTABILISATION DES SCORES

            // 3 - AFFICHAGE SCORES
        }
    }
}
