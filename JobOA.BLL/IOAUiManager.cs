using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// OA������Ϣҵ���߼��ӿ�
    /// </summary>
    public interface IOAUiManager
    {
        /// <summary>
        /// ͨ��Id����OA������Ϣ
        /// </summary>
        /// <returns>OA������Ϣ</returns>
        OAUi SearchOAUiById(int id);

        /// <summary>
        /// ͨ��������׼ȷ����OA������Ϣ
        /// </summary>
        /// <param name="title">������������ģ��ƥ��</param>
        /// <returns>OA������Ϣ</returns>
        OAUi SearchOAUiByTitle(string title);

        /// <summary>
        /// ���ݷ�ҳ��Ϣ��������oaϵͳ������Ϣ,��ҳ��Ϣ���Remarksָ��ѯ������Ϣ
        /// </summary>
        /// <param name="pager">��ҳ��Ϣ����</param>
        /// <returns>oaϵͳ������Ϣ����</returns>
        List<OAUi> SearchOAUiByPager(Pager pager);

        /// <summary>
        /// ���Ͷ��ţ�ʹ����joboa_System_sms��־�Ķ����˺�
        /// </summary>
        /// <param name="smsMob">����Ŀ�ĺ��룬����ֻ������ð�Ƕ��Ÿ���</param>
        /// <param name="smsText">��������</param>
        /// <returns>�Ƿ��Ѿ��ж��ŷ��ͳɹ�</returns>
        bool SendSms(string smsMob, string smsText);

        /// <summary>
        /// ����������Ϣ��ʹ����joboa_System_email��־�Ķ����˺�
        /// </summary>
        /// <param name="toSb">���͸�˭������</param>
        /// <param name="subject">����</param>
        /// <param name="body">����</param>
        /// <param name="fileList">�����ļ�������</param>
        /// <returns>�Ƿ��ͳɹ�</returns>
        bool SendEmail(string toSb, string subject, string body, List<string> fileList = null);

        /// <summary>
        /// ���OA������Ϣ
        /// </summary>
        /// <param name="oaUi">OA������Ϣ</param>
        /// <returns>����Ƿ�ɹ�</returns>
        bool AddOAUi(OAUi oaUi);

        /// <summary>
        /// ɾ��OA������Ϣ
        /// </summary>
        /// <param name="id">OA����Id</param>
        /// <returns>ɾ���Ƿ�ɹ�</returns>
        bool DeleteOAUi(int id);

        /// <summary>
        /// ����OA������Ϣ
        /// </summary>
        /// <param name="oaUi">��OA������Ϣ</param>
        /// <returns>�޸��Ƿ�ɹ�</returns>
        bool UpdateOAUi(OAUi oaUi);
    }
}