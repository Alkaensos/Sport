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
        private string itemId;
        private string name;
        private string teilnehmer;
        public string Id
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Teilnehmer
        {
            get { return teilnehmer; }
            set { teilnehmer = value;  }
        }

    }
}