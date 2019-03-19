using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Selecao
    {
        private int idSelecao;
        private string dsSelecao;
        private int idGrupoSelecao;
        private string dsImagemBandeira;
        private string dsTipoImagem;
        private string dsCaminhoImagemBandeira;

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

        public string DsSelecao
        {
            get
            {
                return dsSelecao;
            }

            set
            {
                dsSelecao = value;
            }
        }

        public int IdGrupoSelecao
        {
            get
            {
                return idGrupoSelecao;
            }

            set
            {
                idGrupoSelecao = value;
            }
        }

        public string DsImagemBandeira
        {
            get
            {
                return dsImagemBandeira;
            }

            set
            {
                dsImagemBandeira = value;
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

        public string DsCaminhoImagemBandeira
        {
            get
            {
                return dsCaminhoImagemBandeira;
            }

            set
            {
                dsCaminhoImagemBandeira = value;
            }
        }
    }
}
