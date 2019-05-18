using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BusinessMarketPlace
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public static int passCount = 0;

        public LoginForm()
        {
            
            InitializeComponent();
        }

        private void Btn_Regster_Click(object sender, RoutedEventArgs e)
        {
            
                OfferService offerServiceWindow = new OfferService("Signup");
                offerServiceWindow.Tabctrl_OfferServce.SelectedIndex = 1;
                offerServiceWindow.Show();
                this.Close();
           

        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
                       
           
            bool personExists = false;
            foreach (var person in App.listOfPersons)
            {
                if (person.Email.Equals(Txt_Logn_id.Text))
                {
                    if (person.Password.Equals(Txt_Logn_pwd.Password))
                    {
                        App.loginPersonInfo = person;
                        personExists = true;
                        this.Close();
                        
                        MessageBox.Show("Login Successfully...");
                    }
                    else
                    {
                        passCount++;
                        
                        
                    }
                    
                }
               
            }
            if(passCount>=3)
            {
                ResetPassword reset = new ResetPassword();
               
                reset.Show();
                return;
            }
            else if (!personExists)
            {
                    MessageBox.Show("Incorrect Email or Password, Please Enter Registered Email and Password");
            }
           

        }
    }
}
