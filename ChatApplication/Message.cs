using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    public class Message
    {
        private string _contenu;

        #region accesseurs
        public string Contenu
        {
            get
            {
                return _contenu;
            }

            set
            {
                _contenu = value;
            }
        }
        #endregion

        public Message(string contenu)
        {
            _contenu = contenu;
        }
    }
}
