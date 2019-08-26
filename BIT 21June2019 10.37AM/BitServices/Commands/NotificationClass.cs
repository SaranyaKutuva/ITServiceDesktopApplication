using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BitServices.Commands
{
    public class NotificationClass : INotifyPropertyChanged // When a grid is changed it raises an event
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged(string propertyName)
        {
            if(propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          
            }
        }
    }
}
