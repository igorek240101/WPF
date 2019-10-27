using AticaRevisorPcManager.Model;
using AticaRevisorPcManager.Repository;
using AticaRevisorPcManager.Service;
using AticaRevisorPcManager.ViewModel.Base;
using AticaRevisorPcManager.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AticaRevisorPcManager.ViewModel
{
    class OneElementInstrumentWindowViewModel:ViewModelBase
    {
        public OneElementInstrumentWindowViewModel(ElementInstrumentToUpload elementInstrumentToUpload   )
        {
            ElementInstrumentToUpload = elementInstrumentToUpload;
            IsEnabled = true;
        }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled;set { isEnabled = value;OnPropertyChanged("IsEnabled"); } }

        public ServerRepository CompressionServer { get; set; }

        private ElementInstrumentToUpload elementInstrument;
        public ElementInstrumentToUpload ElementInstrumentToUpload { get => elementInstrument; set { elementInstrument = value;OnPropertyChanged("ElementInstrumentToUpload"); } }

        private string sourceImage;
        public string SourceImage { get => sourceImage;set { sourceImage = value;OnPropertyChanged("SourceImage"); } }

        private string xkey;
        public string Xkey { get => xkey;set { xkey = value;OnPropertyChanged("Xkey"); } }
       
        RelayCommand _clicGetImage;
        public RelayCommand ClicGetImage
        {
            get
            {
                if (_clicGetImage == null)
                {
                    _clicGetImage = new RelayCommand(ExecuteClicGetImage, CanExecuteClicGetImage);
                }
                return _clicGetImage;
            }
        }

        public void ExecuteClicGetImage(object parameter)
        { 
          byte[] image=  ServerRepository.GetImage(ElementInstrumentToUpload.Id);
            if(image==null||image.Length==0)
            {
                MessageBox.Show("Фото не обнаружено");
            }
             
            else
            {
                SourceImage = CompressionService.Decompress(image, ElementInstrumentToUpload.Id);
            }
            


        }
        public bool CanExecuteClicGetImage(object parameter)
        {
            return true;
        }




        RelayCommand _clicAddToELementHeader;
        public RelayCommand ClicAddToELementHeader
        {
            get
            {
                if (_clicAddToELementHeader == null)
                {
                    _clicAddToELementHeader = new RelayCommand(ExecuteClicAddToELementHeader, CanExecuteClicAddToELementHeader);
                }
                return _clicAddToELementHeader;
            }
        }

        public void ExecuteClicAddToELementHeader(object parameter)
        {
            if (ServerRepository.PostNewElementHeader(ElementInstrumentToUpload.Id, ElementInstrumentToUpload.Nomenclature.Id, Xkey))
            {
                MessageBox.Show("Новый известный элемент добавлен. Обновите данные");
                IsEnabled = false;
            }


        }
        public bool CanExecuteClicAddToELementHeader(object parameter)
        {
            if(Xkey!=null)
          if(Xkey.Length>1)  return true;
            return false;
        }
    }
}
