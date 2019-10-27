using AticaRevisorPcManager.Model;
using AticaRevisorPcManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AticaRevisorPcManager.Context
{
    public class LocalContext
    {


        public List<InventoryObject> ListOfObjects { get; set; }

        public InventoryObject CurrentInventoryObject { get; set; }

        public List<ElementInstrumentToUpload> ElementInstrumentForConcreteHold { get; set; }

        public List<ElementMaterialToUpload> ElementMaterialForConcreteHold { get; set; }

        public List<InstrumentNomenclature> InstrumentNomenclatures { get; set; }

        public List<MaterialNomenclature> MaterialNomenclatures { get; set; }

        public List<InstrumnetHeader> InstrumnetHeaders { get; set; }

        public List<User> Users { get; set; }
        public void UpdateListOfObjects()
        {
            var l = ServerRepository.GetAllInventoryObject();
            if (l != null)
                ListOfObjects = l;
        }

        public void SetCurrentInventoryObject(int id)
        {
            CurrentInventoryObject = ListOfObjects.Find(x => x.Id == id);
        }

        public void GetInstruments(int id1)
        {
            ElementInstrumentForConcreteHold = ServerRepository.GetAllInstumnets(id1);
        }
        public void GetMaterials(int id1)
        {
            ElementMaterialForConcreteHold = ServerRepository.GetAllMaterials(id1);
        }
        public void GetInstrumentNomenclatures()
        {
            InstrumentNomenclatures= ServerRepository.GetInstrumentAllNomenclature();
        }

        public void GetMaterialNomenclatures()
        {
            MaterialNomenclatures = ServerRepository.GetMaterialAllNomenclature();
        }

        public void GetInstrumnetHeaders()
        {
            InstrumnetHeaders = ServerRepository.GetAllInstrumnetHeader();
        }

        public void GetUsers()
        {
            Users = ServerRepository.GetAllUsers();
        }
    }
}
