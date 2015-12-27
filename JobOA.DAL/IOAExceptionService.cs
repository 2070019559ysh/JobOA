using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OAϵͳ�쳣��Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IOAExceptionService
    {
        /// <summary>
        /// ͨ��Id����OAϵͳ�쳣��Ϣ
        /// </summary>
        /// <returns>OAϵͳ�쳣��Ϣ</returns>
        OAException SearchOAExceptionById(int id);

        /// <summary>
        /// ���OAϵͳ�쳣��Ϣ
        /// </summary>
        /// <param name="oaException">OAϵͳ�쳣��Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddOAException(OAException oaException);

        /// <summary>
        /// ɾ��OAϵͳ�쳣��Ϣ
        /// </summary>
        /// <param name="id">OAϵͳ�쳣Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteOAException(int id);

        /// <summary>
        /// ����OAϵͳ�쳣��Ϣ
        /// </summary>
        /// <param name="oaException">��OAϵͳ�쳣��Ϣ</param>
        /// <returns>���µļ�¼��</returns>
        int UpdateOAException(OAException oaException);
    }
}