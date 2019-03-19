using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class EstadioBLL
    {
        public List<Estadio> FindaAll()
        {
            EstadioDAL eDAL = new EstadioDAL();
            return eDAL.FindAll();
        }
    }
}
