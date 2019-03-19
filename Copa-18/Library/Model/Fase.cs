using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
   public class Fase
    {
        private int idFase;
        private string dsFase;

        public int IdFase
        {
            get
            {
                return idFase;
            }

            set
            {
                idFase = value;
            }
        }

        public string DsFase
        {
            get
            {
                return dsFase;
            }

            set
            {
                dsFase = value;
            }
        }
    }
}
