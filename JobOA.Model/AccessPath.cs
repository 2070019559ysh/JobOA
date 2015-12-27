namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 可访问路径类
    /// </summary>
    [Serializable]
    [Table("AccessPath")]
    public partial class AccessPath
    {
        public AccessPath()
        {
            Permission = new HashSet<Permission>();
        }

        /// <summary>
        /// 访问路径Id
        /// </summary>
        public int AccessPathId { get; set; }

        /// <summary>
        /// 访问方式
        /// </summary>
        [DisplayName("访问方式")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(20, ErrorMessage = "{0}不能超过{1}个字符")]
        public string HttpMethod { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        [DisplayName("访问路径")]
        [Required(ErrorMessage = "{0}是必须的")]
        public string Path { get; set; }

        /// <summary>
        /// 关联的权限
        /// </summary>
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
