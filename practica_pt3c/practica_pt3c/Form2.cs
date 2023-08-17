
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista;

namespace practica_pt3c
{
    
    public partial class Form2 : Form
    {
        FormClientList formClientList;
        FormClientDetalles formClientDetalles;
        FormComandaLista formComandaLista;
        public string username = "";
        public Form2()
        {
            InitializeComponent();
            lbUsername.Text = username ;
            // Con esto el Form2 cogerá todas las pulsaciones (así las combinaciones de teclas funcionarán desde cualquier lugar)
            KeyPreview = true;
            shortCutsMessages();
        }


        // Método que recibe como parametro el nombre del usuario que inició sesión y lo asigna como texto para el Label
        public void connectedAs(string connectedAs)
        {
            username = connectedAs;
            lbUsername.Text = username ;
        }


        
        private void Form2_Leave(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
        }

        // cierra el formulario
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // minimiza el formulario
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Sí el submenú es visible lo esconde
        private void hideSubMenu()
        {
            if (panelSubmenuClientes.Visible)
                panelSubmenuClientes.Visible = false;
            if(panelSubmenuComandas.Visible)
                panelSubmenuComandas.Visible = false;
        }

        // muestra el submenú y si ya está mostrado lo esconde
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        // el btnClientes abre su submenú
        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubmenuClientes);
        }

        // acciones de botones del submenú del botón Clientes
        #region Clientes_Submenu
        private void btnSubMenuClientesLista_Click(object sender, EventArgs e)
        {
            hideSubMenu();


          
            // TODO
            formClientList = new FormClientList();
            addForm(formClientList);
        }

        private void btnSubMenuClientesDetalles_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            //TODO
            formClientDetalles = new FormClientDetalles();
            addForm(formClientDetalles);
        }

        #endregion

        // el btnComandas abre su submenú
        private void btnComandas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubmenuComandas);
        }

        #region Comandas_Submenu
        private void btnSubMenuComandasLista_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            formComandaLista = new FormComandaLista();
            addForm(formComandaLista);
        }
        #endregion

        // botón de cerrar sesión muestra un MessageBox para avisar de que se cerrará el formulario
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            DialogResult res = MessageBox.Show("Estás seguro que quieres salir ?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // abre nuevo folmulario y borra los existentes dentro del panelPadre (se utiliza en la acción de los botones)
        public void addForm(Form form)
        {
            if (this.panelPadre.Controls.Count>0)
            {
                this.panelPadre.Controls.RemoveAt(0);
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelPadre.Controls.Add(form);
            form.Show();
        }

        // mensages al mantener el ratón encima de los botones para ver los atajos
        public void shortCutsMessages() 
        {
            // Crea un objeto ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Establece la propiedad IsBalloon en true para que se muestre la descripción en una "burbuja" al mover el ratón sobre el botón
            toolTip1.IsBalloon = true;

            // Establece el texto de la descripción en la propiedad Text del objeto ToolTip
            toolTip1.SetToolTip(btnSubMenuClientesLista, "Ctrl + l");
            toolTip1.SetToolTip(btnSubMenuClientesDetalles, "Ctrl + d");
            toolTip1.SetToolTip(btnSubMenuComandasLista, "Alt + l");


        }

        /// <summary>
        /// Detecta las teclas presionadas y ejecuta el botón correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + L para Listar CLientes
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.L))
            {
                btnSubMenuClientesLista_Click(sender, e);
            }

            // Ctrl + D para DETALLES CLientes
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.D))
            {
                btnSubMenuClientesDetalles_Click(sender, e);
            }

            // Alt + L para Listar Comandas

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.L))
            {
                btnSubMenuComandasLista_Click(sender, e);
            }
        }


        #region Iconos de navegación rápida
        private void btnIconList_Click(object sender, EventArgs e)
        {
            btnSubMenuClientesLista_Click(sender, e);
        }

        private void btnIconDetails_Click(object sender, EventArgs e)
        {
            btnSubMenuClientesDetalles_Click(sender, e);
        }

        private void btnIconCommands_Click(object sender, EventArgs e)
        {
            btnSubMenuComandasLista_Click(sender, e);
        }
        #endregion
    }
}
