using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LearningBox.Data.Models;

namespace LearningBox.Data.ViewModels
{
    public class BoxViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Box> _boxs ;

        public ObservableCollection<Box> boxs
        {
            get { return _boxs; }
            set
            {
                //_Name = value;

                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this , new PropertyChangedEventArgs(caller));
            }
        }
    }
}
