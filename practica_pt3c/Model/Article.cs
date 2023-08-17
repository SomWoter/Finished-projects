using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        #region Atributos
        private int idArticle;
        private string nomArticle;
        private string seccioMagatzem;
        private float preuUnitat;
        private int disponibilitat;
        private string origen;
        #endregion

        #region Constructor

        public Article(int idArticle, string nomArticle, string seccioMagatzem, float preuUnitat, int disponibilitat, string origen)
        {
            this.IdArticle = idArticle;
            this.NomArticle = nomArticle;
            this.SeccioMagatzem = seccioMagatzem;
            this.PreuUnitat = preuUnitat;
            this.Disponibilitat = disponibilitat;
            this.Origen = origen;
        }

        public Article()
        {
        }


        #endregion

        #region Getters n Setters
        public int IdArticle { get => idArticle; set => idArticle = value; }
        public string NomArticle { get => nomArticle; set => nomArticle = value; }
        public string SeccioMagatzem { get => seccioMagatzem; set => seccioMagatzem = value; }
        public float PreuUnitat { get => preuUnitat; set => preuUnitat = value; }
        public int Disponibilitat { get => disponibilitat; set => disponibilitat = value; }
        public string Origen { get => origen; set => origen = value; }
        #endregion
    }
}
