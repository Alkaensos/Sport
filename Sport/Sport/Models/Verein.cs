using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sport.Models
{
    public class Verein
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Leiter { get; set; }
        public int Teilnehmer { get; set; }
    }
}
