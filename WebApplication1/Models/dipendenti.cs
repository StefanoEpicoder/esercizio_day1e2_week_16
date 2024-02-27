using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class dipendenti
    {
        public int idDipendente { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Indirizzo { get; set; }

        [Display(Name = "Codice fiscale")]
        public string Codice_fiscale { get; set; }
        
        public bool Coniugato { get; set; }

        public bool Figli { get; set; }

        public string Mansione { get; set; }

        public dipendenti()
        {
        }

        public dipendenti(int idDipendente, string Nome, string Cognome, string Indirizzo, string Codice_fiscale, bool Coniugato, bool Figli, string Mansione)
        {
            this.idDipendente = idDipendente;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Indirizzo = Indirizzo;
            this.Codice_fiscale = Codice_fiscale;
            this.Coniugato = Coniugato;
            this.Figli = Figli;
            this.Mansione = Mansione;
        }

    }
}