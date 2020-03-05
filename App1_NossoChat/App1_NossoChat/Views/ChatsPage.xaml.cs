using App1_NossoChat.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatsPage : ContentPage {
        public ChatsPage() {
            InitializeComponent();
            BindingContext = new ChatsViewModel();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            (BindingContext as ChatsViewModel).ActionAtualizar();
        }
    }
}