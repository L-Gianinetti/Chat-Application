using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    class Administrateur : User
    {
        string _nomDiscussion;

        #region accesseurs
        public string NomDiscussion
        {
            get
            {
                return _nomDiscussion;
            }

            set
            {
                _nomDiscussion = value;
            }
        }
        #endregion

        public Administrateur(string nom, string prenom, string pseudo, string description, string nomDiscussion) : base(nom, prenom, pseudo, description)
        {
            _nomDiscussion = nomDiscussion;
        }
    }
}
