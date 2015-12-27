using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 可访问路径关联数据库类
    /// </summary>
    public class AccessPathService:IAccessPathService
    {
        /// <summary>
        /// 通过Id查找可访问路径信息
        /// </summary>
        /// <returns>可访问路径信息</returns>
        public AccessPath SearchAccessPathById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var accessPath = from a in dbContext.AccessPath
                                 where a.AccessPathId == id
                                 select a;
                return accessPath.SingleOrDefault();
            }
        }

        /// <summary>
        /// 通过访问方式和访问路径查找具体的可访问路径信息
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>可访问路径信息</returns>
        public AccessPath SearchAccessPathByPath(string httpMethod, string path)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var accessPath = from a in dbContext.AccessPath
                                 join p in dbContext.Permission
                                 on a.AccessPathId equals p.AccessPathId
                                 where a.HttpMethod.ToUpper().Contains(httpMethod.ToUpper()) &&
                                 a.Path.ToUpper().Equals(path.ToUpper())
                                 select a;
                return accessPath.FirstOrDefault();
            }
        }

        /// <summary>
        /// 添加可访问路径信息
        /// </summary>
        /// <param name="accessPath">可访问路径信息</param>
        /// <returns>添加的记录数</returns>
        public int AddAccessPath(AccessPath accessPath)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.AccessPath.Add(accessPath);
                int rows=dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除可访问路径信息
        /// </summary>
        /// <param name="id">可访问路径Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteAccessPath(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                AccessPath accessPath = new AccessPath() { AccessPathId = id };
                dbContext.AccessPath.Attach(accessPath);
                dbContext.AccessPath.Remove(accessPath);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新可访问路径信息
        /// </summary>
        /// <param name="accessPath">新可访问路径信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateAccessPath(AccessPath accessPath)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldAccessPath=dbContext.AccessPath.Find(accessPath.AccessPathId);
                if (oldAccessPath != null)
                {
                    oldAccessPath.HttpMethod = accessPath.HttpMethod;
                    oldAccessPath.Path = accessPath.Path;
                    oldAccessPath.Permission = accessPath.Permission;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
