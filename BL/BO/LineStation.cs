using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation
    {
        public int Code { get; set; }
        public string Name { get; set; }      
        public int NextStation { get; set; }
        public TimeSpan TimetoNext {get;set;}
        public double DistancetoNext { get; set; }


    }
}
