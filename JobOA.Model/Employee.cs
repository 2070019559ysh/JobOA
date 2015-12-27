namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����״̬ö��
    /// </summary>
    public enum OnlineState
    {
        /// <summary>
        /// ����
        /// </summary>
        onLine = 1,
        /// <summary>
        /// ����
        /// </summary>
        offLine = 0
    }

    /// <summary>
    /// Ա����
    /// </summary>
    [Serializable]
    [Table("Employee")]
    public partial class Employee
    {
        /// <summary>
        /// �޲ι��췽����ʼ����(��)���񼯺�
        /// </summary>
        public Employee()
        {
            ArrangePersonTask = new HashSet<MajorTask>();
            ArrangePersonSubTask = new HashSet<SubTask>();
            CheckPersonTask = new HashSet<MajorTask>();
            CheckPersonSubTask = new HashSet<SubTask>();
            ExePersonTask = new HashSet<MajorTask>();
            ExePersonSubTask = new HashSet<SubTask>();
            Roles = new HashSet<Role>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        [DisplayName("�û���")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0}����11λ����")]
        [StringLength(11, ErrorMessage = "{0}���ܳ���{1}���ַ�")]
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [DisplayName("����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "{0}Ҫ{2}~{1}���ַ�")]
        public string Password { get; set; }

        /// <summary>
        /// ��ʵ����
        /// </summary>
        [DisplayName("��ʵ����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(20, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string RealName { get; set; }

        /// <summary>
        /// ͷ����
        /// </summary>
        public string HeadPicture { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// ���һ�ε�¼ʱ��
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// �����ַ
        /// </summary>
        [DisplayName("�����ַ")]
        [StringLength(50, ErrorMessage = "{0}���ܴ���{1}���ַ�")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}�ĸ�ʽҪ��ȷ")]
        public string Email { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// ��ɫId�ַ����б�
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// ����Id
        /// </summary>
        [DisplayName("����")]
        [Required(ErrorMessage = "����ָ��{0}")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        public int OnlineState { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// �����������񼯺�
        /// </summary>
        public virtual ICollection<MajorTask> ArrangePersonTask { get; set; }

        /// <summary>
        /// �����������񼯺�
        /// </summary>
        public virtual ICollection<SubTask> ArrangePersonSubTask { get; set; }

        /// <summary>
        /// ����������񼯺�
        /// </summary>
        public virtual ICollection<MajorTask> CheckPersonTask { get; set; }

        /// <summary>
        /// ����������񼯺�
        /// </summary>
        public virtual ICollection<SubTask> CheckPersonSubTask { get; set; }

        /// <summary>
        /// ӵ�еĽ�ɫ
        /// </summary>
        [NotMapped]
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// ִ���������񼯺�
        /// </summary>
        public virtual ICollection<MajorTask> ExePersonTask { get; set; }

        /// <summary>
        /// ִ���������񼯺�
        /// </summary>
        public virtual ICollection<SubTask> ExePersonSubTask { get; set; }
    }
}
