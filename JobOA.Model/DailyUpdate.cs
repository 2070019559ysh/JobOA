namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ������ÿ�ո�����
    /// </summary>
    [Serializable]
    [Table("DailyUpdate")]
    public partial class DailyUpdate
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        [DisplayName("����ʱ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        [Range(typeof(DateTime), "2015-10-7 12:00:00", "9999-12-31 23:59:59", ErrorMessage = "{0}Ҫ�ں���Χ")]
        public DateTime Time { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DisplayName("��������")]
        [Required(ErrorMessage="{0}�Ǳ����")]
        [StringLength(500, ErrorMessage = "{0}Ҫ������ˣ���Ӧ��500�ַ�")]
        public string WorkContent { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [DisplayName("������������")]
        [StringLength(500, ErrorMessage = "{0}Ҫ������ˣ���Ӧ��500�ַ�")]
        public string ExtraTask { get; set; }

        /// <summary>
        /// ������������ʱ�䣨����,������
        /// </summary>
        [DisplayName("������������ʱ��")]
        [Range(0, 1440, ErrorMessage = "{0}Ӧ��{1}��{2}������")]
        public decimal? SpendTime { get; set; }

        /// <summary>
        /// ������Id
        /// </summary>
        [DisplayName("����������������")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public int SubTaskId { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual SubTask SubTask { get; set; }
    }
}
