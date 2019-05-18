using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessMarketPlace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        public static Personinfo_with_service_details loginPersonInfo = null;
        public static ObservableCollection<Personinfo_with_service_details> listOfPersons;
        public static ObservableCollection<Servicesinfo> listOfServices;
        public static ObservableCollection<DisplayDetails> generalInfo;
        public static List<String> serviceTypes;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            listOfPersons = Mystorage.ReadXML<ObservableCollection<Personinfo_with_service_details>>("Personinfowithservicedetails.xml");
            listOfServices = Mystorage.ReadXML<ObservableCollection<Servicesinfo>>("Serviceinfo.xml");
            serviceTypes = new List<String> { "Education", "Furniture","Electronic_Items","HouseholdItems", "RentCar", "Renthouse", "Other" };

            if (listOfPersons == null)
                listOfPersons = new ObservableCollection<Personinfo_with_service_details>();

            if (listOfServices == null)
                listOfServices = new ObservableCollection<Servicesinfo>();

            if (generalInfo == null)
                generalInfo = new ObservableCollection<DisplayDetails>();

            MainWindow mainWindow = new MainWindow();
            MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}
