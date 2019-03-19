using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Jogador
    {
        private int idJogador;
        private string dsNome;
        private int nrCamisa;
        private int idPosicaoJogador;
        private int idSelecaoJogador;
        private byte[] dsImagemJogador;
        private string dsTipoImagem;
        private string dsCaminhoImagemJogador;

        public int IdJogador
        {
            get
            {
                return idJogador;
            }

            set
            {
                idJogador = value;
            }
        }

        public string DsNome
        {
            get
            {
                return dsNome;
            }

            set
            {
                dsNome = value;
            }
        }

        public int NrCamisa
        {
            get
            {
                return nrCamisa;
            }

            set
            {
                nrCamisa = value;
            }
        }

        public int IdPosicaoJogador
        {
            get
            {
                return idPosicaoJogador;
            }

            set
            {
                idPosicaoJogador = value;
            }
        }

        public int IdSelecaoJogador
        {
            get
            {
                return idSelecaoJogador;
            }

            set
            {
                idSelecaoJogador = value;
            }
        }

        public byte[] DsImagemJogador
        {
            get
            {
                return dsImagemJogador;
            }

            set
            {
                dsImagemJogador = value;
            }
        }

        public string DsTipoImagem
        {
            get
            {
                return dsTipoImagem;
            }

            set
            {
                dsTipoImagem = value;
            }
        }

        public string DsCaminhoImagemJogador
        {
            get
            {
                return dsCaminhoImagemJogador;
            }

            set
            {
                dsCaminhoImagemJogador = value;
            }
        }
    }
}
