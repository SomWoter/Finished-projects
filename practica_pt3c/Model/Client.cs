using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Client
    {
        #region Atributos
        private int idClient;
        private string nomClient;
        private string cognoms;
        private string adresa;
        private string poblacio;
        private string telefon;
        private string responsable;
        private string emailContacte;
        #endregion

        #region Constructor

        public Client(string nomClient, string cognoms)
        { 
            this.NomClient = nomClient;
            this.cognoms = cognoms;
        }
        public Client(int idClient, string nomClient, string cognoms, string adresa, string poblacio, string telefon, string responsable, string emailContacte)
        {
            this.IdClient = idClient;
            this.NomClient = nomClient;
            this.Cognoms = cognoms;
            this.Adresa = adresa;
            this.Poblacio = poblacio;
            this.Telefon = telefon;
            this.Responsable = responsable;
            this.EmailContacte = emailContacte;
        }

        public Client(string nomClient, string adresa, string poblacio, string telefon, string emailContacte)
        {
            this.poblacio = poblacio;
            this.telefon = telefon;
            this.emailContacte = emailContacte;
        }

        public Client()
        {
        }


        #endregion

        #region Getters n Setters
        [Key]
        public int IdClient { get => idClient; set => idClient = value; }


        public string NomClient { get => nomClient; set => nomClient = value; }
        public string Cognoms { get => cognoms; set => cognoms = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Poblacio { get => poblacio; set => poblacio = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Responsable { get => responsable; set => responsable = value; }
        public string EmailContacte { get => emailContacte; set => emailContacte = value; }
        #endregion

    }
}