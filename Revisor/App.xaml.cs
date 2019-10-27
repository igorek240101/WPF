using AticaRevisorPcManager.Context;
using AticaRevisorPcManager.Repository;
using AticaRevisorPcManager.Service;
using AticaRevisorPcManager.View;
using AticaRevisorPcManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AticaRevisorPcManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        


        protected override void OnStartup(StartupEventArgs e)
        {
           
            LocalContext localContext = new LocalContext();
            ViewModelService.NomenclatureAndElementHeadersViewModel = new NomenclatureAndElementHeadersViewModel(localContext);
            ViewModelService.ListOfObjects = new ListOfObjectsViewModel(localContext);
            ViewModelService.MainWindowViewModel = new MainWindowViewModel();
            ViewModelService.OneInventoryObjectViewModel = new OneInventoryObjectViewModel(ViewModelService.MainWindowViewModel, localContext);
            ViewModelService.ListUsersViewModel = new ListUsersViewModel(localContext);

            ViewService.ListUsers = new ListUsers() { DataContext = ViewModelService.ListUsersViewModel };
            ViewService.NomenclatureAndElementHeadersPage = new NomenclatureAndElementHeadersPage() { DataContext = ViewModelService.NomenclatureAndElementHeadersViewModel };
            ViewService.OneInventoryObject = new OneInventoryObject() { DataContext = ViewModelService.OneInventoryObjectViewModel };
            ViewService.ListOfObjects = new ListOfObjects() { DataContext= ViewModelService.ListOfObjects };


            

            var view = new MainWindow() { DataContext = ViewModelService.MainWindowViewModel };
            ViewModelService.MainWindowViewModel.SetListObjectsView();
            view.Show();
          
        }


    }

     
}
