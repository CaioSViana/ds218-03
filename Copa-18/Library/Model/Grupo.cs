using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Grupo
    {
        private int idGrupo;
        private char dsGrupo;

        public int IdGrupo
        {
            get
            {
                return idGrupo;
            }

            set
            {
                idGrupo = value;
            }
        }

        public char DsGrupo
        {
            get
            {
                return dsGrupo;
            }

            set
            {
                dsGrupo = value;
            }
        }
    }
}
