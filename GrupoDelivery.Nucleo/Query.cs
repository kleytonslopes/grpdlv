using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Nucleo
{
    public class Query
    {
        private String _query;
        private MySqlConnection _connection;
        private MySqlTransaction _transaction;
        private Dictionary<String, Object> _parameters;

        public Query(Connection connection)
        {
            _connection = connection.GetConnection();
        }

        public String AddQuery(String sql)
        {
            return _query += sql;
        }

        public Dictionary<String, Object> AddParam(String key, Object value)
        {
            try
            {
                if (_parameters == null)
                    _parameters = new Dictionary<String, Object>();

                _parameters.Add(key, value);

                return _parameters;
            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"AddParam\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

        public void Execute()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw new InvalidProgramException($"A Conexão não estava Aberta!");

                MySqlCommand _command = new MySqlCommand();
                _command.Connection = _connection;
                _command.Transaction = _transaction;

                if (_parameters != null && _parameters.Any())
                    foreach (var p in _parameters)
                        _command.Parameters.AddWithValue(p.Key, p.Value);

                _command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"Execute\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

        public DataTable ExecuteSelect()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw new InvalidProgramException($"A Conexão não estava Aberta!");

                MySqlCommand _command = new MySqlCommand();
                _command.Connection = _connection;

                MySqlDataReader dataReader = _command.ExecuteReader();

                if(dataReader != null)
                {
                    DataTable table = new DataTable();
                    table.Load(dataReader);

                    return table;
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"ExecuteSelect\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

    }
}
