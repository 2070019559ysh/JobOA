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
    [Table("SubTask")]
    public partial class SubTask
    {
        public SubTask()
        {
            DailyUpdate = new HashSet<DailyUpdate>();
            OAMessage = new HashSet<OAMessage>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ���,������Id-�ڼ���������
        /// </summary>
        [DisplayName("���")]
        public string No { get; set; }

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
        [RegularExpression(@"/^(?:(?:(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|"
            + @"(?:(?:16|[2468][048]|[3579][26])00)))(\/|-)(?:0?2\1(?:29)))|(?:(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-)"
            + @"(?:(?:(?:0?[13578]|1[02])\2(?:31))|(?:(?:0?[1,3-9]|1[0-2])\2(29|30))|(?:(?:0?[1-9])|(?:1[0-2]))\2"
            + @"(?:0?[1-9]|1\d|2[0-8])))))\s(?:([0-1]\d|2[0-3]):[0-5]\d:[0-5]\d)$/m", ErrorMessage = "{0}�ĸ�ʽ����ȷ")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        [DisplayName("���ʱ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [RegularExpression(@"/^(?:(?:(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|"
            + @"(?:(?:16|[2468][048]|[3579][26])00)))(\/|-)(?:0?2\1(?:29)))|(?:(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-)"
            + @"(?:(?:(?:0?[13578]|1[02])\2(?:31))|(?:(?:0?[1,3-9]|1[0-2])\2(29|30))|(?:(?:0?[1-9])|(?:1[0-2]))\2"
            + @"(?:0?[1-9]|1\d|2[0-8])))))\s(?:([0-1]\d|2[0-3]):[0-5]\d:[0-5]\d)$/m", ErrorMessage = "{0}�ĸ�ʽ����ȷ")]
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
        /// ������Id
        /// </summary>
        [DisplayName("������")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int TaskId { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        [DisplayName("������״̬")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int State { get; set; }

        /// <summary>
        /// �Ƿ���Ᵽ��
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// ������˵��
        /// </summary>
        [DisplayName("������˵��")]
        [StringLength(500, ErrorMessage = "{0}���ܳ���{1}�ַ�")]
        public string SubmissionThing { get; set; }

        /// <summary>
        /// �����ļ���
        /// </summary>
        [DisplayName("�����ļ���")]
        [StringLength(255, ErrorMessage = "{0}������չ�����ܶ���{1}���ַ�")]
        public string Attachment { get; set; }

        /// <summary>
        /// ��ɱ�׼
        /// </summary>
        [DisplayName("��ɱ�׼")]
        [StringLength(500, ErrorMessage = "{0}���ܳ���{1}�ַ�")]
        public string CompletionCriteria { get; set; }

        /// <summary>
        /// ����˼·������
        /// </summary>
        [DisplayName("����˼·������")]
        [StringLength(500, ErrorMessage = "{0}���ܳ���{1}�ַ�")]
        public string WorkMethod { get; set; }

        /// <summary>
        /// �������0~100����
        /// </summary>
        [DisplayName("�������")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [RegularExpression(@"^1?\d{2}$", ErrorMessage = "{0}�����벻��ȷ")]
        [Range(0, 100, ErrorMessage = "{0}�ķ�Χ��{1}~{2}")]
        public decimal Progress { get; set; }

        /// <summary>
        /// ÿ�ո��¼���
        /// </summary>
        public virtual ICollection<DailyUpdate> DailyUpdate { get; set; }

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
        /// ����������
        /// </summary>
        public virtual MajorTask Task { get; set; }
    }
}
