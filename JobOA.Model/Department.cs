namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
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
        [StringLength(10, ErrorMessage = "{0}���ܳ���{1}���ַ�")]
        public string Name { get; set; }

        /// <summary>
        /// Ա������
        /// </summary>
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
