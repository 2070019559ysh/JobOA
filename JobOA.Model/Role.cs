namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 角色类
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
        /// 角色ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(20, ErrorMessage = "{0}不能多于{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 角色是否启用
        /// </summary>
        [DisplayName("角色是否启用")]
        [Required(ErrorMessage = "{0}是必须的")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 多个权限Id
        /// </summary>
        public string PermissionIds { get; set; }

        /// <summary>
        /// 员工集合
        /// </summary>
        [NotMapped]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
