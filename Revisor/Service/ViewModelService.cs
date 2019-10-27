using AticaRevisorPcManager.View;
using AticaRevisorPcManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AticaRevisorPcManager.Service
{
    class ViewModelService
    {
        public static MainWindowViewModel MainWindowViewModel { get; set; }
        public static  ListOfObjectsViewModel ListOfObjects { get; set; }
        public static OneInventoryObjectViewModel OneInventoryObjectViewModel { get; set; }

        public static NomenclatureAndElementHeadersViewModel NomenclatureAndElementHeadersViewModel { get; set; }

        public static ListUsersViewModel ListUsersViewModel { get; set; }
    }
}
