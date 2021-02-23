using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using BO;

namespace PO
{
    class LineTime
    { 
            public int Id { get; set; }
            public int Code { get; set; }
            public string LastStation { get; set; }
            public TimeSpan TripStart { get; set; }
            public TimeSpan Timing { get; set; }
    }

        public class P
        {

        IBL bl;
            internal IEnumerable<IGrouping<TimeSpan, LineTime>> BoPoLineTimingAdapter
                (IEnumerable<IGrouping<TimeSpan, BO.LineTime>> listTiming, TimeSpan hour)
            {
                List<LineTime> timing = new List<LineTime>();
                foreach (var element in listTiming)
                {
                    foreach (var item in element)
                    {
                        BO.Line line = bl.GetLine(item.Id);
                        timing.Add(new LineTime
                        {
                            Id = item.Id,
                            Code = line.Code,
                            LastStation = bl.GetStation(line.LastStation).Name,
                            TripStart = item.TripStart,
                            Timing = item.ExpectedTimeTillArrive - hour
                        });
                    }
                }

                return from item in timing
                       group item by item.Timing;
            }
        }
    
}
