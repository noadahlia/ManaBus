using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public class DalFactory
    {
        static readonly IDAL instance = new DalObject();
        static public IDAL GetDAL()
        {
            return instance;
        }

    }
}
