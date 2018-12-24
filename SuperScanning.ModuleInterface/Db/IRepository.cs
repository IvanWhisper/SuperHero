using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.Db
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭数据库
        /// </summary>
        void Close();
        /// <summary>
        /// 提交任务
        /// </summary>
        void Commit();
        /// <summary>
        /// 提交任务 回调
        /// </summary>
        /// <param name="callback"></param>
        void Commit(Action<Dictionary<string,long>> callback);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        long Add(string sqlformat,T entity,bool isTrans);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entities">实体集合</param>
        /// <param name="isTrans">是否事务（必须）</param>
        long Adds(string sqlformat,IEnumerable<T> entities, bool isTrans);
        /// <summary>
        /// 清空数据表
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="isTrans">是否事务（必须）</param>
        long DeleteAll(string sqlformat, bool isTrans);
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        long Delete(string sqlformat, T entity, bool isTrans);
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlformat">SQL语句</param>
        /// <param name="entity">实体</param>
        /// <param name="isTrans">是否事务</param>
        long Update(string sqlformat, T entity, bool isTrans);
    }
}
