using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Estadio
    {
        private int idEstadio;

        private string dsEstadio;

        private string dsCidade;

        private int nrCapacidade;

        private string dsImagemEstadio;

        private string dsCaminhoImagemEstadio;

        public int IdEstadio
        {
            get
            {
                return idEstadio;
            }

            set
            {
                idEstadio = value;
            }
        }

        public string DsEstadio
        {
            get
            {
                return dsEstadio;
            }

            set
            {
                dsEstadio = value;
            }
        }

        public string DsCidade
        {
            get
            {
                return dsCidade;
            }

            set
            {
                dsCidade = value;
            }
        }

        public int NrCapacidade
        {
            get
            {
                return nrCapacidade;
            }

            set
            {
                nrCapacidade = value;
            }
        }

        public string DsImagemEstadio
        {
            get
            {
                return dsImagemEstadio;
            }

            set
            {
                dsImagemEstadio = value;
            }
        }

        public string DsCaminhoImagemEstadio
        {
            get
            {
                return dsCaminhoImagemEstadio;
            }

            set
            {
                dsCaminhoImagemEstadio = value;
            }
        }
    }
}
