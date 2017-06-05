using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaserMines
{
    class Joueur
    {
        // ATTRIBUTS
        private uint jetonsBlancsRestants = Parametres.JETONS_BLANCS;
        private uint jetonsNoirsRestants = Parametres.JETONS_NOIRS;
        private Type typeJoueur; // pas sécurisé car un joueur peut alors être de type bloc, neutre ou vide !!

        // CONSTRUCTEUR
        public Joueur(Type t)
        {
            typeJoueur = t;
        }

        // METHODES
        public Type choisirJeton()
        {
            int jeton = 1;
            if (jetonsBlancsRestants != 0 || jetonsNoirsRestants != 0)
            {
                Console.WriteLine("Type de jeton");
                Console.WriteLine("1. couleur");
                Console.WriteLine("2. blanc : " + jetonsBlancsRestants);
                Console.WriteLine("3. noir : " + jetonsNoirsRestants);

                bool continuer = false;
                do
                {
                    int.TryParse(Console.ReadLine(), out jeton); // lecture
                    // vérification
                    if(jeton == 1 || jeton == 2 && jetonsBlancsRestants != 0 || jeton == 3 && jetonsNoirsRestants != 0)
                    {
                        continuer = true;
                    }
                    else
                    {
                        continuer = false;
                    }
                } while (continuer);
            }
            switch (jeton)
            {
                case 1:
                    return typeJoueur;
                case 2:
                    jetonsBlancsRestants--;
                    return Type.neutre;
                case 3:
                    jetonsNoirsRestants--;
                    return Type.bloc;
            }
            return typeJoueur; // retourne le type du joueur par défaut
        }

        public Pair<uint, uint> choisirCoordonnees()
        {
            Pair<uint, uint> coord = new Pair<uint, uint>(0, 0);
            uint x, y;
            Console.Write("x : ");
            uint.TryParse(Console.ReadLine(), out x);
            coord.first = x;
            Console.Write("y : ");
            uint.TryParse(Console.ReadLine(), out y);
            coord.second = y;

            return coord;
        } 
    }
}
