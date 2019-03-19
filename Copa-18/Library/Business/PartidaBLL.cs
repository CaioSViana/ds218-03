using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class PartidaBLL
    {
        public bool Insert(Partida p)
        {
            bool salvou = false;
            new PartidaDAL().Insert(p);

            //Se o ID for maior que zero, indica que o dado foi salvo
            if (p.IdPartida > 0)
            {
                //Iterando a lista de placar dentro do objeto do tipo Partida
                foreach (Placar pl in p.ListaPlacar)
                {
                    pl.IdPartida = p.IdPartida;
                    new PlacarDAL().Insert(pl);
                }
                salvou = true;
            }
            return salvou;
        }

        public DataTable FindPartidas()
        {
            PartidaDAL pDAL = new PartidaDAL();
            return pDAL.FindPartidas();
        }
    }
}
