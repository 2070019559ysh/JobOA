namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��Ŀ���������״̬
    /// </summary>
    public enum ProgressState
    {
        /// <summary>
        /// δ���
        /// </summary>
        NotFinished=0,
        /// <summary>
        /// �����
        /// </summary>
        Completed=1,
        /// <summary>
        /// ������
        /// </summary>
        Acceptance=2,
        /// <summary>
        /// ���ղ�ͨ��
        /// </summary>
        AcceptanceNotThrough=3,
        /// <summary>
        /// ��ֹ
        /// </summary>
        Stop=4
    }

    /// <summary>
    /// ������Ŀ��
    /// </summary>
    [Serializable]
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<MajorTask>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ��Ŀ��
        /// </summary>
        [DisplayName("��Ŀ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(100, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string Name { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [DisplayName("��Ŀ����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(500, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string Description { get; set; }

        /// <summary>
        /// �Ƿ���
        /// </summary>
        [DisplayName("�Ƿ���")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// ��Ŀ״̬
        /// </summary>
        [DisplayName("��Ŀ״̬")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int State { get; set; }

        /// <summary>
        /// �����������񼯺�
        /// </summary>
        public virtual ICollection<MajorTask> Task { get; set; }
    }
}
