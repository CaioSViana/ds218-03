using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class JogadorBLL
    {
        public bool Insert(Jogador j)
        {
            bool salvou = false;
            new JogadorDAL().Insert(j);

            //Se o ID for maior que zero, indica que o dado foi salvo
            if (j.IdJogador > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Jogador> FindaAll()
        {
            JogadorDAL jDAL = new JogadorDAL();
            return jDAL.FindAll();
        }

        public Jogador FindaById(int idJogador)
        {
            JogadorDAL jDAL = new JogadorDAL();
            return jDAL.FindById(idJogador);
        }

        public List<Jogador> FindBySelecao(int idSelecao)
        {
            JogadorDAL jDAL = new JogadorDAL();
            return jDAL.FindBySelecao(idSelecao);
        }

        public List<Jogador> FindByPosicao(int idPosicao)
        {
            JogadorDAL jDAL = new JogadorDAL();
            return jDAL.FindByPosicao(idPosicao);
        }
    }
}
