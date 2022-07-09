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
        public int Id { get; set; }

        private string _name;
        private int _Teilnehmer;
        private int _Leiter;

        public NewVereinViewModel(Verein verein)
        {
            Id = verein.Id;
            _name = verein.Name;
            _Teilnehmer = verein.Teilnehmer;
            _Leiter = verein.Leiter;

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Teilnehmer
        {
            get { return _Teilnehmer; }
            set { _Teilnehmer = value; }
        }

    }
}