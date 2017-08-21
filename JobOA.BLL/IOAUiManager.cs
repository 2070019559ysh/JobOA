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
        /// <param name="delOaui">ɾ����oaui����</param>
        /// <returns>ɾ���Ƿ�ɹ�</returns>
        bool DeleteOAUi(int id,out OAUi delOaui);

        /// <summary>
        /// ����OA������Ϣ
        /// </summary>
        /// <param name="oaUi">��OA������Ϣ</param>
        /// <returns>�޸��Ƿ�ɹ�</returns>
        bool UpdateOAUi(OAUi oaUi);

        /// <summary>
        /// �������Ͳ���ϵͳ������Ϣ
        /// </summary>
        /// <param name="type">ϵͳ������Ϣ���ͣ�{"joboa_System_sms","ϵͳ����������Ϣ"},
        /// {"joboa_System_email","ϵͳ����������Ϣ"},
        /// {"joboa_System_PictureCarousel","ϵͳͼƬ�ֲ�"},
        /// {"joboa_System_FootHead","ϵͳ�Ų�����"},
        /// {"joboa_System_FootContent","ϵͳ�Ų�����"},
        /// {"joboa_System_Notice","ϵͳ����"},
        /// {"joboa_System_InfoList","ϵͳ��Ϣ�б�"}</param>
        /// <param name="limit">���ƻ�ȡ������,Ĭ����4����¼</param>
        /// <returns>ϵͳ������Ϣ����</returns>
        List<OAUi> SearchOauiByType(string type, int limit = 4);
    }
}