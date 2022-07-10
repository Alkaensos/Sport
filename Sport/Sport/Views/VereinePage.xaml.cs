using Sport.ViewModels;
using Sport.Models;
using Sport.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sport.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VereinePage : ContentPage
    {
        VereineViewModel _VereineViewModel;
        public VereinePage()
        {
            InitializeComponent();

            BindingContext = _VereineViewModel = new VereineViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _VereineViewModel.OnAppearing();
        }
    }
}