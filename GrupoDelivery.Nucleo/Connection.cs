using GrupoDelivery.Nucleo.Helpers;
using GrupoDelivery.Nucleo.Types;
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
        private MySqlTransaction _transaction;

        public void OpenConnection()
        {
            try
            {
                if (_connection != null && _connection.State != ConnectionState.Open)
                    throw ErroMessage.Operation(EErrosCode.ConnectionIsOpen);
#warning  CRIAR UM HOST PARA CONECTAR-SE
                _connection = new MySqlConnection("");
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw ErroMessage.ProgramException("OpenConnection", ex);
            }
        }

        public void BeginTransaction()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                _transaction = _connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ErroMessage.ProgramException("BeginTransaction", ex);
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
                throw ErroMessage.ProgramException("CloseConnection", ex);
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Commit()
        {
            try
            {
                if(_transaction == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutTransaction);

                _transaction.Commit();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("Commit", ex);
            }
        }

        public void RollBack()
        {
            try
            {
                if (_transaction == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutTransaction);

                _transaction.Rollback();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("RollBack", ex);
            }
        }
    }
}
