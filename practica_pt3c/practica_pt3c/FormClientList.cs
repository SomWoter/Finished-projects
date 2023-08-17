using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using static Vista.listViewItemComparer;

namespace Vista
{
    public partial class FormClientList : Form
    {
        private Controlador.Controlador controlador;
        private listViewItemComparer listViewComparer;
        public FormClientList()
        {
            InitializeComponent();
            listViewComparer = new listViewItemComparer();
            controlador = new Controlador.Controlador();
            getDataForListView();
        }


        /// <summary>
        /// Asigna las columnas necesarias al ListView y rellena con datos del DataSet llenado en el ClientDao
        /// </summary>
        private void getDataForListView()
        {
            DataSet ds = new DataSet();
            ds = controlador.getAll();

            listView1.Columns.Add("", 1);
            //listView1.Columns.Add("idClient");
            listView1.Columns.Add("nomClient", 150);
            listView1.Columns.Add("adreça", 150);
            listView1.Columns.Add("població", 150);
            listView1.Columns.Add("telèfon", 150);
            listView1.Columns.Add("emailContacte", 180);

            // Recorre cada una de las filas del DataSet

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                // Crea un nuevo ListViewItem para esta fila
                ListViewItem item = new ListViewItem();

                // Agrega las demás columnas de la fila al ListViewItem
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                // Agrega el ListViewItem al ListView
                listView1.Items.Add(item);
            }
        }


        // Ordena las líneas de la tabla al hacer click en una cabecera de cualquier columna.
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listViewComparer.col)
            {
                if (listViewComparer.order == SortOrder.Ascending)
                {
                    listViewComparer.order = SortOrder.Descending;
                }
                else
                {
                    listViewComparer.order = SortOrder.Ascending;
                }
            }
            else
            {
                listViewComparer.col = e.Column;
                listViewComparer.order = SortOrder.Ascending;
            }
            listView1.ListViewItemSorter = listViewComparer;
            listView1.Sort();
        }
    }
}
