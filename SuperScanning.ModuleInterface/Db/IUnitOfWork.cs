using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.Db
{
    public interface IUnitOfWork<T> where T : class
    {
        /// <summary>
        /// 注册新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        void RegisterAdd(T entity, Func<long> callback);
        /// <summary>
        /// 注册批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="callback"></param>
        void RegisterAdds(IEnumerable<T> entities, Func<long> callback);
        /// <summary>
        /// 注册更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        void RegisterUpdate(T entity, Func<long> callback);
        /// <summary>
        /// 注册删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        void RegisterDelete(T entity, Func<long> callback);
        /// <summary>
        /// 注册更改
        /// </summary>
        /// <param name="callback"></param>
        void RegisterChange(Func<long> callback);
        /// <summary>
        /// 提交
        /// </summary>
        void Commit();
        /// <summary>
        /// 回调 提交
        /// </summary>
        /// <param name="callback"></param>
        void Commit(Action<Dictionary<string,long>> callback);
        /// <summary>
        /// 多数据库提交
        /// </summary>
        void MultiCommit();
    }
}
