using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class FaseBLL
    {
        public List<Fase> FindaAll()
        {
            FaseDAL fDAL = new FaseDAL();
            return fDAL.FindAll();
        }
    }
}
