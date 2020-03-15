using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Keneyz_02.Tools;
using Keneyz_02.Model;
using Keneyz_02.Tools.Exeptions;

namespace Keneyz_02.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private readonly Person _person = new Person("", "", "");

        private RelayCommand<object> _proceedCommand;


        public DateTime DateOfBirth
        {
            set
            {
                _person.DateOfBirth = value;
                OnPropertyChanged();
            }
            get => (DateTime) _person.DateOfBirth;

        }

        public string Age => DateOfBirth == default ? "" : _person.Age.ToString();

        public string Name
        {
            get => _person.Name;
            set => _person.Name = value;
        }

        public string Surname
        {
            get => _person.Surname;
            set => _person.Surname = value;
        }

        public string Email
        {
            get => _person.Email;
            set => _person.Email = value;
        }
        public string Western => _person.Western;

        public string Chinese => _person.Chinese;

        public string IsBirthday => _person.IsBirthday;

        public string IsAdult => _person.IsAdult;

        private async void Process()
        {
            LoaderManager.Instance.ShowLoader();

            var res = await Task.Run(() =>
            {
                _person.Calculator();
                try
                {
                    _person.Validate();
                    if (_person.DateOfBirth.Month == DateTime.Today.Month &&
                        _person.DateOfBirth.Day == DateTime.Today.Day)
                    {
                        MessageBox.Show("Happy Birthday");
                    }
                }
                catch (NotBornException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (TooOldException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }


                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(IsAdult));
                OnPropertyChanged(nameof(IsBirthday));
                OnPropertyChanged(nameof(Western));
                OnPropertyChanged(nameof(Chinese));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Surname));
                OnPropertyChanged(nameof(Email));

                return true;

            });

            Thread.Sleep(100);
            LoaderManager.Instance.HideLoader();
        }

        
        public RelayCommand<object> ProceedCommand =>_proceedCommand ?? (_proceedCommand = new RelayCommand<object>(o => Process(), o => CanExecuteCommand()));
    
        private bool CanExecuteCommand() =>
            !string.IsNullOrWhiteSpace(_person.Email) &&
            !string.IsNullOrWhiteSpace(_person.Name) &&
            !string.IsNullOrWhiteSpace(_person.Surname) &&
            !string.IsNullOrWhiteSpace(_person.DateOfBirth.ToString());


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}