using AticaRevisorPcManager.Context;
using AticaRevisorPcManager.Model;
using AticaRevisorPcManager.Repository;
using AticaRevisorPcManager.Service;
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
    class ListOfObjectsViewModel:ViewModelBase
    {
        public ListOfObjectsViewModel(LocalContext localContext) => LocalContext = localContext;
        public LocalContext LocalContext { get; set; }

        public List<InventoryObject> InventoryObjects { get { if (LocalContext.ListOfObjects != null) return LocalContext.ListOfObjects; return new List<InventoryObject>(); } }

        private InventoryObject selectobject;
        public InventoryObject SelectObject { get => selectobject;set { selectobject = value;OnPropertyChanged("SelectObject"); } }

        RelayCommand _clicGetAllObjects;
        public RelayCommand ClicGetAllObjects
        {
            get
            {
                if (_clicGetAllObjects == null)
                {
                    _clicGetAllObjects = new RelayCommand(ExecuteClicGetAllObjects, CanExecuteClicGetAllObjects);
                }
                return _clicGetAllObjects;
            }
        }

        public void ExecuteClicGetAllObjects(object parameter)
        {
            LocalContext.UpdateListOfObjects();
            OnPropertyChanged("InventoryObjects");
        }
        public bool CanExecuteClicGetAllObjects(object parameter)
        {
            //if (Name.Length == 0 && Number.Length== 0 && Mark.Length == 0 && Model.Length == 0)
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

            LocalContext.SetCurrentInventoryObject(SelectObject.Id);
            ViewModelService.OneInventoryObjectViewModel.Update();
            ViewModelService.MainWindowViewModel.SetOneObject();
        }
        public bool CanExecuteClicSelect(object parameter)
        {
             return true;
      
        }

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
            var window = new AddInventoryObjectWindow() { DataContext = new AddInventoryObjectViewModel() };
            window.ShowDialog();
        }
        public bool CanExecuteClicAddObject(object parameter)
        {
            return true;
        }


    }
}
