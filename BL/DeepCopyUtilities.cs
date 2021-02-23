using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    static class DeepCopyUtilities
    {

        //we have to use this function and not Cloning because cloning is when we want to 
        //copy an object from a class to the same class 
        //but here we have to copy from a class to a new class (from DO entities to Bo entities)
        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())
            {
                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);
            }
        }
        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }

        public static BO.LineStation CopyToLineStation(this DO.Station station, DO.LineStation linsta)
        {
            DalApi.IDAL dal = DalApi.DalFactory.GetDal();

            BO.LineStation result = (BO.LineStation)station.CopyPropertiesToNew(typeof(BO.LineStation));
            // propertys' names changed? copy them here...
            result.NextStation = linsta.NextStation;
            if(result.NextStation != 2)
            {
                result.TimetoNext = dal.GetAdjacentStations(result.Code, result.NextStation).Time;
                result.DistancetoNext = dal.GetAdjacentStations(result.Code, result.NextStation).Distance;
            }
            return result;
        }
    }
}
