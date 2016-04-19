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
    }
}