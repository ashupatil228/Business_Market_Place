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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusinessMarketPlace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int Count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_Service_List.ItemsSource = App.serviceTypes;
            Lbx_Display_List.ItemsSource = App.listOfServices;

        }


        private void Lbx_Service_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Servicesinfo> list = new List<Servicesinfo>();

            String ServType = (string)Lbx_Service_List.SelectedItem;

            foreach (var service in App.listOfServices)
            {
                if (service.ServiceType.Equals(ServType))
                {
                    list.Add(service);
                }

            }

            if (list.Count == 0)
            {
                MessageBox.Show("No services available");
            }
            Lbx_Display_List.ItemsSource = list;
        }

        private void Btn_Main_Login_Click(object sender, RoutedEventArgs e)
        {

            LoginForm login = new LoginForm();
            App.loginPersonInfo = null;
            login.Show();
            
        }

        private void Btn_Offerservice_Click(object sender, RoutedEventArgs e)
        {

            if (App.loginPersonInfo == null)
            {
                MessageBox.Show("Please login to manage services and personal data");
            }
            else
            {
                OfferService service = new OfferService(null);
                service.Show();
            }
        }

        private void Btn_Interested_Click(object sender, RoutedEventArgs e)
        {
            var interestedService = Lbx_Display_List.SelectedItem as Servicesinfo;

            if (App.loginPersonInfo == null)
            {
                MessageBox.Show("Please login to send your interested request");
            }
            else if (Lbx_Display_List.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to send your interested request");
            }
            else
            {

                foreach (var person in App.listOfPersons)
                {
                    if (interestedService.PersonId == App.loginPersonInfo.Email)
                    {
                        MessageBox.Show("Selected service is offered by you...");
                        return;

                    }
                }

                bool existingService = false;

                foreach (var interest in App.listOfPersons)
                {
                    if (interest.Email == App.loginPersonInfo.Email)
                    {

                        foreach (var serviceId in interest.Interested_offers)
                        {
                            if (interestedService.ServiceId == serviceId)
                            {
                                MessageBox.Show("Selected service already in your interested list");
                                existingService = true;
                                return;
                            }
                        }
                        if (!existingService)
                        {
                            interest.Interested_offers.Add(interestedService.ServiceId);
                            MessageBox.Show("Thankyou for your interest in service....");
                        }

                        break;
                    }

                }

                foreach (var service in App.listOfServices)
                {
                    if (service.ServiceId == interestedService.ServiceId)
                    {
                        service.InterestedPersonsEmailId.Add(App.loginPersonInfo.Email);
                        break;
                    }

                }

                Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
                Mystorage.WriteXML<ObservableCollection<Servicesinfo>>("Serviceinfo.xml", App.listOfServices);
            }
        }



        private void Tbx_filter_service_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lst = from item in App.serviceTypes where item.ToLower().Contains(Tbx_filter_service.Text.ToLower()) select item;

            Lbx_Service_List.ItemsSource = lst;


        }

        private void Btn_Int_srv_Click(object sender, RoutedEventArgs e)
        {
            if (App.loginPersonInfo == null)
            {
                MessageBox.Show("Please login to see your interested offers");
            }
            else
            {
                Your_Interested_Offers interested_Offers_window = new Your_Interested_Offers();
                interested_Offers_window.Show();
            }

        }
    }
}
