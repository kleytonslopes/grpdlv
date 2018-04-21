using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Nucleo
{
    public class Connection
    {
        private MySqlConnection _connection;

        public void OpenConnection()
        {
            try
            {
                if (_connection != null && _connection.State != ConnectionState.Open)
                    throw new InvalidProgramException($"Conexão já Aberta!");

                _connection = new MySqlConnection("");
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"OpenConnection\" : {Environment.NewLine}{ex.ToString()}");
            }
        }
        public void CloseConnection()
        {
            try
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"CloseConnection\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
