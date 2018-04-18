using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    public class User
    {
        protected string _nom;
        protected string _prenom;
        protected string _pseudo;
        protected string _description;
        protected string _motDePasse;
        

        #region accesseurs

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }

            set
            {
                _pseudo = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }

            set
            {
                _motDePasse = value;
            }
        }



        #endregion

        public User(string nom, string prenom, string pseudo, string description)
        {
            _nom = nom;
            _prenom = prenom;
            _pseudo = pseudo;
            _description = description;
        }
        public User(string pseudo)
        {
            _pseudo = pseudo;
        }
        public User()
        {

        }


    }
}
