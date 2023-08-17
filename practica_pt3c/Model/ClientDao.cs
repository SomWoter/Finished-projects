using MySql.Data.MySqlClient;
using System.Data;

namespace Model
{
    public class ClientDao
    {
        private DbConnect dbConnect;
        private MySqlConnection con;
        // Es un archivo donde se guarda las credenciales del cliente que inició sesión con la casilla de "guardar contraseña" marcada.
        private string filePath = "./password_saved.txt";

        public ClientDao()
        {
            dbConnect = DbConnect.getInstance();
        }


        // recibe las credenciales y si el cliente no existe no puede iniciar sesión
        public Client validar(string name, string pwd)
        {
            Client client = null;

            String query = "SELECT * FROM clients WHERE nomClient = @name AND cognoms = @pwd";
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", name));
                        cmd.Parameters.Add(new MySqlParameter("@pwd", pwd));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    client = new Client(reader["nomClient"].ToString(), reader["cognoms"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error en el login: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el loging" + error2.Message);
            }
            return client;
        }

        // busca las comandas del nombre del cliente que recibe como parametro
        public DataSet getCommandaByName(string name)
        {
            String query = "SELECT c.nomClient, o.dataComanda, o.formaPagament, o.descompte, o.enviat FROM clients c JOIN comandes o ON c.idClient = o.idClient WHERE c.nomClient = @name ;";

            DataSet ds = new DataSet();
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", name));

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getCommanda()" + e.Message);
            }
            return ds;
        }

        // Hago una consulta para obtener los articulos el precio cantidad y el precio total del pedido recibiendo solo el id de la comanda

        public DataSet getArticles(int idComanda)
        {
            DataSet sd = new DataSet();
            string query = "SELECT articles.nomArticle, detalls.quantitat , articles.preuUnitat, (detalls.quantitat * articles.preuUnitat) as 'Precio Total' FROM articles JOIN detalls ON articles.idArticle = detalls.idArticle WHERE idComanda = @idComanda;";

            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@idComanda", idComanda));

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(sd);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getArticles" + e.Message);
            }
            
            
            return sd;
        }

        // recibe el tel como parametro y busca las comandas del cliente que tiene dicho tel
        public DataSet getCommandaByTel( string tel)
        {
            String query = "SELECT c.nomClient, o.dataComanda, o.formaPagament, o.descompte, o.enviat FROM clients c JOIN comandes o ON c.idClient = o.idClient WHERE c.telèfon = @tel ;";

            DataSet ds = new DataSet();
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@tel", tel));

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getCommanda()" + e.Message);
            }
            return ds;
        }


        // recibe las credenciales y las guarda
        public void savePass(string name, string pwd) {
           // string filePath = "./password_saved.txt";
            string separador = "/";

            // Guardo contraseña
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(name + separador + pwd);
            }
        }

        // Leo las credenciales guardadas y las devuelvo
        // En el archivo, las credenciales están separadas por un "/" por lo tanto uso el split para guardarlas en una array
        public string[] loadUser() {
            string[] words = { "", ""};
            try
            {
                StreamReader reader = new StreamReader(filePath);
                string line = reader.ReadLine();
                words = line.Split('/');
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return words;
        }


        // devuelve en un DataSet casi todos los datos de los clientes
        public DataSet getAll()
        {
            String query = "SELECT nomClient, adreça, població, telèfon, emailContacte FROM clients;";
            DataSet ds = new DataSet();

            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand= cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getAll()" + e.Message);
            }
            return ds;
        
        }


        // Recibe nombres de la base de datos y los retorna en DataSet
        public DataSet getName()
        {
            String query = "SELECT nomClient FROM clients;";
            DataSet ds = new DataSet();

            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getName()" + e.Message);
            }
            return ds;
        }

        // Recibe telefonos de la base de datos y los retorna en DataSet
        public DataSet getTel()
        {
            String query = "SELECT telèfon FROM clients;";
            DataSet ds = new DataSet();

            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en clientDao.getTel()" + e.Message);
            }
            return ds;
        }


        // Recibe id de las comandas y el nombre de los clientes y los retorna en DataSet
        public DataSet getCommandsAndClients()
        {
            String query = "SELECT clients.nomClient, comandes.idComanda FROM clients JOIN comandes ON clients.idClient = comandes.IdClient;";
            DataSet ds = new DataSet();

            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand= cmd;
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en el método clientDao.getCommandsAndClients()" + e.Message);
            }
            return ds;
        }
    }
}
