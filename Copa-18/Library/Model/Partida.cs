using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Partida
    {
        private int idPartida;
        private string dsPartida;
        private DateTime dtPartida;
        private int idFase;
        private int idEstadio;
        private List<Placar> listaPlacar;

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

        public DateTime DtPartida
        {
            get
            {
                return dtPartida;
            }

            set
            {
                dtPartida = value;
            }
        }

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

        public List<Placar> ListaPlacar { get => listaPlacar; set => listaPlacar = value; }
        public string DsPartida { get => dsPartida; set => dsPartida = value; }
    }
}
