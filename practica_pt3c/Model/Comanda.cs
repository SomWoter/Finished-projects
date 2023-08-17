using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comanda
    {
        #region Atributos
        private int idComanda;
        private int idClient;
        private DateTime dataComanda;
        private string formaPagament;
        private int descompte;
        private Boolean enviat;
        #endregion

        #region Constructor

        public Comanda()
        {
        }
        public Comanda(int idComanda, int idClient, DateTime dataComanda, string formaPagament, int descompte, bool enviat)
        {
            this.IdComanda = idComanda;
            this.IdClient = idClient;
            this.DataComanda = dataComanda;
            this.FormaPagament = formaPagament;
            this.Descompte = descompte;
            this.Enviat = enviat;
        }

        #endregion

        #region Getters n Setters
        public int IdComanda { get => idComanda; set => idComanda = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public DateTime DataComanda { get => dataComanda; set => dataComanda = value; }
        public string FormaPagament { get => formaPagament; set => formaPagament = value; }
        public int Descompte { get => descompte; set => descompte = value; }
        public bool Enviat { get => enviat; set => enviat = value; }
        #endregion
    }
}
