﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
       
        public string Adress { get; set; }//optionnal

        //public override string ToString()
        //{ 
        // return this.ToStringProperty();
        //}

    }
}