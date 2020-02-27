
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel() {
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

        public async Task DisplayAlert(string title, string message, string cancel = "Ok") {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel) {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }


        // A PARTIR DAQUI COPIEI O CÓDIGO DO LUIS. SÓ ELE E DEUS SABEM EXATAMENTE COMO ISSO FUNCIONA

        private Type GetTypeByViewModel<TViewModel>() where TViewModel : BaseViewModel {
            var pastaview = "Views";
            var sufixoview = "Page";
            var pastaviewmodels = "ViewModels";
            var sufixoviewmodels = "ViewModel";

            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.FullName;
            var name = viewModelTypeName.Replace(pastaviewmodels, pastaview)
                                        .Replace(sufixoviewmodels, sufixoview);

            return Type.GetType(name);
        }
       
        public async Task PushModalAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel {
            var viewType = GetTypeByViewModel<TViewModel>();

            try {
                var page = Activator.CreateInstance(viewType, args) as Page;

                INavigation navigation;

                // se master detail ou navegação simples
                if (Application.Current.MainPage is MasterDetailPage masterDetailPage) {
                    navigation = masterDetailPage.Detail.Navigation;
                } else {
                    navigation = Application.Current.MainPage.Navigation;
                }

                // se navigationpage instanciada ou ainda não
                if (navigation is NavigationPage) {
                    await navigation.PushModalAsync(page);
                } else {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel {
            var viewType = GetTypeByViewModel<TViewModel>();
            try {
                var page = Activator.CreateInstance(viewType, args) as Page;

                INavigation navigation;

                // se master detail ou navegação simples
                if (Application.Current.MainPage is MasterDetailPage masterDetailPage) {
                    navigation = masterDetailPage.Detail.Navigation;
                } else {
                    navigation = Application.Current.MainPage.Navigation;
                }

                // se navigationpage instanciada ou ainda não
                if (navigation is NavigationPage) {
                    await navigation.PushAsync(page);
                } else {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task PopAsync() {
            if (Application.Current.MainPage is MasterDetailPage _page) {
                await _page.Detail.Navigation.PopAsync();
            } else {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async Task PopModalAsync() {
            if (Application.Current.MainPage is MasterDetailPage _page) {
                await _page.Detail.Navigation.PopModalAsync();
            } else {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }

    }
}
