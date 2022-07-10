using Sport.Models;
using Sport.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sport.ViewModels
{
    public class VereineViewModel : BaseViewModel
    {
        private Verein _SelectedVerein;
        public ObservableCollection<Verein> Vereine { get; }
        public Command LoadVereineCommand { get; }
        public Command AddVereinCommand { get; }
        public Command<Verein> VereinTapped { get; }

        public VereineViewModel()
        {
            Title = "Vereine";
            Vereine = new ObservableCollection<Verein>();
            LoadVereineCommand = new Command(async () => await ExecuteLoadVereineCommand());

            VereinTapped = new Command<Verein>(OnItemSelected);

            AddVereinCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadVereineCommand()
        {
            IsBusy = true;

            try
            {
                Vereine.Clear();
                var vereine = await VereinStore.GetItemsAsync(true);
                foreach (var verein in vereine)
                {
                    Vereine.Add(verein);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedVerein = null;
        }
        public Verein SelectedVerein
        {
            get => _SelectedVerein;
            set
            {
                SetProperty(ref _SelectedVerein, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(Verein verein)
        {
            if (verein == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VereinDetailPage)}?{nameof(VereinDetailViewModel.Id)}={verein.Id}");
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVereinPage));
        }
    }
}
