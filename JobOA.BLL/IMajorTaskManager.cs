﻿using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 主任务业务逻辑接口
    /// </summary>
    public interface IMajorTaskManager
    {
        /// <summary>
        /// 通过Id查找主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>主任务</returns>
        MajorTask SearchMajorTaskById(int id);

        /// <summary>
        /// 通过任务名模糊查找主任务
        /// </summary>
        /// <param name="name">主任务名</param>
        /// <returns>主任务集合</returns>
        List<MajorTask> SearchMajorTaskByName(string name);

        /// <summary>
        /// 根据查询任务条件查找所有主任务
        /// </summary>
        /// <param name="search">查询任务条件,格式：pageIndex,pageSize,projectId,departmentId,name</param>
        /// <returns>所有主任务的集合</returns>
        public List<MajorTask> SearchAllMajorTask(string search);

        /// <summary>
        /// 根据分页查找所有主任务
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageMax">每页最大记录数</param>
        /// <returns>当前页所有主任务的集合</returns>
        List<MajorTask> SearchAllMajorTask(int pageIndex, int pageMax);

        /// <summary>
        /// 添加主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>添加记录是否成功</returns>
        bool AddMajorTask(MajorTask majorTask);

        /// <summary>
        /// 删除主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>删除记录是否成功</returns>
        bool DeleteMajorTask(int id);

        /// <summary>
        /// 更新主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>修改记录是否成功</returns>
        bool UpdateMajorTask(MajorTask majorTask);
    }
}
