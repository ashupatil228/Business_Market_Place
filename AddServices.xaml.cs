using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddServices.xaml
    /// </summary>
    public partial class AddServices : Window
    {
        Servicesinfo selelctedService;
        String btnName;

        public AddServices( Servicesinfo info,String func)
        {
            InitializeComponent();
            selelctedService = info;
            btnName = func;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cbx_Serv_List.ItemsSource = App.serviceTypes;
            if (btnName =="Add")
            {
                
            }
            else
            {
                
                Grd_Business_List.DataContext = selelctedService;
                Cbx_Serv_List.SelectedItem = selelctedService.ServiceType;
                //Cbx_Serv_List.SelectedValue = selelctedService.ServiceType;
                Dp_Date.Text = selelctedService.PostedDate;
            }

        }

        private void Btn_Add_Submit_Click(object sender, RoutedEventArgs e)
        {
            int serviceCount = App.listOfServices.Count;

            if (btnName == "Add")
            {
                var newService = new Servicesinfo
                {
                    ServiceId = "S" + ++serviceCount,
                    ServiceType = Cbx_Serv_List.SelectedValue.ToString(),
                    Price = Txt_Price.Text,
                    Description = Txt_Description.Text,
                    Location = Txt_Location.Text,
                    PostedDate = Dp_Date.Text,
                    PersonId = App.loginPersonInfo.Email

                };
               
                foreach(var person in App.listOfPersons)
                {
                    if(person.Email == App.loginPersonInfo.Email)
                    {

                        person.Offered_services.Add(newService.ServiceId);
                        break;
                    }
                }
                App.listOfServices.Add(newService);
            }
            else
            {
                App.listOfServices.Where(S => S.ServiceId == selelctedService.ServiceId)
                    .Select(S => {  S.ServiceType = Cbx_Serv_List.SelectedValue.ToString(); S.Price = Txt_Price.Text; S.Location = Txt_Location.Text; S.Description = Txt_Description.Text; return S; }).ToList();

            }

            Mystorage.WriteXML<ObservableCollection<Servicesinfo>>("Serviceinfo.xml", App.listOfServices);
            Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
            MessageBox.Show("Service Added Successfully....");
            OfferService.UpdateServiceList();
            this.Close();
        }

        private void Cbx_Serv_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Txt_Price_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
             Regex regex = new Regex(@"^[0-9]*\.[0-9][0-9][0-9]$");
            if (regex.IsMatch(Txt_Price.Text))
            {
               MessageBox.Show("Invalid price !");
               Txt_Price.Text = "";


            }

        }

        private void Txt_Location_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(Txt_Location.Text))
            {
             
                Txt_Location.Text = "";
            }
        }

       
    }
}
