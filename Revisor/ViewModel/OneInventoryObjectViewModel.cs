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
    class OneInventoryObjectViewModel:ViewModelBase
    {
        public OneInventoryObjectViewModel(MainWindowViewModel mainWindowViewModel, LocalContext localContext)
        {AllInstruments = true;
            MainWindowViewModel = mainWindowViewModel;
            LocalContext = localContext;
        } 


        MainWindowViewModel MainWindowViewModel { get; set; }
      
        public LocalContext LocalContext { get; set; }

        public InventoryObject InventoryObject { get => LocalContext.CurrentInventoryObject; }

        private HoldInstrument selectedHoldinstrument;
        public HoldInstrument SelectedHoldinstrument  { get => selectedHoldinstrument;set { selectedHoldinstrument = value;OnPropertyChanged("SelectedHoldinstrument"); } }

        private HoldMaterial selectedHoldMaterial;
        public HoldMaterial SelectedHoldMaterial { get => selectedHoldMaterial; set { selectedHoldMaterial = value;OnPropertyChanged("SelectedHoldMaterial"); } }


        private bool allInstruments;
        public bool AllInstruments { get => allInstruments; set { allInstruments = value; OnPropertyChanged("AllInstruments"); OnPropertyChanged("FillterContext"); } }

        private bool onlyNewInstruments;
        public bool OnlyNewInstruments { get => onlyNewInstruments; set { onlyNewInstruments = value; OnPropertyChanged("OnlyNewInstruments"); OnPropertyChanged("FillterContext"); } }

        private bool onlyOldInstruments;
        public bool OnlyOldInstruments { get => onlyOldInstruments; set { onlyOldInstruments = value; OnPropertyChanged("OnlyOldInstruments"); OnPropertyChanged("FillterContext");  } }




        public List<ElementInstrumentToUpload> ElementInstruments { get => LocalContext.ElementInstrumentForConcreteHold; }


        public List<ElementInstrumentToUpload> FillterContext
        {
            get
            {
               
                        if (OnlyOldInstruments) return ElementInstruments.Where(x => x.InstrumnetHeader != null).ToList();
                        if (OnlyNewInstruments) return ElementInstruments.Where(y => y.InstrumnetHeader == null).ToList();

                        return ElementInstruments;
                    
                 
               
            }
        }



        public List<ElementMaterialToUpload> ElementMaterial { get => LocalContext.ElementMaterialForConcreteHold; }


        public List<ElementMaterialToUpload> FillterMaterialContext
        {
            get
            {

                 

                return ElementMaterial;



            }
        }
        private string filter;
        public string Filter { get => filter;set { filter = value;OnPropertyChanged("Filter"); OnPropertyChanged("FillterContext"); } }

        public void Update() => OnPropertyChanged("InventoryObject");

        RelayCommand _clicLoadInstrumnet;
        public RelayCommand ClicLoadInstrumnet
        {
            get
            {
                if (_clicLoadInstrumnet == null)
                {
                    _clicLoadInstrumnet = new RelayCommand(ExecuteClicLoadInstrumnet, CanExecuteClicLoadInstrumnet);
                }
                return _clicLoadInstrumnet;
            }
        }

        public void ExecuteClicLoadInstrumnet(object parameter)
        {

            LocalContext.GetInstruments(SelectedHoldinstrument.Id);
            OnPropertyChanged("FillterContext");
            
        }
        public bool CanExecuteClicLoadInstrumnet(object parameter)
        {
            if(SelectedHoldinstrument!=null) return true;
            return false;
        }


        RelayCommand _clicLoadMaterial;
        public RelayCommand ClicLoadMaterial
        {
            get
            {
                if (_clicLoadMaterial == null)
                {
                    _clicLoadMaterial = new RelayCommand(ExecuteClicLoadMaterial, CanExecuteClicLoadMaterial);
                }
                return _clicLoadMaterial;
            }
        }

        public void ExecuteClicLoadMaterial(object parameter)
        {

            LocalContext.GetMaterials(SelectedHoldMaterial.Id);
            OnPropertyChanged("FillterMaterialContext");

        }
        public bool CanExecuteClicLoadMaterial(object parameter)
        {
              return true;
            
        }



        RelayCommand _clicSelect;
        public RelayCommand ClicSelect
        {
            get
            {
                if (_clicSelect == null)
                {
                    _clicSelect = new RelayCommand(ExecuteClicSelect, CanExecuteClicSelect);
                }
                return _clicSelect;
            }
        }

        public void ExecuteClicSelect(object parameter)
        {
            var win = new OneElementInstrumentWindow() { DataContext = new OneElementInstrumentWindowViewModel((ElementInstrumentToUpload)parameter) };
            win.ShowDialog();
            
        }
        public bool CanExecuteClicSelect(object parameter)
        {
            return true;
        }



        RelayCommand _clicAddInstrumentHold;
        public RelayCommand ClicAddInstrumentHold
        {
            get
            {
                if (_clicAddInstrumentHold == null)
                {
                    _clicAddInstrumentHold = new RelayCommand(ExecuteClicAddInstrumentHold, CanExecuteClicAddInstrumentHold);
                }
                return _clicAddInstrumentHold;
            }
        }

        public void ExecuteClicAddInstrumentHold(object parameter)
        {
            var win = new AddInstrumentHoldWindow() { DataContext = new AddInstrumentHoldViewModel(InventoryObject.Id,MainWindowViewModel) };
            win.ShowDialog();
        }
        public bool CanExecuteClicAddInstrumentHold(object parameter)
        {
            return true;
        }

        RelayCommand _clicAddMaterialHold;
        public RelayCommand ClicAddMaterialHold
        {
            get
            {
                if (_clicAddMaterialHold == null)
                {
                    _clicAddMaterialHold = new RelayCommand(ExecuteClicAddMaterialHold, CanExecuteClicAddMaterialHold);
                }
                return _clicAddMaterialHold;
            }
        }

        public void ExecuteClicAddMaterialHold(object parameter)
        {
            var win = new  AddMaterialHoldWindow () { DataContext = new AddMaterialHoldViewModel(LocalContext.CurrentInventoryObject.Id,MainWindowViewModel) };
            win.ShowDialog();
        }
        public bool CanExecuteClicAddMaterialHold(object parameter)
        {
            return true;
        }
    }
}
