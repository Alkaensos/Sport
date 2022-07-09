using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sport.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sport.ViewModels
{
    [QueryProperty(nameof(VereinStore), nameof(Name))]
    public class VereinDetailViewModel : BaseViewModel
    {
        private int id;
        private string name;
        private int Teilnehmer;

        

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int teilnehmer
        {
            get { return Teilnehmer; }
            set { Teilnehmer = value;  }
        }

    }
}