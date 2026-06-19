using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace AbySalto.Mid.Domain.Business.Databasing
{
    public class Db
    {
        private readonly SqlConnection connection;
        public Db(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        public void Connect()
        {
            if(this.connection.State == System.Data.ConnectionState.Closed)
            {
                this.connection.Open();
            }

        }

        public SqlDataReader ExecuteProcedure(string procedure, params SqlParameter[] args)
        {
            SqlCommand command = this.connection.CreateCommand();

            command.CommandText = procedure;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter param in args)
            {
                command.Parameters.Add(param);
            }

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public SqlDataReader ExecuteQuery(string sql, params SqlParameter[] args)
        {
            SqlCommand command = this.connection.CreateCommand();

            command.CommandText = sql;
            foreach (SqlParameter param in args)
            {
                command.Parameters.Add(param);
            }
      
            SqlDataReader reader = command.ExecuteReader();

            return reader;

        }

        public void ExecuteControl(string sql, params SqlParameter[] args)
        {
            SqlCommand command = this.connection.CreateCommand();

            command.CommandText = sql;
            foreach (SqlParameter param in args)
            {
                command.Parameters.Add(param);
            }

            command.ExecuteNonQuery();
        }

        public void Disconnect()
        {
            if (this.connection.State == System.Data.ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

    }
}
