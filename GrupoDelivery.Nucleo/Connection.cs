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
                    throw new InvalidProgramException($"Conexão já Aberta!");

                _connection = new MySqlConnection("");
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"OpenConnection\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

        public void BeginTransaction()
        {
            try
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                    throw new InvalidProgramException($"Conexão não estava Aberta!");

                _transaction = _connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"BeginTransaction\" : {Environment.NewLine}{ex.ToString()}");
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

        public void Commit()
        {
            try
            {
                if(_transaction == null)
                    throw new InvalidProgramException($"Não havia uma transação Aberta!");

                _transaction.Commit();
            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"Commit\" : {Environment.NewLine}{ex.ToString()}");
            }
        }

        public void RollBack()
        {
            try
            {
                if (_transaction == null)
                    throw new InvalidProgramException($"Não havia uma transação Aberta!");

                _transaction.Rollback();
            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"Commit\" : {Environment.NewLine}{ex.ToString()}");
            }
        }
    }
}
