using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionTool
{
    public class Connection : IConnection
    {
        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
            }
        }

        //afin d'éviter de répéter le code de la connection je crée une méthode que j'appel dans mon constructeur
        //pour y créer et y ouvrir ma connection directement
        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnectionString;
            return sqlConnection;
        }

        //afin d'éviter de répeter le code de création de commande j'utiliserai cette méthode
        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = command.Query;
            //pour rappel , si je suis dans le cadre d'un procédure sotckée je doit lui donner le type nécessaire
            if (command.Stored)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            //je vais paracourir mon tableau de paramètre
            //et les ajouter à ma commande
            foreach (KeyValuePair<string, object> kvp in command.Params)
            {
                //je vais avoir besoin d'un objet sqlparameter pour définir le parametre
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value;
                //j'ajoute le parametre à ma sqlcommand
                cmd.Parameters.Add(parameter);
            }
            return cmd;
        }

        public object ExecuteScalar(Command command)
        {

            using (SqlConnection connection = CreateConnection())
            {

                using (SqlCommand cmd = CreateCommand(command, connection))
                {

                    connection.Open();

                    object result = cmd.ExecuteScalar();

                    return (result is DBNull) ? null : result;
                }
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            yield return selector(reader);
                        }

                    }
                }
            }
        }


        public DataTable GetDataTable(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
