using AticaRevisorPcManager.Repository;
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
    class AddInventoryObjectViewModel : ViewModelBase
    {
        public AddInventoryObjectViewModel() => IsEnabled = true;
      
        private string name;
        public string Name { get => name; set { name = value;OnPropertyChanged("Name"); } }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled;set { isEnabled = value;OnPropertyChanged("IsEnabled"); } }


        RelayCommand _clicAddObject;
        public RelayCommand ClicAddObject
        {
            get
            {
                if (_clicAddObject == null)
                {
                    _clicAddObject = new RelayCommand(ExecuteClicAddObject, CanExecuteClicAddObject);
                }
                return _clicAddObject;
            }
        }

        public void ExecuteClicAddObject(object parameter)
        {

          if(  ServerRepository.PostNewInventoryObject(Name))
            {
                IsEnabled = false;
                MessageBox.Show("Объект успешно добавлен");
            }


        }
        public bool CanExecuteClicAddObject(object parameter)
        {
          if(Name!=null)
                if(Name.Length>0)return true;
            return false;
        }
    }
}
