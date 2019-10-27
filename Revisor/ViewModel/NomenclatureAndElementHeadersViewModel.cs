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
     class NomenclatureAndElementHeadersViewModel:ViewModelBase
    {
        public NomenclatureAndElementHeadersViewModel(LocalContext localContext)
        {
            LocalContext = localContext;
        }
        public LocalContext LocalContext { get; set; }

        public List<MaterialNomenclature> MaterialNomenclatures { get => LocalContext.MaterialNomenclatures; }
        public List<InstrumentNomenclature> InstrumentNomenclatures { get => LocalContext.InstrumentNomenclatures; }

        public List<InstrumnetHeader> InstrumnetHeaders { get => LocalContext.InstrumnetHeaders; }

        RelayCommand _clicUpdateNomenclature;
        public RelayCommand ClicUpdateNomenclature
        {
            get
            {
                if (_clicUpdateNomenclature == null)
                {
                    _clicUpdateNomenclature = new RelayCommand(ExecuteClicUpdateNomenclature, CanExecuteClicUpdateNomenclature);
                }
                return _clicUpdateNomenclature;
            }
        }

        public void ExecuteClicUpdateNomenclature(object parameter)
        {
            if(System.Convert.ToInt32(parameter)==1)
            {
                LocalContext.GetInstrumentNomenclatures();
                OnPropertyChanged("InstrumentNomenclatures");
            }

            if (System.Convert.ToInt32(parameter) == 2)
            {
                LocalContext.GetMaterialNomenclatures();
                OnPropertyChanged("MaterialNomenclatures");
            }

        }
        public bool CanExecuteClicUpdateNomenclature(object parameter)
        {
           
            return true;
        }


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
            if (System.Convert.ToInt32(parameter) == 1)
            {
                var win = new AddNewInstrumentNomenclature{ DataContext = new AddNewInstrumentNomenclatureViewModel() };
                win.ShowDialog();
            }
            if (System.Convert.ToInt32(parameter) == 2)
            {
                var win = new AddNewMaterialNomenclature { DataContext = new AddNewMaterialNomenclatureViewModel() };
                win.ShowDialog();
            }

        }
        public bool CanExecuteClicAddNomenclature(object parameter)
        {

            return true;
        }


        /////////ELementHeaders
        ///
        RelayCommand _clicUpdateElementHeaders;
        public RelayCommand ClicUpdateElementHeaders
        {
            get
            {
                if (_clicUpdateElementHeaders == null)
                {
                    _clicUpdateElementHeaders = new RelayCommand(ExecuteClicUpdateElementHeaders, CanExecuteClicUpdateElementHeaders);
                }
                return _clicUpdateElementHeaders;
            }
        }

        public void ExecuteClicUpdateElementHeaders(object parameter)
        {
            LocalContext.GetInstrumnetHeaders();
            OnPropertyChanged("InstrumnetHeaders");
        }
        public bool CanExecuteClicUpdateElementHeaders(object parameter)
        {

            return true;

        }

        RelayCommand _clicAddInstrumentHeader;
        public RelayCommand ClicAddInstrumentHeader
        {
            get
            {
                if (_clicAddInstrumentHeader == null)
                {
                    _clicAddInstrumentHeader = new RelayCommand(ExecuteClicAddInstrumentHeader, CanExecuteClicAddInstrumentHeader);
                }
                return _clicAddInstrumentHeader;
            }
        }

        public void ExecuteClicAddInstrumentHeader(object parameter)
        {
            var win = new AddNewElementHeaderWindow() { DataContext = new AddNewElementHeaderViewModel(LocalContext)};
            win.ShowDialog();
        }
        public bool CanExecuteClicAddInstrumentHeader(object parameter)
        {

            return true;
        }

    }
}
