namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 权限类
    /// </summary>
    [Serializable]
    [Table("Permission")]
    public partial class Permission
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        [DisplayName("权限描述")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(50, ErrorMessage = "{0}要简洁明了，不能多于{1}个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 可访问路径Id
        /// </summary>
        public int? AccessPathId { get; set; }

        /// <summary>
        /// 关联的可访问路径
        /// </summary>
        public virtual AccessPath AccessPath { get; set; }
    }
}
