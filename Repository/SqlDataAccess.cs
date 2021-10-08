using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;
using Microsoft.Data.SqlClient;


namespace WebAPI.Repository
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public string ConnectionStringName { get; set; } = "UserDBConnection";


        public async Task<List<T>> LoadData<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                var data = await connection.QueryAsync<T>(sql, parameter, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
        }


        public List<T> LoadDataByQuery<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                var data = connection.Query<T>(sql, parameter);
                return data.ToList();
            }
        }

        //save data using raw sql query
        public void SaveDataByQuery<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                connection.Execute(sql, parameter);
            }
        }

        //save data using raw sql query and return ID of newly inserted row
        public Guid SaveDataByQueryAndReturnID<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                return connection.ExecuteScalar<Guid>(sql, parameter);
            }
        }

        /*
      - it use  sp to call db
      - return object or data type of type T
       */
        public T LoadDataByID<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                var data = connection.Query<T>(sql, parameter, commandType: CommandType.StoredProcedure);
                return data.FirstOrDefault();
            }
        }

        //save data using storeprocedure
        public void SaveData<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                connection.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        //save data using sp and return ID of newly inserted row
        public Guid SaveDataAndReturnID<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                return connection.ExecuteScalar<Guid>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        /*
        - it use  sp to call db
        - return object or data type of type T
        */
        //note: duplicate of LoadDataByID
        public T LoadDataByValue<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                return connection.QueryFirstOrDefault<T>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        /*
       - it use raw sql query' to call db
       - return object or data type of type T
       */
        public T LoadDataByIDByQuery<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                return connection.QueryFirstOrDefault<T>(sql, parameter);

            }
        }

        /*
        - it use  sp to call db
        - return list of type T
        - paramater can be null but not necessary
         */
        public List<T> LoadDataBySP<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(ConnectionStringName)))
            {
                var data = connection.Query<T>(sql, parameter, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
        }
    }
}
