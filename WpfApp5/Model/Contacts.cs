using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Model
{
    public class ContactsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Model.Contact> _Contacts;
        public ObservableCollection<Model.Contact> Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                if (PropertyChanged != null)
                    OnPropertyChanged("Contacts");
            }
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
