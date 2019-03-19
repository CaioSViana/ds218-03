using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Posicao
    {
        private int idPosicao;
        private string dsPosicao;

        public int IdPosicao
        {
            get
            {
                return idPosicao;
            }

            set
            {
                idPosicao = value;
            }
        }

        public string DsPosicao
        {
            get
            {
                return dsPosicao;
            }

            set
            {
                dsPosicao = value;
            }
        }
    }
}
