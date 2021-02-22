using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation
    {
        //public int LineId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        //je peux enlver prev et index
        //public int LineStationIndex { get; set; }
        //public int PrevStation { get; set; }
        public int NextStation { get; set; }
        // zman et distance tonext
        public TimeSpan TimetoNext {get;set;}
        public double DistancetoNext { get; set; }

        //public override string ToString() => this.ToStringProperty();

    }
}
