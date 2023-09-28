using PipApp.ViewModels;

namespace PipApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(VModelLogin vModel)
        {
            BindingContext = vModel;
            InitializeComponent();
        }
    }
}