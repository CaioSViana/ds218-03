using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class GrupoBLL
    {
        public List<Grupo> FindaAll()
        {
            GrupoDAL gDAL = new GrupoDAL();
            return gDAL.FindAll();
        }
    }
}
