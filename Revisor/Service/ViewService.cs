using AticaRevisorPcManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AticaRevisorPcManager.Service
{
  public class ViewService
    {
      public  static ListOfObjects ListOfObjects { get; set; }
        public static OneInventoryObject OneInventoryObject { get; set; }
        public static NomenclatureAndElementHeadersPage NomenclatureAndElementHeadersPage { get; set; }
        public static ListUsers ListUsers { get; set; }
    }
}
