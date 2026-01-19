using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfMvvmDemo.Models;

namespace WpfMvvmDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private User _user;

        public MainViewModel()
        {
            // Initialize with some data
            _user = new User
            {
                Name = "Jane Doe (ViewModel)",
                Age = 25,
                Email = "jane@mvvm.com"
            };
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                if (_user.Name != value)
                {
                    _user.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get { return _user.Age; }
            set
            {
                if (_user.Age != value)
                {
                    _user.Age = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return _user.Email; }
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
