using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SuperScanning.ModuleInterface.Db;

namespace SuperScanning.Core.Db
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// 数据库链接
        /// </summary>
        protected IDbConnection Conn { get; private set; }
        private static object locker = new object();
        public IUnitOfWork<T> CurUnitOfWork
        {
            get
            {
                lock (locker)
                {
                    return unitOfWork;
                }
            }
        }

        /// <summary>
        /// 单元任务
        /// </summary>
        private IUnitOfWork<T> unitOfWork;
        /// <summary>
        /// 构造
        /// </summary>
        public DapperRepository()
        {
            Conn =new MySql.Data.MySqlClient.MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["mysqldb"]);
            unitOfWork = new UnitOfWork<T>(Conn);
        }
        /// <summary>
        /// 连接数据库
        /// </summary>
        public void Open()
        {
            if(Conn.State!=ConnectionState.Open)
                Conn.Open();
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void Close()
        {
            Conn.Close();
        }
        /// <summary>
        /// 提交任务
        /// </summary>
        public void Commit()
        {
            lock (locker)
            {
                unitOfWork.Commit();
            }
        }
        /// <summary>
        /// 提交任务 回调
        /// </summary>
        /// <param name="callback"></param>
        public void Commit(Action<Dictionary<string, long>> callback)
        {
            lock (locker)
            {
                unitOfWork.Commit(callback);
            }
        }
        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="conn"></param>
        public void SetDbConnection(IDbConnection conn)
        {
            Conn = conn;
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entities">实体集合</param>
        /// <param name="isTrans">是否事务（必须）</param>
        public long Adds(string sqlformat,IEnumerable<T> entities, bool isTrans)
        {
            if (isTrans)
            {
                this.CurUnitOfWork.RegisterAdds(entities, () =>
                 {
                     return Conn.Execute(sqlformat, entities);
                 });
                Commit();
                return 0;
            }
            else
            {
                return Conn.Execute(sqlformat, entities);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        public long Add(string sqlformat,T entity, bool isTrans)
        {
            if (isTrans)
            {
                this.CurUnitOfWork.RegisterAdd(entity, () =>
                {
                    return Conn.Execute(sqlformat, entity);
                });
                return 0;
            }
            else
            {
                return Conn.Execute(sqlformat, entity);
            }
        }
        /// <summary>
        /// 清空数据表
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="isTrans">是否事务（必须）</param>
        public long DeleteAll(string sqlformat, bool isTrans)
        {
            if (isTrans)
            {
                this.CurUnitOfWork.RegisterChange(() =>
                {
                    return Conn.Execute(sqlformat);
                });
                return 0;
            }
            else
            {
                return Conn.Execute(sqlformat);
            }
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        public long Delete(string sqlformat, T entity, bool isTrans)
        {
            if (isTrans)
            {
                this.CurUnitOfWork.RegisterDelete(entity, () =>
                {
                    return Conn.Execute(sqlformat, entity);
                });
                return 0;
            }
            else
            {
                return Conn.Execute(sqlformat, entity);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        public long Update(string sqlformat, T entity, bool isTrans)
        {
            if (isTrans)
            {
                this.CurUnitOfWork.RegisterUpdate(entity, () =>
                {
                    return Conn.Execute(sqlformat, entity);
                });
                return 0;
            }
            else
            {
                return Conn.Execute(sqlformat, entity);
            }
        }



    }
}
