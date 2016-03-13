using JobOA.Model;
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
    }
}