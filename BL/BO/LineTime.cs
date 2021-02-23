using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineTime
    {

        private static int counter = 0;

        public int Id{ get; set; } 

        public LineTime() => Id = ++counter; 

        public TimeSpan TripStart { get; set; } 

        public int code { get; set; } 

        public TimeSpan ExpectedTimeTillArrive { get; set; }

        //public override string ToString()
        //{
        //    return this.ToStringProperty();
        //}
    }
}
