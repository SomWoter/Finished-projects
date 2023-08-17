using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore;

namespace Model
{
    internal  class DbConnect
    {
        private static string connectionString = "Server=localhost;Database=storepokemon;Uid=root;Pwd=;";//cal ficar com a Uid i Pwd un usuari donat d'alta a la base de dades amb permissos restringits
        private static DbConnect instance;
        private static MySqlConnection con;

        private DbConnect()
        { }

        public static DbConnect getInstance()
        {
            if (instance == null)
            {
                instance = new DbConnect();
            }
            return instance;
        }

        public MySqlConnection getConnection()
        {
            con = null;
            try
            {
                using (con = new MySqlConnection(connectionString)) ;

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error en la getConnection() " + e.Message);
            }
            return con;
        }

    }

}