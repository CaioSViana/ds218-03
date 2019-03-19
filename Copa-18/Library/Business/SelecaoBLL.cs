using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class SelecaoBLL
    {
        public List<Selecao> FindaAll()
        {
            SelecaoDAL selDAL = new SelecaoDAL();
            return selDAL.FindAll();
        }
    }
}
