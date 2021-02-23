using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    public class Line
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
        
        public bool IsActive = true;
        public Areas Area { get; set; }
        public IEnumerable<LineStation> ListOfStations { get; set; }


        //public override string ToString()
        //{ 
        // return this.ToStringProperty();
        //}
    }
}
