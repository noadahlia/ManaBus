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
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");

        public MainWindow()
        {
            InitializeComponent();



        }




        BO.User curUser = new User();
        private void login_btn2_Click(object sender, RoutedEventArgs e)
        {

            curUser.UserName = userN.Text;
            curUser.Password = (string)password2.Password;
            
            bool verification;


            verification = bl.LogInVerify(curUser);
            try
            {
                if (verification == true)
                {
                    verification = bl.isWorker(curUser);
                    if (verification==true)
                    {
                        Management managementWin = new Management(bl);
                        this.Close();
                        managementWin.ShowDialog();
                    }
                    else
                    {
                        UserArea userAreaWin = new UserArea(bl);
                        this.Close();
                        userAreaWin.ShowDialog();

                    }

                    // verifier si User existe
                    // verifier si bon password
                    //verifier si worker page 1 sinon page 2
                }
            }
            catch (BO.BadUserIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void login_btn1_Click(object sender, RoutedEventArgs e)
        {
            Management managementWin = new Management(bl);
            this.Close();
            managementWin.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}