using AticaRevisorPcManager.Repository;
using AticaRevisorPcManager.Service;
using AticaRevisorPcManager.ViewModel.Base;
using AticaRevisorPcManager.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AticaRevisorPcManager.ViewModel
{
    class AddNewUserViewModel : ViewModelBase
    {

        public AddNewUserViewModel( )
        { 
            IsEnabled = true;
            
        } 


        //public MainWindowViewModel MainWindowViewModel { get; set; }

        public int Id { get; set; }
        private string name;
        public string Name { get => name; set { name = value;OnPropertyChanged("Name"); } }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged("IsEnabled"); } }

        private string password;
        public string Password { get => password; set { password = value;OnPropertyChanged("Password"); } }


        RelayCommand _clicAddUser;
        public RelayCommand ClicAddUser
        {
            get
            {
                if (_clicAddUser == null)
                {
                    _clicAddUser = new RelayCommand(ExecuteClicAddUser, CanExecuteClicAddUser);
                }
                return _clicAddUser;
            }
        }

        public void ExecuteClicAddUser(object parameter)
        {

            if (ServerRepository.PostNewElementUser(  Name,Password ))
            {
                IsEnabled = false;
                MessageBox.Show("Новый пользователь добавлен. Обновите данные");

            }


        }
        public bool CanExecuteClicAddUser(object parameter)
        {
          if(Name!=null)
                if(Name.Length>0)
                    if (Password != null)
                        if (Password.Length > 3)

                            return true;
            return false;
        }
    }
}
