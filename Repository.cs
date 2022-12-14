using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDesenvolvedoresEProjetos
{
    public class Repository : DbContext
    {
        private static MySqlConnection _databaseconnection;

        public DbSet<Developer> Developers { get; set; }

        public Repository() : base(GetDbConnection(), false)
        {
            if (Database.CreateIfNotExists())
            {
                Repository repository = this;

                Developer d = new Developer("Estevão", new DateTime(2006, 11, 23), 'P');
                Credential c = new Credential("ers11@aluno.ifnmg.edu.br", "asdf1234", true, true);

                d.Credential = c;
                c.Developer = d;

                repository.Developers.Add(d);
                repository.SaveChanges();
            }
        }

        // Singleton
        public static MySqlConnection GetDbConnection()
        {
            if (_databaseconnection == null)
            {
                String connectionString = ConfigurationManager.ConnectionStrings["ManagementConnectionString"].ConnectionString;
                _databaseconnection = new MySqlConnection(connectionString);
            }
            return _databaseconnection;
        }
    }
}
