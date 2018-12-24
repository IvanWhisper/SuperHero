using MySql.Data.MySqlClient;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.Db;
using SuperScanning.ModuleInterface.Default;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SuperScanning.Core.Db
{
    public class UnitOfWork<T> :IUnitOfWork<T> where T : class
    {
        private ILogger log;
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private IDbConnection Conn;
        /// <summary>
        /// 新增方法委托字典
        /// </summary>
        private Dictionary<T, Func<long>> addEntities;
        /// <summary>
        /// 批量新增委托字典
        /// </summary>
        private Dictionary<IEnumerable<T>, Func<long>> addsEntities;
        /// <summary>
        /// 更新方法委托字典
        /// </summary>
        private Dictionary<T, Func<long>> updateEntities;
        /// <summary>
        /// 删除方法委托字典
        /// </summary>
        private Dictionary<T, Func<long>> deleteEntities;
        /// <summary>
        /// 更改方法委托列表
        /// </summary>
        private List<Func<long>> changeEntities;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="conn"></param>
        public UnitOfWork(IDbConnection conn)
        {
            log = new DefaultLogger();
            this.Conn = conn;
            addEntities = new Dictionary<T, Func<long>>();
            updateEntities = new Dictionary<T, Func<long>>();
            deleteEntities = new Dictionary<T, Func<long>>();
            addsEntities = new Dictionary<IEnumerable<T>, Func<long>>();
            changeEntities = new List<Func<long>>();
        }
        /// <summary>
        /// 注册新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        public void RegisterAdd(T entity, Func<long> callback)
        {
            this.addEntities.Add(entity, callback);
        }
        /// <summary>
        /// 注册批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="callback"></param>
        public void RegisterAdds(IEnumerable<T> entities, Func<long> callback)
        {
            this.addsEntities.Add(entities, callback);
        }
        /// <summary>
        /// 注册更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        public void RegisterUpdate(T entity, Func<long> callback)
        {
            this.updateEntities.Add(entity, callback);
        }
        /// <summary>
        /// 注册删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        public void RegisterDelete(T entity, Func<long> callback)
        {
            this.deleteEntities.Add(entity, callback);
        }
        /// <summary>
        /// 注册更改
        /// </summary>
        /// <param name="callback"></param>
        public void RegisterChange(Func<long> callback)
        {
            this.changeEntities.Add(callback);
        }
        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
            using (MySqlTransaction scope = ((MySqlConnection)Conn).BeginTransaction())
            {
                try
                {
                    foreach (var item in changeEntities)
                    {
                        item();
                    }
                    foreach (var entity in deleteEntities.Keys)
                    {
                        this.deleteEntities[entity]();
                    }

                    foreach (var entity in updateEntities.Keys)
                    {
                        this.updateEntities[entity]();
                    }

                    foreach (var entity in addEntities.Keys)
                    {
                        this.addEntities[entity]();
                    }
                    foreach (var entities in addsEntities.Keys)
                    {
                        this.addsEntities[entities]();
                    }
                    scope.Commit();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    scope.Rollback();
                }
                finally
                {
                    changeEntities.Clear();
                    deleteEntities.Clear();
                    updateEntities.Clear();
                    addEntities.Clear();
                    addsEntities.Clear();
                }
            }
        }
        /// <summary>
        /// 回调 提交
        /// </summary>
        /// <param name="callback"></param>
        public void Commit(Action<Dictionary<string, long>> callback)
        {
            long c = 0,d = 0,u = 0,a = 0,b = 0;
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
            using (MySqlTransaction scope = ((MySqlConnection)Conn).BeginTransaction())
            {
                try
                {
                    foreach (var item in changeEntities)
                    {
                        c+=item();
                    }
                    foreach (var entity in deleteEntities.Keys)
                    {
                        d+=this.deleteEntities[entity]();
                    }

                    foreach (var entity in updateEntities.Keys)
                    {
                        u+=this.updateEntities[entity]();
                    }

                    foreach (var entity in addEntities.Keys)
                    {
                        a+=this.addEntities[entity]();
                    }
                    foreach (var entities in addsEntities.Keys)
                    {
                        b+=this.addsEntities[entities]();
                    }
                    scope.Commit();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    scope.Rollback();
                }
                finally
                {
                    changeEntities.Clear();
                    deleteEntities.Clear();
                    updateEntities.Clear();
                    addEntities.Clear();
                    addsEntities.Clear();
                    Dictionary<string, long> result = new Dictionary<string, long>();
                    result.Add("C",c);
                    result.Add("D",d);
                    result.Add("U",u);
                    result.Add("A",a);
                    result.Add("B",b);
                    callback(result);
                }
            }
        }
        /// <summary>
        /// 多数据库提交
        /// </summary>
        public void MultiCommit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var entity in deleteEntities.Keys)
                {
                    this.deleteEntities[entity]();
                }

                foreach (var entity in updateEntities.Keys)
                {
                    this.updateEntities[entity]();
                }

                foreach (var entity in addEntities.Keys)
                {
                    this.addEntities[entity]();
                }

                scope.Complete();
            }
        }

    }
}
