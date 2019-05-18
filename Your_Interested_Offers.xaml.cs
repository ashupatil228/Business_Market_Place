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
    /// Interaction logic for Your_Interested_Offers.xaml
    /// </summary>
    public partial class Your_Interested_Offers : Window
    {
        public Your_Interested_Offers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            List<String> servicesId = new List<string>();
                       
            foreach (var person in App.listOfPersons)
            {
                if(person.Email == App.loginPersonInfo.Email)
                {
                    for(int i=0;i<person.Interested_offers.Count;i++)
                    {
                        servicesId.Add(person.Interested_offers[i]);
                    }
                }
            }

            foreach(var service in App.listOfServices)
            {
                for(int i=0;i< servicesId.Count;i++)
                {
                    if(service.ServiceId == servicesId[i])
                    {
                        var display = new DisplayDetails
                        {
                            ServiceId = service.ServiceId,
                            ServiceType = service.ServiceType,
                            Price = service.Price,
                            Location = service.Location,
                            Description = service.Description,
                            PostedDate = service.PostedDate,


                        };
                        foreach(var person in App.listOfPersons)
                        {
                            if(service.PersonId == person.Email)
                            {
                                display.FirstName = person.FirstName;
                                display.LastName = person.LastName;
                                display.ContactNo = person.ContactNo;
                                display.Email = person.Email;
                            }
                        }
                        App.generalInfo.Add(display);
                    }
                }
            }
           
            foreach(var item in App.generalInfo)
            {
                if(item.ServiceId==null)
                {

                    foreach(var person in App.listOfPersons)
                    {
                        if(person.Email==App.loginPersonInfo.Email)
                        {
                            foreach(var serviceId in person.Interested_offers)
                            {
                                person.Interested_offers.Remove(serviceId);
                                break;
                            }
                        }

                    }
                    break;
                }
            }


            Lbx_Interested_Offers.ItemsSource = App.generalInfo;
            Txtb_Interested_Offers.Text = "You are interested in " + App.generalInfo.Count + " offers";
        }
        private void Btn_Delete_Intst_Offer_Click(object sender, RoutedEventArgs e)
        {

            var deleteService = Lbx_Interested_Offers.SelectedItem as DisplayDetails;
            if (Lbx_Interested_Offers.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete an interested service");
            }
            else
            {
                if (deleteService == null)
                {
                    return;
                }
                else
                {
                    foreach (var person in App.listOfPersons)
                    {
                        if (person.Email == App.loginPersonInfo.Email)
                        {
                            foreach (var serviceId in person.Interested_offers)
                            {
                                if (serviceId == deleteService.ServiceId)
                                {
                                    person.Interested_offers.Remove(serviceId);
                                    break;
                                }
                            }
                            break;
                        }

                    }
                    
                    foreach (var item in App.listOfServices)
                    {
                        if (item.ServiceId == deleteService.ServiceId)
                        {
                            if (item.InterestedPersonsEmailId.Count != 0)
                            {
                                foreach (var emailId in item.InterestedPersonsEmailId)
                                {
                                    item.InterestedPersonsEmailId.Remove(emailId);
                                    break;
                                }
                                break;
                            }
                            
                        }

                    }
                    foreach(var delete in App.generalInfo )
                    {
                        if(delete.ServiceId==deleteService.ServiceId)
                        {
                            App.generalInfo.Remove(delete);
                            break;
                        }
                    }
                }
                Lbx_Interested_Offers.ItemsSource = App.generalInfo;
                Txtb_Interested_Offers.Text = "You are interested in " + App.generalInfo.Count + " offers";
                Mystorage.WriteXML<ObservableCollection<Servicesinfo>>("Serviceinfo.xml", App.listOfServices);
                Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
            }

        }

        private void Txt_Intrested_Service_Type_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var lst = from item in App.generalInfo where item.ServiceType.ToLower().Contains(Txt_Intrested_Service_Type.Text.ToLower()) select item;
            Lbx_Interested_Offers.ItemsSource = lst;
        }
    }
}
