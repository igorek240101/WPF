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
    class AddNewInstrumentNomenclatureViewModel : ViewModelBase
    {

        public AddNewInstrumentNomenclatureViewModel ( )
        { 
            IsEnabled = true;
            
        } 


        //public MainWindowViewModel MainWindowViewModel { get; set; }

        public int Id { get; set; }
        private string name;
        public string Name { get => name; set { name = value;OnPropertyChanged("Name"); } }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged("IsEnabled"); } }


        RelayCommand _clicAddNomenclature;
        public RelayCommand ClicAddNomenclature
        {
            get
            {
                if (_clicAddNomenclature == null)
                {
                    _clicAddNomenclature = new RelayCommand(ExecuteClicAddNomenclature, CanExecuteClicAddNomenclature);
                }
                return _clicAddNomenclature;
            }
        }

        public void ExecuteClicAddNomenclature(object parameter)
        {

            if (ServerRepository.PostNewInstrumentNomenclature(  Name))
            {
                IsEnabled = false;
                MessageBox.Show("Новая номенклатура успешно добавлена. Обновите данные");

            }


        }
        public bool CanExecuteClicAddNomenclature(object parameter)
        {
          if(Name!=null)
                if(Name.Length>0)return true;
            return false;
        }
    }
}
