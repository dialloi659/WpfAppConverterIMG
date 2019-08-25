using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
using WpfApp5.Model;

namespace WpfApp5
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContactsModel Contactmodel { get; set; }

        public MainWindow()
        {
            this.Contactmodel = new ContactsModel();
            this.Contactmodel.Contacts = new ObservableCollection<Contact>();
            InitializeComponent();
            this.DataContext = this;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Contactmodel.Contacts = await GetContacts();
        }


        private async Task<ObservableCollection<Model.Contact>> GetContacts()
        {
            HttpClient MyClt = new HttpClient();
            MyClt.BaseAddress = new Uri("http://localhost:8767");
            MyClt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage WebApiRsp = await MyClt.GetAsync("api/home");
            if (WebApiRsp.IsSuccessStatusCode)
            {
                var StrContacts = await WebApiRsp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Model.Contact>>(StrContacts);                  
            }
            else
            {
                return new ObservableCollection<Model.Contact>();
            }
        }
    }
}
