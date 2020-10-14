using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Model
{
    public class Departement
    {
        public string nom;
        public int numD;
        public List<Commune> Communes { get; set; }
    }
}