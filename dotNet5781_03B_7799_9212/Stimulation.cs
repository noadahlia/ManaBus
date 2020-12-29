using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace dotNet5781_03B_7799_9212
{
    public static class Stimulation
    {
        static Random rand = new Random(DateTime.Now.Millisecond);


        public static void readyToTravel(this Bus bus, int distance)
        {
            bus.buState = Bus.State.readyToGo;
            //chercher nom de fonction au lieu de func
            Func(bus, () => bus.drive(distance), new TimeSpan(distance / rand.Next(20, 50), 0, 0));
        }

        public static void refuel(this Bus bus)
        {
            bus.buState = Bus.State.onRefueling;
            Func(bus, () => bus.Refueling(), new TimeSpan(2, 0, 0));
        }

        public static void treatement(this Bus bus)
        {
            bus.buState = Bus.State.inTreatment;
            Func(bus, () => bus.dateTreatment(), new TimeSpan(24, 0, 0));
        }

        public static void Func(Bus bus, Action action, TimeSpan span)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            //worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;// a completer
            worker.RunWorkerAsync(span);

            // void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            //{
            //    bus.Progress = (int)e.ProgressPercentage;// progress????????????
            //    if (action.Method.Name == "<Treat>b_0")
            //        bus.LastProgress = 100 * span..Hours - (int)e.ProgressPercentage + 100;
            //    else
            //        bus.LastProgress = 100 * span..Hours - (int)e.ProgressPercentage - 100;
            // }

            void Worker_DoWork(object sender, DoWorkEventArgs e)
            {
                var worker1 = (BackgroundWorker)sender;
                var Minutes = ((TimeSpan)e.Argument).TotalMinutes;
                for (int i = 1; i <= Minutes; i++)
                {
                    int progress = (int)(i / Minutes) * 1000;
                    WorkerReportsProgress(progress);
                    Thread.Sleep(100);
                }
            }

        }

        private static void WorkerReportsProgress(int progress)
        {
            throw new NotImplementedException();
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    } }
