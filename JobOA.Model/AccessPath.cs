namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// �ɷ���·����
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
        /// ����·��Id
        /// </summary>
        public int AccessPathId { get; set; }

        /// <summary>
        /// ���ʷ�ʽ
        /// </summary>
        [DisplayName("���ʷ�ʽ")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [StringLength(20, ErrorMessage = "{0}���ܳ���{1}���ַ�")]
        public string HttpMethod { get; set; }

        /// <summary>
        /// ����·��
        /// </summary>
        [DisplayName("����·��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public string Path { get; set; }

        /// <summary>
        /// ������Ȩ��
        /// </summary>
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
