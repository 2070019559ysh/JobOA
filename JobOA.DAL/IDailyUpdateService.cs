using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// ����ÿ�ո��¹������ݿ�ӿ�
    /// </summary>
    public interface IDailyUpdateService
    {
        /// <summary>
        /// ͨ��Id����ÿ�ո�����Ϣ
        /// </summary>
        /// <returns>ÿ�ո�����Ϣ</returns>
        DailyUpdate SearchDailyUpdateById(int id);

        /// <summary>
        /// ���ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="dailyUpdate">ÿ�ո�����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddDailyUpdate(DailyUpdate dailyUpdate);

        /// <summary>
        /// ɾ��ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="id">ÿ�ո���Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteDailyUpdate(int id);

        /// <summary>
        /// ����ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="dailyUpdate">��ÿ�ո�����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateDailyUpdate(DailyUpdate dailyUpdate);
    }
}
