using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormComandaLista : Form
    {
        private Controlador.Controlador controlador = new Controlador.Controlador();
        public FormComandaLista()
        {
            InitializeComponent();
            showCommands();
        }


        private void showCommands()
        {
            DataSet ds = new DataSet();
            ds = controlador.getCommandsAndClients();

            listView2.Columns.Add("idComanda", 125);
            listView2.Columns.Add("nomClient",125);

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string[] comandas = { row["idComanda"].ToString(), row["nomClient"].ToString() };
                listView2.Items.Add(new ListViewItem(comandas));
            }
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Vaciar todos los elementos del ListView
            listView1.Items.Clear(); 
            // Vaciar todas las columnas del ListView
            listView1.Columns.Clear();
            // Obtiene el elemento selecccionado
            ListViewItem item = e.Item;

            // Obtiene el nombre del cliente y el id de la comanda
            string idComanda = item.Text;
            string nomClient = item.SubItems[1].Text;

            // Guarda el id de la comanda y el nombre del cliente en variables
            string selectedIdComanda = idComanda;
            string selectedNomClient = nomClient;

            // convierto el string en int
            int id = Int32.Parse(idComanda);


            DataSet ds = new DataSet();
            ds = controlador.getArticles(id);

            // articles.nomArticle, detalls.quantitat , articles.preuUnitat, (detalls.quantitat * articles.preuUnitat) as 'Precio Total'

            listView1.Columns.Add("nomArticle", 132);
            listView1.Columns.Add("quantitat", 132);
            listView1.Columns.Add("preuUnitat", 132);
            listView1.Columns.Add("Precio Total", 129);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string[] articles = { row["nomArticle"].ToString(), row["quantitat"].ToString(), row["preuUnitat"].ToString(), row["Precio Total"].ToString() };
                listView1.Items.Add(new ListViewItem(articles));
            }
        }

      
    }
}
