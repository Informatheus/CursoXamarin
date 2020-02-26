
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel {
    public class BaseViewModel : INotifyPropertyChanged {

        //Passa navegar entre páginas será chamado este Navigation.Push/Pop
        INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(INavigation nav) {
            Navigation = nav;
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null) {

            if (EqualityComparer<T>.Default.Equals(storage, value)) {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void DisplayAlert(string title, string message, string cancel = "Ok") {
            Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public bool DisplayAlert(string title, string message, string accept, string cancel) {
            var resp = Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            return resp as Boolean;
        }
    }
}
