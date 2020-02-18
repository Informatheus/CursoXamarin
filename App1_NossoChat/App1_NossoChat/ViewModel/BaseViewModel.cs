using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1_NossoChat.ViewModel {
    class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged(String PropertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
