using AticaRevisorPcManager.Service;
using AticaRevisorPcManager.ViewModel.Base;
using AticaRevisorPcManager.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AticaRevisorPcManager.ViewModel
{
    class MainWindowViewModel:ViewModelBase
    {
        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }

        public MainWindowViewModel()
        {
            SetListObjectsView();
        }
       public void SetListObjectsView()
        {
            CurrentPage = ViewService.ListOfObjects;
        }

      public void SetOneObject()
        {
            CurrentPage = ViewService.OneInventoryObject;
        }

        public void SetNomenclatureAndInstrumentHeaders()
        {
            CurrentPage = ViewService.NomenclatureAndElementHeadersPage;
        }
        public void SetListUsers()
        {
            CurrentPage = ViewService.ListUsers;
        }

        RelayCommand _clicButton;
        public RelayCommand ClicButton
        {
            get
            {
                if (_clicButton == null)
                {
                    _clicButton = new RelayCommand(ExecuteClicButton, CanExecuteClicButton);
                }
                return _clicButton;
            }
        }

        public void ExecuteClicButton(object parameter)
        {
            var t = System.Convert.ToInt32(parameter);
            if (t == 1) {
                SetListObjectsView();
            }
            if (t == 2) { SetNomenclatureAndInstrumentHeaders(); }
            if (t ==3) { SetListUsers(); }
        }
        public bool CanExecuteClicButton(object parameter)
        {
            return true;
        }







    }
}
