using AticaRevisorPcManager.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
 

namespace AticaRevisorPcManager.Repository
{
  public  class ServerRepository
    {
        static HttpClient client = new HttpClient();
       
        public static List<InventoryObject>GetAllInventoryObject()
        {
            try
            {
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/InventoryObjects/GetAllInventoryObject"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {

                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();

                    List<InventoryObject> inventoryObjects = JsonConvert.DeserializeObject<List<InventoryObject>>(ooop.Result);


                    MessageBox.Show("Получен актуальный список объектов");
                    return inventoryObjects;
                    
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }


        public static List<InstrumentNomenclature> GetInstrumentAllNomenclature()
        {
            try
            {
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetAllInstrumentNomenclature"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {

                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();

                    List<InstrumentNomenclature> nomenclatures = JsonConvert.DeserializeObject<List<InstrumentNomenclature>>(ooop.Result);


                    MessageBox.Show("Получен актуальный список номенклатуры");
                    return nomenclatures;

                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }



        public static List<MaterialNomenclature> GetMaterialAllNomenclature()
        {
            try
            {
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetAllMaterialNomenclature"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {

                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();

                    List<MaterialNomenclature> nomenclatures = JsonConvert.DeserializeObject<List<MaterialNomenclature>>(ooop.Result);
 
                    MessageBox.Show("Получен актуальный список номенклатуры материала");
                    return nomenclatures;

                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }





        public static List<ElementInstrumentToUpload> GetAllInstumnets(int id1)
        {
            try
            {
              //  http://127.0.0.1:52366/api/InventoryObjects/1/2
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetInstruments/{id1}"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();
                    List<ElementInstrumentToUpload> inventoryObjects = JsonConvert.DeserializeObject<List<ElementInstrumentToUpload>>(ooop.Result);
                     return inventoryObjects;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }

        public static List<User> GetAllUsers ()
        {
            try
            {
                //  http://127.0.0.1:52366/api/InventoryObjects/1/2
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetUsers"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();
                    List<User> inventoryObjects = JsonConvert.DeserializeObject<List<User>>(ooop.Result);
                    return inventoryObjects;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }



        public static List<ElementMaterialToUpload> GetAllMaterials(int id1)
        {
            try
            {
                //  http://127.0.0.1:52366/api/InventoryObjects/1/2
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetMaterials/{id1}"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();
                    List<ElementMaterialToUpload> inventoryObjects = JsonConvert.DeserializeObject<List<ElementMaterialToUpload>>(ooop.Result);
                    return inventoryObjects;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }






        public static List<InstrumnetHeader> GetAllInstrumnetHeader( )
        {
            try
            {
                //  http://127.0.0.1:52366/api/InventoryObjects/1/2
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetAllInstrumentHeader"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();
                    List<InstrumnetHeader> instrumnetHeaders = JsonConvert.DeserializeObject<List<InstrumnetHeader>>(ooop.Result);
                    return instrumnetHeaders;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }

        public static byte[] GetImage(int id )
        {
            try
            { 
                Task<HttpResponseMessage> task = client.GetAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/GetImage/{id}"));

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {

                    var ooop = task.Result.Content.ReadAsStringAsync();
                    ooop.Wait();

                    byte[] imagebytes = JsonConvert.DeserializeObject<byte[]>(ooop.Result);
                    return imagebytes;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return null;
            }
            return null;
        }



        public static bool PostHoldInstrument(int id,string s)
        {
            try
            {
                string json = JsonConvert.SerializeObject(s);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/InventoryObjects/PostNewInstrumentHold/{id}"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;
                   
                }return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }


        public static bool PostHoldMaterial(int id, string s)
        {
            try
            {
                string json = JsonConvert.SerializeObject(s);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/InventoryObjects/PostNewMaterialHold/{id}"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }





        public static bool PostNewInventoryObject( string s)
        {
            try
            {
                string json = JsonConvert.SerializeObject(s);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/InventoryObjects/AddNewObject"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }

        public static bool PostNewInstrumentNomenclature(string s)
        {
            try
            {
                string json = JsonConvert.SerializeObject(s);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/AddNewInstrumentNomeclature"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }


        public static bool PostNewMaterialNomenclature(string s, string d)
        {
            try
            {
                string[] op= new string[2] { s, d };
                string json = JsonConvert.SerializeObject(op);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/AddNewMaterialNomeclature"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }




        public static bool PostNewElementHeader(int id1, int id2, string s)
        {
            try
            {
                string json = JsonConvert.SerializeObject(s);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/AddNewElementHeader/{id1}/{id2}"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }

        public static bool PostNewElementUser(  string s1, string s2)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new string[2] { s1,s2});

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(new Uri($"http://alfack1997-001-site1.itempurl.com/api/Transaction/AddNewUser"), content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                {
                    return true;

                }
                return false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка при соеденении с сервером");
                return false;
            }
            return false;
        }


    }
}
