using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        BO.User curUser;
        public MainWindow(IBL _bl, BO.User _curUser)
        {
            InitializeComponent();
            bl = _bl;
            curUser = _curUser;
           

        }
      
        //private void login_btn1_Click(object sender, RoutedEventArgs e)
        //{
        //    bool verification;

        //    try 
        //    {
        //        verification=bl.LogInVerify(curUser);
        //        if(verification==true)
        //        {
        //            if(curUser.Worker==true)
        //            {
        //                Management managementWin = new Management(bl);
        //                this.Close();
        //                managementWin.ShowDialog();
        //            }
        //            else
        //            {

        //            }
               
        //        // verifier si User existe
        //        // verifier si bon password
        //        //verifier si worker page 1 sinon page 2
        //    }
        //    catch (DO.BadUserIdException ex)
        //    {
        //        throw new BO.BadUserIdException("", ex);
        //    }
        //    //Management managementWin = new Management(bl);
        //    //this.Close();
        //    //managementWin.ShowDialog();
        //}

    }
}