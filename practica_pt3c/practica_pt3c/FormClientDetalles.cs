using Controlador;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FormClientDetalles : Form
    {
        private bool bloqueandoEvento = false;
        private Controlador.Controlador controlador = new Controlador.Controlador();
        public FormClientDetalles()
        { 
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            getData();
        }

        private void getData()
        {
            DataSet ds = new DataSet();
            ds = controlador.getTel();
            DataSet ds2 = new DataSet();
            ds2 = controlador.getName();

            listBox1.DataSource = ds2.Tables[0];
            listBox1.DisplayMember = "nomClient";
            
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "telèfon";
        }
        private void nombreSeleccionado_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DataRowView nameSelected = (DataRowView)listBox1.SelectedItem;
            string name = nameSelected.Row[0].ToString();



            ds = controlador.getComandaByName(name);
            try
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (IndexOutOfRangeException x)
            {
                Console.WriteLine(x.Message);
            }
            dataGridView1.DefaultCellStyle.BackColor = Color.Black;
        }


        private void telSeleccionado_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DataRowView telSelected = (DataRowView)comboBox1.SelectedItem;
            string tel = telSelected.Row.ItemArray[0].ToString();

            ds = controlador.getComandaByTel(tel);
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.EndEdit();
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.Cells["nomClient"].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }
    }
}
