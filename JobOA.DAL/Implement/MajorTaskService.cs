using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// ������������ݿ���
    /// </summary>
    public class MajorTaskService:IMajorTaskService
    {
        /// <summary>
        /// ͨ��Id����������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>������</returns>
        public MajorTask SearchMajorTaskById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var majorTask = from m in dbContext.MajorTask.Include("ArrangeEmployee,CheckEmployee,ExeEmployee")
                              where m.Id == id
                              select m;
                return majorTask.SingleOrDefault();
            }
        }

        /// <summary>
        /// ͨ��������ģ������������
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns>�����񼯺�</returns>
        public List<MajorTask> SearchMajorTaskByName(string name)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var majorTask = from m in dbContext.MajorTask.Include("ArrangeEmployee,CheckEmployee,ExeEmployee")
                                where m.Name.Contains(name)
                                orderby m.CreateTime descending
                                select m;
                return majorTask.ToList();
            }
        }

        /// <summary>
        /// ���ݲ�ѯ����������������������
        /// </summary>
        /// <param name="searchCondition">��ѯ��������</param>
        /// <returns>����������ļ���</returns>
        public List<MajorTask> SearchAllMajorTask(SearchTaskCondition searchCondition)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var majorTask = from m in dbContext.MajorTask.Include("ArrangeEmployee,CheckEmployee,ExeEmployee")
                                join p in dbContext.Project on m.ProjectId equals p.Id
                                join e in dbContext.Employee on m.ExePersonId equals e.Id
                                where m.Name.Contains(searchCondition.TaskName) 
                                && e.DepartmentId==searchCondition.DepantmentId
                                && p.Id==searchCondition.ProjectId
                                orderby m.CreateTime descending
                                select m;
                var majorTasks = majorTask.Skip((searchCondition.PageIndex - 1) 
                    * searchCondition.PageMax).Take(searchCondition.PageMax);
                return majorTasks.ToList();
            }
        }

        /// <summary>
        /// ���ݷ�ҳ��������������
        /// </summary>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageMax">ÿҳ����¼��</param>
        /// <returns>��ǰҳ����������ļ���</returns>
        public List<MajorTask> SearchAllMajorTask(int pageIndex,int pageMax)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var majorTask = from m in dbContext.MajorTask.Include("ArrangeEmployee,CheckEmployee,ExeEmployee")
                                orderby m.CreateTime descending
                                select m;
                var majorTasks = majorTask.Skip((pageIndex - 1) * pageMax).Take(pageMax);
                return majorTasks.ToList();
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ��������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ����������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>�޸ĵļ�¼��</returns>
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