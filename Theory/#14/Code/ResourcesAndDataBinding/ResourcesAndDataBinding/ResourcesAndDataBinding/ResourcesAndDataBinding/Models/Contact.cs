using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace ResourcesAndDataBinding.Models
{
    [Table("Contacts")]
    public class Contact : INotifyPropertyChanged
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        private string _lastName;

        [MaxLength(50)]
        [NotNull]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth

        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        private bool _isFamilyMember;
        public bool IsFamilyMember
        {
            get
            {
                return _isFamilyMember;
            }

            set
            {
                _isFamilyMember = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}