using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    class Playerclass
    {
        private int position;
        private string name;
        private int score;
        private int compteur;
        public bool isJail = false;
        private int compteurprison;


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
