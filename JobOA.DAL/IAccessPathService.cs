using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 可访问路径关联数据库接口
    /// </summary>
    public interface IAccessPathService
    {
        /// <summary>
        /// 通过Id查找可访问路径信息
        /// </summary>
        /// <returns>可访问路径信息</returns>
        AccessPath SearchAccessPathById(int id);

        /// <summary>
        /// 通过访问方式和访问路径查找具体的可访问路径信息
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>可访问路径信息</returns>
        AccessPath SearchAccessPathByPath(string httpMethod, string path);
        /// <summary>
        /// 添加可访问路径信息
        /// </summary>
        /// <param name="accessPath">可访问路径信息</param>
        /// <returns>添加的记录数</returns>
        int AddAccessPath(AccessPath accessPath);

        /// <summary>
        /// 删除可访问路径信息
        /// </summary>
        /// <param name="id">可访问路径Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteAccessPath(int id);

        /// <summary>
        /// 更新可访问路径信息
        /// </summary>
        /// <param name="accessPath">新可访问路径信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateAccessPath(AccessPath accessPath);
    }
}