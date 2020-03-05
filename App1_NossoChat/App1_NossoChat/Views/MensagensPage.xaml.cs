using App1_NossoChat.Models;
using App1_NossoChat.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MensagensPage : ContentPage {
        public MensagensPage(Chat chat) {
            InitializeComponent();

            Title = chat.nome;

            BindingContext = new MensagensViewModel(chat);

        }

    }
}