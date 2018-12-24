using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.Db
{
    public interface IQuery
    {
        bool IsExist(string sql);
        T QuerySingle<T>(string sql, object paramPairs) where T : class;
        IEnumerable<T> QueryList<T>(string sql, object paramPairs) where T : class;
        Tuple<int, IEnumerable<T>> GetPage<T>(string sql, object paramPairs = null) where T : class;
        int Execute(string sql, dynamic paramPairs = null);
        long Count(string sql, dynamic paramPairs = null);
    }
}
