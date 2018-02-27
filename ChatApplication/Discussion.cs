using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    public class Discussion
    {
        private string _nom;

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
        #endregion

        public Discussion(string nom)
        {
            _nom = nom;
        }
    }
}
