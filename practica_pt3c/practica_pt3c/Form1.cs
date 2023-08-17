using System.Runtime.InteropServices;
using Model;

namespace practica_pt3c
{
    public partial class Form1 : Form
    {
        private Controlador.Controlador control = new Controlador.Controlador();
        private ClientDao clientDao;
        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            clientDao = new ClientDao();
            loadUser();
        }
        #region EXTRA 
        // Código necesario para arrastrar un Formulario sin bordes
        // https://www.youtube.com/watch?v=en_eqatpDEo&t=3s
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion



        public void btnlogin_Click(object sender, EventArgs e)
        {
            // Al apretar el botón escondo los mensajes de error que pueden estar mostrándose por culpa de un previo uso del botón
            msgError("Correcto", false);
            string clientName = txtuser.Text;
            string clientPass = txtpass.Text;

            if (txtuser.Text == "" || txtpass.Text == "")
            {
                msgError("Todos los campos son obligatorios", true);
            }
            else
            {
                msgError("",  false);

                // compruebo usuario
                bool validar = control.validar(clientName, clientPass);
                if (validar)
                {
                    // conectado como "clientNamE"
                    form2.connectedAs(clientName);
                    openApp();
                    // si el checkbox está activado, guardo las credenciales
                    if (chbxGuardar.Checked)
                    {
                        control.savePass(clientName, clientPass);
                    }
                    else
                    {
                        control.savePass("", "");
                    }
                }
                else
                {
                    msgError("Credenciales incorrectas.", true);
                }
            }
        }


        // carga el usuario guardado previamente
        public void loadUser() 
        {
            string[] words = control.loadUser();
            txtuser.Text = words[0];
            txtpass.Text = words[1];
        }
        
        /// <summary>
        /// Abre el Formulario 2 (la aplicación en sí) si el usuario es correcto
        /// </summary>
        public void openApp() 
        {
            if (form2.ShowDialog() == DialogResult.OK)
            {
                form2.ShowDialog();
                this.Hide();
            }
        }
        public void msgError(string msg, Boolean visible) 
        {
            msgError1.Text = msg;
            msgError1.Visible = visible;
            iconError1.Visible = visible;
        }




        /// <summary>
        /// Si  activas el checkBox muestra la contraseña 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxMostrar.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {

                txtpass.UseSystemPasswordChar = true;
            }
        }


        #region Botones CERRAR/MINIMIZAR
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        #endregion

        #region Capture Mouse Movement
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            panelSettings.Visible = false;
        }

        // detecta si el haces click en otro lugar para poder cerrar los "settings" ( icono engranaje )
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            panelSettings.Visible = false;
        }

        #endregion

        /// <summary>
        /// Por defecto el menú de Settings está escondido, al hacer click en el engranaje mostrará 1 opción que es la de volver transparente o no el Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible)
            {
                panelSettings.Visible = false;
            }
            else
            {
                panelSettings.Visible = true;
            }
            
        }

        /// <summary>
        /// Por defecto está en Transparente (valor: 80%), si le haces click el Form1 se vuelve completamente OPACO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransparent_Click(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                this.Opacity = 0.85;
                btnTransparent.Text = "Transparente";
            }
            else
            {
                this.Opacity = 1;
                btnTransparent.Text = "Opaco";
            }
        }

    }
}