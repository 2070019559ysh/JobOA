using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 主任务关联数据库类
    /// </summary>
    public class MajorTaskService:IMajorTaskService
    {
        /// <summary>
        /// 通过Id查找主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>主任务</returns>
        public MajorTask SearchMajorTaskById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var majorTask = from m in dbContext.MajorTask
                              where m.Id == id
                              select m;
                return majorTask.SingleOrDefault();
            }
        }

        /// <summary>
        /// 通过任务名模糊查找主任务
        /// </summary>
        /// <param name="name">主任务名</param>
        /// <returns>主任务集合</returns>
        public List<MajorTask> SearchMajorTaskByName(string name)
        {
            using (OaModel dbContext = new OaModel())
            {
                var majorTask = from m in dbContext.MajorTask
                                where m.Name.Contains(name)
                                select m;
                return majorTask.ToList();
            }
        }

        /// <summary>
        /// 添加主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>添加的记录数</returns>
        public int AddMajorTask(MajorTask majorTask)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                dbContext.MajorTask.Add(majorTask);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteMajorTask(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                MajorTask majorTask = new MajorTask() { Id = id };
                dbContext.MajorTask.Attach(majorTask);
                dbContext.MajorTask.Remove(majorTask);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>修改的记录数</returns>
        public int UpdateMajorTask(MajorTask majorTask)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                var oldMajorTask = dbContext.MajorTask.Find(majorTask.Id);
                if (oldMajorTask != null)
                {
                    oldMajorTask.Name = majorTask.Name;
                    oldMajorTask.IsSecrecy = majorTask.IsSecrecy;
                    oldMajorTask.State = majorTask.State;
                    oldMajorTask.ArrangePersonId = majorTask.ArrangePersonId;
                    oldMajorTask.Attachment = majorTask.Attachment;
                    oldMajorTask.CheckPersonId = majorTask.CheckPersonId;
                    oldMajorTask.CommitTime = majorTask.CommitTime;
                    oldMajorTask.CompleteTime = majorTask.CompleteTime;
                    oldMajorTask.CreateTime = majorTask.CreateTime;
                    oldMajorTask.ExePersonId = majorTask.ExePersonId;
                    oldMajorTask.IsNotice = majorTask.IsNotice;
                    oldMajorTask.Participator = majorTask.Participator;
                    oldMajorTask.ProjectId = majorTask.ProjectId;
                    oldMajorTask.StartTime = majorTask.StartTime;
                    oldMajorTask.State = majorTask.State;
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