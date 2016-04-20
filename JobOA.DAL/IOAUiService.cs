using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA������Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IOAUiService
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
        /// ���OA������Ϣ
        /// </summary>
        /// <param name="oaUi">OA������Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddOAUi(OAUi oaUi);

        /// <summary>
        /// ɾ��OA������Ϣ
        /// </summary>
        /// <param name="id">OA����Id</param>
        /// <param name="delOaui">ɾ����oaui����</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteOAUi(int id,out OAUi delOaui);

        /// <summary>
        /// ����OA������Ϣ
        /// </summary>
        /// <param name="oaUi">��OA������Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateOAUi(OAUi oaUi);

        /// <summary>
        /// �������Ͳ���ϵͳ������Ϣ
        /// </summary>
        /// <param name="type">ϵͳ������Ϣ���ͣ�"joboa_System_sms","ϵͳ����������Ϣ";
        ///"joboa_System_email","ϵͳ����������Ϣ";
        ///"joboa_System_PictureCarousel","ϵͳͼƬ�ֲ�";
        ///"joboa_System_FootHead","ϵͳ�Ų�����";
        ///"joboa_System_FootContent","ϵͳ�Ų�����";
        ///"joboa_System_Notice","ϵͳ����";
        ///"joboa_System_InfoList","ϵͳ��Ϣ�б�"</param>
        /// <param name="limit">���ƻ�ȡ������,Ĭ����4����¼</param>
        /// <returns>ϵͳ������Ϣ����</returns>
        List<OAUi> SearchOauiByType(string type, int limit = 4);
    }
}