namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��ɫ��
    /// </summary>
    [Serializable]
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        /// <summary>
        /// ��ɫID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        [DisplayName("��ɫ����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(20, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string Name { get; set; }

        /// <summary>
        /// ��ɫ�Ƿ�����
        /// </summary>
        [DisplayName("��ɫ�Ƿ�����")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// ���Ȩ��Id
        /// </summary>
        public string PermissionIds { get; set; }

        /// <summary>
        /// Ա������
        /// </summary>
        [NotMapped]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
