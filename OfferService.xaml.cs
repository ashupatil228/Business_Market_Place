using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OfferService.xaml
    /// </summary>
    public partial class OfferService : Window
    {
       
        
        static OfferService Instance;
        ObservableCollection<Servicesinfo> service = new ObservableCollection<Servicesinfo>();
         
        public OfferService( string classname)
        {
            InitializeComponent();
            Instance = this;
            if(classname== "Signup")
            {
                Btn_Add_Person.Visibility = Visibility.Hidden;
                Btn_Save.Visibility = Visibility.Hidden;
                Btn_Register.Visibility = Visibility.Visible;
            }
            else
            {
                Btn_Add_Person.Visibility = Visibility.Visible;
                Btn_Save.Visibility = Visibility.Visible;
                Btn_Register.Visibility = Visibility.Hidden;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            if (App.loginPersonInfo == null)
            {
                Tabctrl_OfferServce.SelectedIndex = 1;
                EnableDisableCtrls(true);
                
                G_PersonInfo.DataContext = null;
                Btn_Add_Person.IsEnabled = false;
               
            }
            else
            {
                G_PersonInfo.DataContext = App.loginPersonInfo;
                EnableDisableCtrls(false);
                Txt_Email.IsEnabled = false;
                Txt_Password.IsEnabled = false;
                Btn_Add_Person.IsEnabled = true;
                foreach (var Addservice in App.listOfServices)
                {
                    if (Addservice.PersonId == App.loginPersonInfo.Email)
                    {
                        service.Add(Addservice);
                    }
                }
            }
           
            Lbx_Offered_Services.ItemsSource = service;
            Txtb_Offered_Lst.Text = "You have offered " + Lbx_Offered_Services.Items.Count + " services";

        }

        public void EnableDisableCtrls(bool isEnabled)
        {
            
            Txt_FrstName.IsEnabled = isEnabled;
            Txt_Contact.IsEnabled = isEnabled;
            Txt_LstName.IsEnabled = isEnabled;
           

        }
        private void Btn_Add_New_Service_Click(object sender, RoutedEventArgs e)
        {
            AddServices add = new AddServices(null,Btn_Add_New_Service.Content.ToString());
            add.Show();
           
          
        }

        private void Btn_edit_service_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_Offered_Services.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to edit service");
            }
            else
            {
                var editService = Lbx_Offered_Services.SelectedItem as Servicesinfo;
                AddServices add = new AddServices(editService, Btn_edit_service.ToString());
                add.Show();
            }
           
        }
       
        private void Btn_Delete_Servc_Click(object sender, RoutedEventArgs e)
        {
            var deleteService = Lbx_Offered_Services.SelectedItem as Servicesinfo;

            if (Lbx_Offered_Services.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to be deleted...");
                return;
            }

            foreach (var person in App.listOfPersons)
            {
                if (person.Email == App.loginPersonInfo.Email)
                {
                    foreach (var serviceId in person.Offered_services)
                    {
                        if (serviceId == deleteService.ServiceId)
                        {
                            person.Offered_services.Remove(serviceId);
                            Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
                            break;
                        }
                    }
                    break;
                }

            }
            foreach(var deletedItem in App.generalInfo )
            {
                if(deletedItem.ServiceId==deleteService.ServiceId)
                {
                    App.generalInfo.Remove(deletedItem);
                }
            }
            foreach (var item in App.listOfServices)
            {
                if (item.ServiceId ==deleteService.ServiceId)
                {
                    App.listOfServices.Remove(item);
                    service.Remove(item);
                    MessageBox.Show("Seletem Item is deleted sucessfully");
                    Mystorage.WriteXML<ObservableCollection<Servicesinfo>>("Serviceinfo.xml", App.listOfServices);
                    break;
                }
                
            }

            Lbx_Offered_Services.ItemsSource = service;
            Txtb_Offered_Lst.Text = "You have offered " + Lbx_Offered_Services.Items.Count + " services";

            Lbx_Interested_Ppl.ItemsSource = App.generalInfo;
           
            
        }

        private void Lbx_Offered_Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedService = Lbx_Offered_Services.SelectedItem as Servicesinfo;
            ObservableCollection<Personinfo_with_service_details> interestedPersons = new ObservableCollection<Personinfo_with_service_details>();

            if (selectedService == null)
            {
                return;
            }
            else
            {
                foreach(var person in App.listOfPersons)
                {
                    foreach (var item in selectedService.InterestedPersonsEmailId)
                    {
                        if(item == person.Email)
                        {
                            interestedPersons.Add(person);
                            break;
                        }
                    }

                    if(interestedPersons.Count == selectedService.InterestedPersonsEmailId.Count)
                    {
                        break;
                    }

                }
               
            }
                
            Lbx_Interested_Ppl.ItemsSource = interestedPersons;
            Txt_Interested_Ppl.Text = "There are " + Lbx_Interested_Ppl.Items.Count + " person interested in your offer";


        }

        private void Btn_Add_Person_Click(object sender, RoutedEventArgs e)
        {
            EnableDisableCtrls(true);
                           
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
         
            if(Txt_Email.Text.Length==0 && Txt_Password.Text.Length==0)
            {
                MessageBox.Show("EmailId and Password cannot be empty");
                
            }
            else
            {
                foreach (var person in App.listOfPersons)
                {
                    if (Txt_Email.Text == person.Email)
                    {
                        App.listOfPersons.Where(S => S.Email == App.loginPersonInfo.Email)
                         .Select(S => { S.FirstName = Txt_FrstName.Text; S.LastName = Txt_LstName.Text; S.Password = Txt_Password.Text; S.ContactNo = Txt_Contact.Text; return S; }).ToList();
                        MessageBox.Show("Updated Sucessfully...");
                        break;
                    }
                    
                }
            }
            
            EnableDisableCtrls(false);
            Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);


        }

        private void Txt_FrstName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(Txt_FrstName.Text))
            {
                Txt_FrstName.Text = "";
                               
            }
        }

        private void Txt_LstName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(Txt_LstName.Text))
            {
                Txt_LstName.Text = "";
                                
            }
        }

        private void Txt_Contact_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void Txt_Email_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@" ^ ([\w\.\-] +)@([\w\-] +)((\.(\w){ 2, 3 })+)$");
            if (regex.IsMatch(Txt_Email.Text))
            {
                Txt_Email.Text = "";
                MessageBox.Show("Invalid email address !");
                
            }
        }

        private void Txt_Password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            Regex regex = new Regex(@"/ ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/ ");
            if (regex.IsMatch(Txt_Password.Text))
            {
                Txt_Password.Text = "";
                       
            }
        }

        private void Txt_OfferedServce_ServiceType_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var lst = from item in App.listOfServices where item.ServiceType.ToLower().Contains(Txt_OfferedServce_ServiceType.Text.ToLower()) select item;
            Lbx_Offered_Services.ItemsSource = lst;
        }


        public static void UpdateServiceList()
        {
            Instance.service.Clear();

            foreach (var Addservice in App.listOfServices)
            {
                if (Addservice.PersonId == App.loginPersonInfo.Email)
                {
                    Instance.service.Add(Addservice);
                }
            }

            Instance.Lbx_Offered_Services.ItemsSource = Instance.service;
            Instance.Txtb_Offered_Lst.Text = "You have offered " + Instance.Lbx_Offered_Services.Items.Count + " services";
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            bool personexist = false;
            if (Txt_Email.Text.Length == 0 && Txt_Password.Text.Length == 0)
            {
                MessageBox.Show("EmailId and Password cannot be empty");

            }
            else
            {
                foreach (var person in App.listOfPersons)
                {
                    if (Txt_Email.Text == person.Email)
                    {
                        
                        MessageBox.Show("Allready registered...");
                        personexist = true;
                        break;
                        

                    }
                   
                }
                if(!personexist)
                {
                    var newPerson = new Personinfo_with_service_details { FirstName = Txt_FrstName.Text, LastName = Txt_LstName.Text, ContactNo = Txt_Contact.Text, Email = Txt_Email.Text, Password = Txt_Password.Text };
                    App.listOfPersons.Add(newPerson);
                    MessageBox.Show("Registered Sucessfull");
                    Mystorage.WriteXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml", App.listOfPersons);
                }
            }

            this.Close();
            

        }
    }
}
