using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AticaRevisorPcManager.Service
{
  public  class CompressionService
    {
        public static string Decompress(byte[] mas, int id)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + $@"\Images\{id}.kek";
            Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + @"\Images");
            try
            {

            

            using (MemoryStream ms= new MemoryStream(mas) )
            {
               
                using (FileStream decompressedFileStream = File.Create(path))
                {
                    using (GZipStream decompressionStream = new GZipStream(ms, CompressionMode.Decompress))
                    {
                        // for(int i=0;i<3;i++)
                       decompressionStream.CopyTo(decompressedFileStream);
                         
                    }
                }
            }
            }
            catch(Exception x) { MessageBox.Show("Ошибка разархивирования фото"); }
            return path;

        } 
    }
        }
 
