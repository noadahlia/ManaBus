using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

class BuStation
{
    int Bus_Station_Key;// max 6 chiffres
    double Latitude;//31,33.3
    double Longitude;//34.3,35.5
    string Station_Name;
   
}

//הגדירו מחלקה שתייצג תחנת קו אוטובוס
//תחנת קו אוטובוס מכילה את כל נתוני תחנת האוטובוס כנ"ל ובנוסף לפחות את
//הנתונים הבאים:
//• מרחק מתחנת קו אוטובוס הקודמת
//• זמן נסיעה מתחנת קו אוטובוס הקודמת
//ניתן לבנות תחנת קו אוטובוס על בסיס אובייקט של תחנת אוטובוס ונתונים הנ"ל
class BusLineStation: BuStation
{
    int Station_Distance;
    int Travel_Time_From_Station;

}

class BusLine
{
    int Line_Num;
    enum Area {North, South, Center, General }
    string First_Station;//int?
    string Last_Staion;


}
