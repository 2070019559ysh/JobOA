namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 部门类
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
        /// 部门名
        /// </summary>
        [DisplayName("部门名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(10, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 员工集合
        /// </summary>
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
