namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Job_OAϵͳ������Ϣ����
    /// </summary>
    [Serializable]
    [Table("OAMessage")]
    public partial class OAMessage
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        [DisplayName("��Ϣ����")]
        [StringLength(100, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string Title { get; set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        [DisplayName("������Ϣ")]
        [StringLength(1000, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string ExtraMessage { get; set; }

        /// <summary>
        /// ����������Id
        /// </summary>
        [DisplayName("����������")]
        public int? TaskId { get; set; }

        /// <summary>
        /// ����������Id
        /// </summary>
        [DisplayName("����������")]
        public int? SubTaskId { get; set; }

        /// <summary>
        /// ����ϢԱ��Id
        /// </summary>
        [DisplayName("����ϢԱ��")]
        public int FromEmployeeId { get; set; }

        /// <summary>
        /// ����ϢԱ��Id
        /// </summary>
        [DisplayName("����ϢԱ��")]
        public int ToEmployeeId { get; set; }

        /// <summary>
        /// ����ϢԱ��
        /// </summary>
        public virtual Employee FromEmployee { get; set; }

        /// <summary>
        /// ����ϢԱ��
        /// </summary>
        public virtual Employee ToEmployee { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public virtual MajorTask Task { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public virtual SubTask SubTask { get; set; }
    }
}
