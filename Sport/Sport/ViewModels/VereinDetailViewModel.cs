using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sport.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Sport.ViewModels;
using Sport.Services;

namespace Sport.ViewModels
{
    public class VereinDetailViewModel : BaseViewModel
    {
        private string name;
        private int teilnehmer;
        private int vereinId;
        public string Id { get; set; }

        public VereinDetailViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public int VereinId
        {
            get { return vereinId; }
            set 
            {
                vereinId = value;
                LoadVereinId(value);
            }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int Teilnehmer
        {
            get { return teilnehmer; }
            set { teilnehmer = value; }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public async void LoadVereinId(int Id)
        {
            try
            {
                var verein = await VereinStore.GetItemAsync(this.Id);
                VereinId = verein.Id;
                Name = verein.Name;
                Teilnehmer = verein.Teilnehmer;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Verein");
            }
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Verein UpdateVerein = new Verein()
            {
                Name = Name,
                Teilnehmer = Teilnehmer
            };
            await VereinStore.UpdateItemAsync(UpdateVerein);
            await Shell.Current.GoToAsync("..");
        }
    }
}