using AticaRevisorPcManager.Context;
using AticaRevisorPcManager.Model;
using AticaRevisorPcManager.View;
using AticaRevisorPcManager.ViewModel.Base;
using AticaRevisorPcManager.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AticaRevisorPcManager.ViewModel
{
    class ListUsersViewModel:ViewModelBase
    {
        public ListUsersViewModel(LocalContext localContext)
        {
            LocalContext = localContext;
        }

        public LocalContext LocalContext { get; set; }

        public List <User> Users { get => LocalContext.Users; }

        RelayCommand _clicGetAllUsers;
        public RelayCommand ClicGetAllUsers
        {
            get
            {
                if (_clicGetAllUsers == null)
                {
                    _clicGetAllUsers = new RelayCommand(ExecuteClicGetAllUsers, CanExecuteClicGetAllUsers);
                }
                return _clicGetAllUsers;
            }
        }

        public void ExecuteClicGetAllUsers(object parameter)
        {
           LocalContext.GetUsers();
            OnPropertyChanged("Users");
        }
        public bool CanExecuteClicGetAllUsers(object parameter)
        {
            //if (Name.Length == 0 && Number.Length== 0 && Mark.Length == 0 && Model.Length == 0)
            return true;
        }

        RelayCommand _clicAddUser;
        public RelayCommand ClicAddUser
        {
            get
            {
                if (_clicAddUser == null)
                {
                    _clicAddUser = new RelayCommand(ExecuteClicAddUser, CanExecuteClicClicAddUser);
                }
                return _clicAddUser;
            }
        }

        public void ExecuteClicAddUser(object parameter)
        {

            var win = new AddNewUser { DataContext = new AddNewUserViewModel() };
                win.ShowDialog();
             
         

        }
        public bool CanExecuteClicClicAddUser(object parameter)
        {

            return true;
        }

    }
}
