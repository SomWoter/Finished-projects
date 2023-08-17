using Model;
using System.Data;

namespace Controlador
{
    public class Controlador
    {

        private ClientDao dao = new ClientDao();





        public string[] loadUser()
        {
            string[] words = dao.loadUser();

            return words;
        }


        // recibe los datos del usuario y los manda al Modelo
        public bool validar(string name, string pass) {
            Client client = new Client();

            bool found = false;

            client = dao.validar(name, pass);

            if (client != null) found = true;
            return found;
        }

        public void savePass(string name, string pwd)
        {
            dao.savePass(name, pwd);
        }

        public DataSet getAll()
        { 
            return dao.getAll();
        }

        public DataSet getName() {
            return dao.getName();
        }
        public DataSet getTel()
        {
            return dao.getTel();
        }

        public DataSet getComandaByName(string name) {
            return dao.getCommandaByName( name);
        }
        public DataSet getComandaByTel(string tel)
        {
            return dao.getCommandaByTel(tel);
        }

        // Recibe los idComanda y nomClient en un DataSet y lo devuelve
        public DataSet getCommandsAndClients()
        { 
            return dao.getCommandsAndClients();
        }

        // Recibe el idComanda y retorna un DataSet con los datos encontrados
        public DataSet getArticles(int idComanda)
        { 
            return dao.getArticles(idComanda);
        }
    }
}