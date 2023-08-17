using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Detall
    {
        #region Atributos
        private int idComanda;
        private int idArticle;
        private int quantitat;
        #endregion

        #region Constructores
        public Detall() {
        }

        public Detall( int idComanda, int idArticle, int quantitat)
        {
            this.IdComanda = idComanda;
            this.IdArticle = idArticle;
            this.Quantitat = quantitat;
        }
        #endregion

        #region Getters n Setters

        public int IdComanda { get => idComanda; set => idComanda = value; }
        public int IdArticle { get => idArticle; set => idArticle = value; }
        public int Quantitat { get => quantitat; set => quantitat = value; }
        #endregion
    }
}
