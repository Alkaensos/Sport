using Sport.Models;
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
        private Verein _SelectedItem;
        public ObservableCollection<Verein> Vereine { get; }
        public Command LoadVereineCommand { get; }

        public VereineViewModel()
        {
            Title = "Vereine";
            Vereine = new ObservableCollection<Verein>();
            LoadVereineCommand = new Command(async () => await ExecuteLoadVereineCommand());
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
    }
}
