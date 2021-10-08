using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Interface
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }


        Task<List<T>> LoadData<T, U>(string sql, U parameter);
        T LoadDataByValue<T, U>(string sql, U parameter);
        T LoadDataByID<T, U>(string sql, U parameter);
        List<T> LoadDataByQuery<T, U>(string sql, U parameter);
        List<T> LoadDataBySP<T, U>(string sql, U parameter);
        void SaveData<T>(string sql, T parameter);
        Guid SaveDataAndReturnID<T>(string sql, T parameter);
        void SaveDataByQuery<T>(string sql, T parameter);
        Guid SaveDataByQueryAndReturnID<T>(string sql, T parameter);
        T LoadDataByIDByQuery<T, U>(string sql, U parameter);

    }
}
