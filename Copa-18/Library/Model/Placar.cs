using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Placar
    {
        private bool blMandante;
        private int nrGolPenaltis;
        private int idPlacar;
        private int idPartida;
        private int idSelecao;
        private int nrGol;
        private int nrGolProrrogacao;

        public int IdPlacar
        {
            get
            {
                return idPlacar;
            }

            set
            {
                idPlacar = value;
            }
        }

        public int IdPartida
        {
            get
            {
                return idPartida;
            }

            set
            {
                idPartida = value;
            }
        }

        public int IdSelecao
        {
            get
            {
                return idSelecao;
            }

            set
            {
                idSelecao = value;
            }
        }

        public int NrGol
        {
            get
            {
                return nrGol;
            }

            set
            {
                nrGol = value;
            }
        }

        public int NrGolProrrogacao
        {
            get
            {
                return nrGolProrrogacao;
            }

            set
            {
                nrGolProrrogacao = value;
            }
        }

        public bool BlMandante { get => blMandante; set => blMandante = value; }
        public int NrGolPenaltis { get => nrGolPenaltis; set => nrGolPenaltis = value; }
    }
}
