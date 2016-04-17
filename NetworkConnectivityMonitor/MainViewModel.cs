//    THIS SAMPLE CODE IS PROVIDED FOR THE PURPOSE OF ILLUSTRATION ONLY
//    AND IS NOT INTENDED TO BE USED IN A PRODUCTION ENVIRONMENT.

//    THIS SAMPLE CODE AND ANY RELATED INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY
//    OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConnectivityMonitor
{
    public class MainViewModel : INotifyPropertyChanged
    {
    #region public bindable properties 
    #endregion
        private string _connectivityStatus;
        public string ConnectivityStatus
        {
            get { return _connectivityStatus; }
            set { SetProperty(ref _connectivityStatus, value); }
        }


        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }


    #region INotifyPropertyChanged implementation details
    #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
