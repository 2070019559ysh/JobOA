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
    /// ��������Ϣ�������ݿ���
    /// </summary>
    public class SubTaskService:ISubTaskService
    {
        /// <summary>
        /// ͨ��Id����������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>������</returns>
        public SubTask SearchSubTaskById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var subTask = from s in dbContext.SubTask
                                where s.Id == id
                                select s;
                return subTask.SingleOrDefault();
            }
        }

        /// <summary>
        /// ͨ��������ģ������������
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns>�����񼯺�</returns>
        public List<SubTask> SearchSubTaskByName(string name)
        {
            using (OaModel dbContext = new OaModel())
            {
                var subTask = from s in dbContext.SubTask
                                where s.Name.Contains(name)
                                select s;
                return subTask.ToList();
            }
        }

        /// <summary>
        /// ���ݷ�ҳ������Ϣ�����������б���Ϣ
        /// </summary>
        /// <param name="id">������id</param>
        /// <param name="pager">��ҳ������Ϣ</param>
        /// <returns>�������б���Ϣ</returns>
        public List<SubTask> SearchSubTask(int id,Pager pager)
        {
            using (OaModel dbContext = new OaModel())
            {
                var subTask = from s in dbContext.SubTask
                              where s.Name.Contains(pager.Remarks)&&s.TaskId==id
                              orderby s.CreateTime descending
                              select s;
                pager.Total = subTask.Count();
                return subTask.Skip((pager.PageIndex-1)*pager.PageSize).Take(pager.PageSize).ToList();
            }
        }

        /// <summary>
        /// ͳ�Ƶ�ǰ�������µ�������һ���м���
        /// </summary>
        /// <param name="majorTaskId">������Id</param>
        /// <returns>������������</returns>
        public int SubTaskCountByMajorTask(int majorTaskId)
        {
            using (OaModel dbContext = new OaModel())
            {
                var subQuery = from sub in dbContext.SubTask
                        where sub.TaskId == majorTaskId
                        select sub;
                return subQuery.Count();
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="SubTask">������</param>
        /// <returns>��ӵļ�¼��</returns>
        public int AddSubTask(SubTask subTask)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                dbContext.SubTask.Add(subTask);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        public int DeleteSubTask(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                SubTask subTask = new SubTask() { Id = id };
                dbContext.SubTask.Attach(subTask);
                dbContext.SubTask.Remove(subTask);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="SubTask">������</param>
        /// <returns>�޸ĵļ�¼��</returns>
        public int UpdateSubTask(SubTask subTask)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                var oldSubTask = dbContext.SubTask.Find(subTask.Id);
                if (oldSubTask != null)
                {
                    oldSubTask.Name = subTask.Name;
                    oldSubTask.IsSecrecy = subTask.IsSecrecy;
                    oldSubTask.State = subTask.State;
                    oldSubTask.ArrangePersonId = subTask.ArrangePersonId;
                    oldSubTask.Attachment = subTask.Attachment;
                    oldSubTask.CheckPersonId = subTask.CheckPersonId;
                    oldSubTask.CommitTime = subTask.CommitTime;
                    oldSubTask.CompleteTime = subTask.CompleteTime;
                    oldSubTask.CreateTime = subTask.CreateTime;
                    oldSubTask.ExePersonId = subTask.ExePersonId;
                    oldSubTask.Participator = subTask.Participator;
                    oldSubTask.TaskId = subTask.TaskId;
                    oldSubTask.StartTime = subTask.StartTime;
                    oldSubTask.State = subTask.State;
                    oldSubTask.WorkMethod = subTask.WorkMethod;
                    oldSubTask.SubmissionThing = subTask.SubmissionThing;
                    oldSubTask.Progress = subTask.Progress;
                    oldSubTask.No = subTask.No;
                    oldSubTask.CompletionCriteria = subTask.CompletionCriteria;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// ����������ĸ�����
        /// </summary>
        /// <param name="subTaskId">������Id</param>
        /// <param name="fileName">�����ļ���</param>
        /// <returns>�޸ĵļ�¼��</returns>
        public int UpdateSubTaskAttachment(int subTaskId,string fileName)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                var oldSubTask = dbContext.SubTask.Find(subTaskId);
                if (oldSubTask != null)
                {
                    oldSubTask.Attachment = fileName;
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