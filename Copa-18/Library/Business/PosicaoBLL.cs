using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class PosicaoBLL
    {
        public List<Posicao> FindaAll()
        {
            PosicaoDAL pDAL = new PosicaoDAL();
            return pDAL.FindAll();
        }        
    }
}
