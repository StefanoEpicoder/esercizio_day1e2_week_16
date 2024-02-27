using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class pagamenti
    {
        public string Periodo { get; set; }

        public decimal Ammontare { get; set; }

        public bool Stipendio { get; set; }

        public bool Acconto { get; set; }

        public int idDipendente { get; set; }

        public pagamenti(string Periodo, decimal Ammontare, bool Stipendio, bool Acconto, int idDipendente)
        {
            this.Periodo = Periodo;
            this.Ammontare = Ammontare;
            this.Stipendio = Stipendio;
            this.Acconto = Acconto;
            this.idDipendente = idDipendente;
        }
    }
}