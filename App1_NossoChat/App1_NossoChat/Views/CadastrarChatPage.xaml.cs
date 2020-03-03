using App1_NossoChat.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarChatPage : ContentPage {
        public CadastrarChatPage() {
            InitializeComponent();
            BindingContext = new CadastrarChatViewModel();
        }
    }
}