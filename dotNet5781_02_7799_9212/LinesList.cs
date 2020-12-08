using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_7799_9212
{
    public class LinesList : IEnumerable
    {
        private List<BusLine> lines { get; set; }

        public LinesList()
        {
            lines = new List<BusLine>();
        }

        public bool Exists(BusLine l)
        {
            foreach (BusLine item in lines)
            {
                if (item.BUSLINE == l.BUSLINE && item.FIRST == l.FIRST && item.LAST == l.LAST)
                    return true;
            }
            return false;
        }




        public void AddLine(BusLine l)
        {
            if (!lines.Any())
            {
                lines.Add(l);
            }
            else if (Exists(l))
            {
                throw new ArgumentOutOfRangeException("This bus line already exists.");
            }
            else
            {
                lines.Add(l);
            }
        }

        public void DeleteLine(BusLine l)
        {
            if (Exists(l))
                throw new ArgumentOutOfRangeException("This bus line doesn't exist.");
            else
                lines.Remove(l);
        }

        public List<BusLine> StopsHere(int key)
        {
            List<BusLine> lst = new List<BusLine>();
            foreach (BusLine item in lines)
            {
                if (item.SearchByKey(key))
                {
                    lst.Add(item);
                }
            }
            if (lst.Any())
                throw new ArgumentOutOfRangeException("Any bus stops here.");

            return lst;
        }

        public List<BusLine> LineSort()
        {
            List<BusLine> sortedLst = this.lines;
            sortedLst.Sort();
            return sortedLst;
        }

        public BusLine this[int index]
        {
            get => lines[FindByKey(index)];
            set => lines[FindByKey(index)] = value;

        }

         

        public int FindByKey(int key)
        {
            BusLine kbus = new BusLine();
            foreach (BusLine item in lines)
            {
                if (item.BUSLINE == key)
                {
                    kbus = item;
                    return lines.IndexOf(kbus);
                }
            }
            throw new ArgumentOutOfRangeException("This bus number doesn't exist");

        }


        public IEnumerator GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        public override string ToString()
        {
            string res = "";
            foreach (BusLine line in lines)
            {
                res += line.ToString() + "\n";
            }
            return res;
        }



    }
}
