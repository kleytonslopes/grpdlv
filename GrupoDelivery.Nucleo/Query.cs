using GrupoDelivery.Nucleo.Helpers;
using GrupoDelivery.Nucleo.Types;
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
        
        public Query(Connection connection)
        {
            _connection = connection.GetConnection();
        }

        public void AddQuery(String sql)
        {
            if (_query == null)
                _query = new StringBuilder();

            _query.Append(sql);
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
                throw ErroMessage.ProgramException("AddParam", ex);
            }
        }

        public void Execute()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                MySqlCommand _command = new MySqlCommand();
                _command.Connection = _connection;

                if (_transaction != null)
                    _command.Transaction = _transaction;

                if (_parameters != null && _parameters.Any())
                    foreach (var p in _parameters)
                        _command.Parameters.AddWithValue(p.Key, p.Value);

                _command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("Execute", ex);
            }
        }

        public DataTable ExecuteSelect()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

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
                throw ErroMessage.ProgramException("ExecuteSelect", ex);
            }
        }

    }
}
