namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// OA�Ľ�����Ϣ�࣬����ͼƬ/����/����
    /// </summary>
    [Serializable]
    [Table("OAUi")]
    public partial class OAUi
    {
        /// <summary>
        /// ������ϢId
        /// </summary>
        [Key]
        public int UiId { get; set; }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        [DisplayName("����ͼƬ")]
        [StringLength(50, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string UiImg { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [DisplayName("�������")]
        [StringLength(100, ErrorMessage = "{0}���ܶ���{1}���ַ�")]
        public string UiTitle { get; set; }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        public string UiMess { get; set; }
    }
}
