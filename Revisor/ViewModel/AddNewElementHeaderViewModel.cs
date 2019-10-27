using AticaRevisorPcManager.Context;
using AticaRevisorPcManager.Model;
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
    class AddNewElementHeaderViewModel:ViewModelBase
    {
        public AddNewElementHeaderViewModel(LocalContext localContext)
        {
            LocalContext = localContext;
            IsEnabled = true;
        }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled;set { isEnabled = value;OnPropertyChanged("IsEnabled"); } }

        LocalContext LocalContext { get; set; }

        public List<InstrumentNomenclature> AvailableNomenclatures { get => LocalContext.InstrumentNomenclatures; }

        private InstrumentNomenclature selectedNomenclature;

        public InstrumentNomenclature SelectedNomenclature { get => selectedNomenclature; set { selectedNomenclature = value; OnPropertyChanged("SelectedNomenclature"); } }

        private string xkey;
        public string Xkey { get => xkey; set { xkey = value;OnPropertyChanged("Xkey"); } }


        RelayCommand _clicAddNewElementHeader;
        public RelayCommand ClicAddNewElementHeader
        {
            get
            {
                if (_clicAddNewElementHeader == null)
                {
                    _clicAddNewElementHeader = new RelayCommand(ExecuteClicAddNewElementHeader, CanExecuteClicAddNewElementHeader);
                }
                return _clicAddNewElementHeader;
            }
        }

        public void ExecuteClicAddNewElementHeader(object parameter)
        {
            if(ServerRepository.PostNewElementHeader(-1, SelectedNomenclature.Id, Xkey))
            {
                MessageBox.Show("Новый известный элемент добавлен. Обновите данные");
                IsEnabled = false;
            }
        }
        public bool CanExecuteClicAddNewElementHeader(object parameter)
        {
           if (SelectedNomenclature!=null&&Xkey!=null)
                if(Xkey.Length>1) return true;
            return false;
        }

    }
}
