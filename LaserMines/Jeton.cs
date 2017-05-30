using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserMines
{
    class Jeton
    {        
        public Type type = Type.joueur1;

        // CONSTRUCTEURS
        public Jeton(Type t) { type = t; }

        // METHODES
        override public String ToString()
        {
            String res = "";

            switch (type)
            {
                case Type.bloc:
                    res += "#";
                    break;
                case Type.joueur1:
                    res += "X";
                    break;
                case Type.joueur2:
                    res += "O";
                    break;
                case Type.neutre:
                    res += "*";
                    break;
                default:
                    res += ".";
                    break;
            }

            return res;
        }
        public Type getType() { return type; }
        public void setType(Type t) { type = t; }
    }
}
