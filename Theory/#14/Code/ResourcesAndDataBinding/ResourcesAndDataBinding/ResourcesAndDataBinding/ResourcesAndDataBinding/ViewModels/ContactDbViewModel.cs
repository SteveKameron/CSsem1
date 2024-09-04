using ResourcesAndDataBinding.DataAccess;
using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResourcesAndDataBinding.ViewModels
{
    public class ContactDbViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName= null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        public Command AddCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command SaveAllCommand { get; set; }

        public ContactsDataAccess ContactsDataBase;

        private void LoadData()
        {
            Contacts = new ObservableCollection<Contact>
                (ContactsDataBase.GetFamilyMembers());
        }

        public ContactDbViewModel()
        {
            ContactsDataBase = new ContactsDataAccess();
            LoadData();

            AddCommand =
                new Command(() => Contacts.Add(new Contact()));

            DeleteCommand =
                new Command<Contact>((contact) =>
                {
                    Contacts.Remove(contact);
                    if (contact.ID != 0)
                        ContactsDataBase.DeleteContact(contact);
                },
                (contact) => contact != null);

            SaveAllCommand = new Command(() => ContactsDataBase.SaveAll(Contacts));

            RefreshCommand =
                new Command(async () =>
                {
                    IsRefreshing = true;
                    LoadData();
                    // Simulates a longer operation
                    await Task.Delay(2000);
                    IsRefreshing = false;
                }
            );
        }
    }
}
