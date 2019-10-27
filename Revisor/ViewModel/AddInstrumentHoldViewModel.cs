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
    class AddInstrumentHoldViewModel : ViewModelBase
    {

        public AddInstrumentHoldViewModel(int id,MainWindowViewModel mainWindowViewModel)
        {Id = id;
            IsEnabled = true;
            MainWindowViewModel = mainWindowViewModel;
        } 


        public MainWindowViewModel MainWindowViewModel { get; set; }

        public int Id { get; set; }
        private string name;
        public string Name { get => name; set { name = value;OnPropertyChanged("Name"); } }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged("IsEnabled"); } }


        RelayCommand _clicAddHold;
        public RelayCommand ClicAddHold
        {
            get
            {
                if (_clicAddHold == null)
                {
                    _clicAddHold = new RelayCommand(ExecuteClicAddHold, CanExecuteClicAddHold);
                }
                return _clicAddHold;
            }
        }

        public void ExecuteClicAddHold(object parameter)
        {

         if(ServerRepository.PostHoldInstrument(Id, Name))
            {
                IsEnabled = false;
                MessageBox.Show("Склад успешно добавлен");
                MainWindowViewModel.SetListObjectsView();
                ViewModelService.ListOfObjects.ExecuteClicGetAllObjects(null);
            }
           


        }
        public bool CanExecuteClicAddHold(object parameter)
        {
          if(Name!=null)
                if(Name.Length>0)return true;
            return false;
        }
    }
}
