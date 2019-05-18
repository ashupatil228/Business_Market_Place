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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach(var person in App.listOfPersons)
            {
                if(person.Email==Txt_Email.Text)
                {
                    if(Txt_Password.Text==Txt_ConfrmPass.Text)
                    {
                        person.Password = Txt_Password.Text;
                        Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
                        MessageBox.Show("Password Reset Successfull");
                        this.Close();
                        break;
                    }
                   
                }
                else
                {
                    MessageBox.Show("Email Id is not registered");
                    break;
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
