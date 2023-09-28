using PipApp.ViewModels;

namespace PipApp.Views
{
    public partial class MainPage : ContentPage
    { 
        public MainPage(VModelMain viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}