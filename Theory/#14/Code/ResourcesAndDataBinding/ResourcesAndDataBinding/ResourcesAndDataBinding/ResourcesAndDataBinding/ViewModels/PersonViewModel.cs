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
    public class PersonViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; }
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
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
        public ICommand RefreshCommand { get; set; }
        public ICommand AddPersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadSampleData()
        {
            People = new ObservableCollection<Person>();
            // sample data
            Person person1 =
            new Person
            {
                FullName = "John McClane",
                Address = "United States",
                DateOfBirth = new DateTime(1977, 5, 10)
            };
            Person person2 =
            new Person
            {
                FullName = "Walter White",
                Address = "United States",
                DateOfBirth = new DateTime(1960, 2, 1)
            };
            Person person3 =
            new Person
            {
                FullName = "Rocky Balboa",
                Address = "United States",
                DateOfBirth = new DateTime(1980, 4, 2)
            };
            People.Add(person1);
            People.Add(person2);
            People.Add(person3);
        }

        public PersonViewModel()
        {
            LoadSampleData();

            Random r = new Random();
            AddPersonCommand = new Command(() => People.Add(new Person() 
            { Address="German",
                DateOfBirth=new DateTime(r.Next(1960,1980), r.Next(1, 12), r.Next(1, 30)),
                FullName = "Hans Gruber"}));

            DeletePersonCommand = new Command<Person>((person) => People.Remove(person));

            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                LoadSampleData();
                // Simulates a longer operation
                await Task.Delay(2000);
                IsRefreshing = false;
            });
        }

    }
}
