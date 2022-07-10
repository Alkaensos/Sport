using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sport.Models;
using Sport.Services;
using Xamarin.Forms;
using SQLite;

namespace Sport.ViewModels
{
    public class NewVereinViewModel : BaseViewModel
    {
        private string name;
        private int teilnehmer;

        public NewVereinViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Teilnehmer
        {
            get { return teilnehmer; }
            set { teilnehmer = value; }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Verein newVerein = new Verein()
            {
                Name = Name,
                Teilnehmer = Teilnehmer
            };
            await VereinStore.AddItemAsync(newVerein);
            await Shell.Current.GoToAsync("..");
        }

    }
}