namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    [Table("MajorTask")]
    public partial class MajorTask
    {
        /// <summary>
        /// �޲ι��캯����ʼ����Ϣ��������
        /// </summary>
        public MajorTask()
        {
            OAMessage = new HashSet<OAMessage>();
            SubTask = new HashSet<SubTask>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [DisplayName("������")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(100, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string Name { get; set; }

        /// <summary>
        /// ������Id
        /// </summary>
        public int ArrangePersonId { get; set; }

        /// <summary>
        /// ִ����Id
        /// </summary>
        [DisplayName("ִ����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int ExePersonId { get; set; }

        /// <summary>
        /// ��飨���գ���Id
        /// </summary>
        [DisplayName("��飨���գ���")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int CheckPersonId { get; set; }

        /// <summary>
        /// ������Id�б��ַ���
        /// </summary>
        public string Participator { get; set; }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        [DisplayName("��ʼʱ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [RegularExpression(@"^\d{4}\D{1}\d{2}\D{1}\d{2}\D{1}(\d{1,2}:\d{1,2}:\d{1,2})?$", ErrorMessage = "{0}�ĸ�ʽ����ȷ")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        [DisplayName("���ʱ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [RegularExpression(@"^\d{4}\D{1}\d{2}\D{1}\d{2}\D{1}(\d{1,2}:\d{1,2}:\d{1,2})?$", ErrorMessage = "{0}�ĸ�ʽ����ȷ")]
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// �ύʱ��
        /// </summary>
        public DateTime? CommitTime { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        [DisplayName("������״̬")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int State { get; set; }

        /// <summary>
        /// �Ƿ��Ѿ�����֪ͨ
        /// </summary>
        public bool IsNotice { get; set; }

        /// <summary>
        /// �Ƿ���Ᵽ��
        /// </summary>
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// �����ļ���
        /// </summary>
        [DisplayName("�����ļ���")]
        [StringLength(255, ErrorMessage = "{0}������չ�����ܶ���{1}���ַ�")]
        public string Attachment { get; set; }

        /// <summary>
        /// ��ĿId
        /// </summary>
        [DisplayName("������Ŀ")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int ProjectId { get; set; }

        //��������
        /// <summary>
        /// ������
        /// </summary>
        public virtual Employee ArrangeEmployee { get; set; }

        /// <summary>
        /// ִ����
        /// </summary>
        public virtual Employee ExeEmployee { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public virtual Employee CheckEmployee { get; set; }

        /// <summary>
        /// ����֪ͨ����Ϣ
        /// </summary>
        public virtual ICollection<OAMessage> OAMessage { get; set; }

        /// <summary>
        /// ������Ŀ
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual ICollection<SubTask> SubTask { get; set; }
    }
}
