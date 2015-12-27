namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Ȩ����
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
        /// Ȩ������
        /// </summary>
        [DisplayName("Ȩ������")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(50, ErrorMessage = "{0}Ҫ������ˣ����ܶ���{1}���ַ�")]
        public string Description { get; set; }

        /// <summary>
        /// �ɷ���·��Id
        /// </summary>
        public int? AccessPathId { get; set; }

        /// <summary>
        /// �����Ŀɷ���·��
        /// </summary>
        public virtual AccessPath AccessPath { get; set; }
    }
}
