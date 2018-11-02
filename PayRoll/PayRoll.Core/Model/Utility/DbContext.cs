﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace PayRoll.Core.Model.Utility
{
    public class DbContext:DataCommon    {
        #region Private Property

        private DbProviderFactory dbFactory;
        private string _connectionString;
        private DbConnection _connection;
        private DbDataAdapter _adapter;
        private DbCommand _command;
        private DbParameter _parameter;
        private int _commandTimeOut = 0;

        #endregion

        #region Public Property

        public int CommandTimeOut
        {
            get;
            set;
        }

        #endregion

        #region Constructor
        public DbContext(string connectionString, string providerName = "System.Data.SqlClient")
        {
            dbFactory = DbProviderFactories.GetFactory(providerName);
            _connectionString = connectionString;
        }

        #endregion

        #region Public Method

        public void Open()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = dbFactory.CreateConnection();
                }
                if (_connection != null)
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.ConnectionString = _connectionString;
                        _connection.Open();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(@"Please check  connection.");
            }
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }


        public DataTable GetDataTable(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            _command = dbFactory.CreateCommand();
            if (_command != null)
            {
                _command.CommandType = CommandType.Text;
                _command.CommandText = sqlQuery;
                _command.CommandTimeout = _commandTimeOut;
                _command.Connection = _connection;
            }
            _adapter = dbFactory.CreateDataAdapter();
            if (_adapter != null)
            {
                _adapter.SelectCommand = _command;
                _adapter.Fill(dataTable);
            }
            return dataTable;
        }


        public DataTable GetDataTable(string sqlQuery, List<Parameter> inputParameters)
        {
            DataTable dataTable = new DataTable();
            _command = dbFactory.CreateCommand();
            if (_command != null)
            {
                _command.CommandType = CommandType.Text;
                _command.CommandText = sqlQuery;
                for (int i = 0; i < inputParameters.Count; i++)
                {
                    _parameter = dbFactory.CreateParameter();
                    if (_parameter != null)
                    {
                        _parameter.DbType = inputParameters[i].Type;
                        _parameter.Value = inputParameters[i].Value;
                        _parameter.ParameterName = inputParameters[i].Name;
                        _command.Parameters.Add(_parameter);
                    }
                }
                _command.CommandTimeout = _commandTimeOut;
                _command.Connection = _connection;
            }
            _adapter = dbFactory.CreateDataAdapter();
            if (_adapter != null)
            {
                _adapter.SelectCommand = _command;
                _adapter.Fill(dataTable);
            }
            return dataTable;
        }


        public int ExecuteQuery(string sqlQuery)
        {
            _command = dbFactory.CreateCommand();
            int result = 0;
            if (_command != null)
            {
                _command.CommandType = CommandType.Text;
                _command.CommandText = sqlQuery;
                _command.CommandTimeout = _commandTimeOut;
                _command.Connection = _connection;
                result = _command.ExecuteNonQuery();
            }
            return result;
        }

        public int ExecuteStructureQuery(DataTable dt)
        {
            SqlConnection conn = new SqlConnection(AppDbConnection.ConnectionString);
            SqlCommand cmd = new SqlCommand("Sp_CollectEmployeeAttendance", conn);
            SqlParameter parameter = new SqlParameter();
            int result = 0;
            parameter.ParameterName = "@DataCollection";
            cmd.CommandType = CommandType.StoredProcedure;
            parameter.SqlDbType = System.Data.SqlDbType.Structured;
            parameter.Value = dt;
            cmd.Parameters.Add(parameter);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }


        public int ExecuteQuery(string sqlQuery, List<Parameter> inputParameters)
        {
            _command = dbFactory.CreateCommand();
            int result = 0;
            if (_command != null)
            {
                _command.CommandType = CommandType.Text;
                _command.CommandText = sqlQuery;
                _command.CommandTimeout = _commandTimeOut;
                _command.Connection = _connection;

                for (int i = 0; i < inputParameters.Count; i++)
                {
                    _parameter = dbFactory.CreateParameter();
                    if (_parameter != null)
                    {
                        _parameter.DbType = inputParameters[i].Type;
                        _parameter.Value = inputParameters[i].Value;
                        _parameter.ParameterName = inputParameters[i].Name;
                        _command.Parameters.Add(_parameter);
                    }
                }
                result = _command.ExecuteNonQuery();
            }
            return result;
        }





        public string GetQueryString(string query)
        {
            _command = null;
            _command = dbFactory.CreateCommand();
            string Value = string.Empty;

            try
            {
                _command.CommandText = query;
                _command.Connection = _connection;
                _command.CommandTimeout = _commandTimeOut;

                DbDataReader result = _command.ExecuteReader();
                if (result.Read())
                {
                    Value = (string)result[0];
                }
                result.Close();
                _connection.Close();
                return Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetQueryDate(string query)
        {
            _command = null;
            _command = dbFactory.CreateCommand();
            string Value = string.Empty;

            try
            {
                _command.CommandText = query;
                _command.Connection = _connection;
                _command.CommandTimeout = _commandTimeOut;

                DbDataReader result = _command.ExecuteReader();
                if (result.Read())
                {
                    Value = result[0].ToString();
                }
                result.Close();
                _connection.Close();
                return Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetQueryInteger(string query)
        {
            _command = dbFactory.CreateCommand();
            int Value = 0;

            try
            {
                _command.CommandText = query;
                _command.Connection = _connection;
                DbDataReader result = _command.ExecuteReader();
                if (result.Read())
                {
                    Value = (int)result[0];
                }
                result.Close();
                _connection.Close();
                return Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
#endregion

    }
}
