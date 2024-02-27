using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class dipendentiController : Controller
    {
        // Questo metodo viene chiamato quando si accede alla pagina principale dei dipendenti
        public ActionResult Index()
        {
            // Recupera la stringa di connessione dal file di configurazione
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            // Crea una nuova connessione SQL
            SqlConnection conn = new SqlConnection(connectionString);
            // Crea un nuovo comando SQL per selezionare tutti i dipendenti
            SqlCommand cmd = new SqlCommand("SELECT * FROM dipendenti", conn);

            // Crea una nuova lista di dipendenti
            List<dipendenti> dipendentiList = new List<dipendenti>();

            try
            {
                // Apre la connessione SQL
                conn.Open();

                // Esegue il comando SQL e ottiene i risultati
                SqlDataReader reader = cmd.ExecuteReader();
                // Continua a leggere i risultati finché ce ne sono
                while (reader.Read())
                {
                    // Crea un nuovo dipendente con i dati letti
                    dipendenti dipendente = new dipendenti(
                    Convert.ToInt32(reader["idDipendente"]),
                    reader["Nome"].ToString(),
                    reader["Cognome"].ToString(),
                    reader["Indirizzo"].ToString(),
                    reader["Codice_fiscale"].ToString(),
                    Convert.ToBoolean(reader["Coniugato"]),
                    Convert.ToBoolean(reader["Figli"]),
                    reader["Mansione"].ToString());
                    // Aggiunge il dipendente alla lista
                    dipendentiList.Add(dipendente);
                }
            }
            catch (Exception ex)
            {
                // Se c'è un errore, scrive "Errore" e il messaggio dell'errore
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                // Chiude la connessione SQL
                conn.Close();
            }
            // Restituisce la vista con la lista di dipendenti
            return View(dipendentiList);
        }



        /// Questo metodo viene chiamato quando si accede alla pagina per creare un nuovo dipendente
        public ActionResult Create()
        {
            return View();
        }

        // Questo metodo viene chiamato quando si invia il form per creare un nuovo dipendente
        [HttpPost]
        public ActionResult Create(dipendenti dipendente)
        {
            // Recupera la stringa di connessione dal file di configurazione
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            // Crea una nuova connessione SQL
            SqlConnection conn = new SqlConnection(connectionString);
            // Crea un nuovo comando SQL per inserire un dipendente
            SqlCommand cmd = new SqlCommand("INSERT INTO dipendenti (Nome, Cognome, Indirizzo, Codice_fiscale, Coniugato, Figli, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @Codice_fiscale, @Coniugato, @Figli, @Mansione)", conn);
            // Imposta i parametri del comando SQL con i dati del dipendente
            cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
            cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
            cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
            cmd.Parameters.AddWithValue("@Codice_fiscale", dipendente.Codice_fiscale);
            cmd.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
            cmd.Parameters.AddWithValue("@Figli", dipendente.Figli);
            cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
            try
            {
                // Apre la connessione SQL
                conn.Open();
                // Esegue il comando SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Se c'è un errore, scrive "Errore" e il messaggio dell'errore
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                // Chiude la connessione SQL
                conn.Close();
            }
            // Reindirizza l'utente alla pagina principale dei dipendenti
            return RedirectToAction("Index");
        }
    }
}





