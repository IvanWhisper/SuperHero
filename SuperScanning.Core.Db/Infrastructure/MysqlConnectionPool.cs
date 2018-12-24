using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperScanning.Core.Db.Infrastructure
{
    public class MysqlConnectionPool
    {
        private Stack<MySqlConnection> pool;
        private const int POOL_MAX_SIZE = 20;
        private int current_Size = 0;
        private string ConnString = "";
        private static MysqlConnectionPool connPool;
        private MysqlConnectionPool()
        {
            if (pool == null)
            {
                pool = new Stack<MySqlConnection>();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static MysqlConnectionPool getInstance()
        {
            if (connPool == null)
            {
                connPool = new MysqlConnectionPool();
            }
            return connPool;
        }
        public MySqlConnection getConnection()
        {
            MySqlConnection conn;
            lock (this)
            {
                if (pool.Count == 0)
                {
                    if (current_Size < POOL_MAX_SIZE)
                    {
                        conn = createConnection();
                        current_Size++;
                        pool.Push(conn);
                    }
                    else
                    {
                        try
                        {
                            Monitor.Wait(this);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }
                    }
                }
                conn = (MySqlConnection)pool.Pop();
            }
            return conn;
        }
        private string GetConnString()
        {
            if (ConnString == "")
            {
                ConnString = System.Configuration.ConfigurationManager.AppSettings["mysqldb"];
            }
            return ConnString;
        }
        public void releaseConnection(MySqlConnection conn)
        {
            lock (this)
            {
                conn.Close();
                pool.Push(conn);
                Monitor.Pulse(this);
            }
        }
        private MySqlConnection createConnection()
        {
            lock (this)
            {
                MySqlConnection newConn = new MySqlConnection(GetConnString());
                newConn.Open();
                return newConn;
            }
        }
    }
}
