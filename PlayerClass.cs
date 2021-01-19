using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Part_3
{
    class Playerclass
    {
        private int position;
        private string name;
        private int score;
        private int compteur; /* count the number of double dice */
        public bool isJail = false;
        private int compteurprison; /* count the number of turns spent in prison  */


        public Playerclass()
        {
        }

        public Playerclass(string Name)
        {
            this.name = Name;
        }

        public int Position
        {
            get { return position; }
            set { this.position = value; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Score
        {
            get { return score; }
            set { this.score = value; }
        }

        public int Compteur
        {
            get { return compteur; }
            set { this.compteur = value; }
        }

        public int CompteurPrison
        {
            get { return compteurprison; }
            set { this.compteurprison = value; }
        }

    }
}

