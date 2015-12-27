namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// OA的界面信息类，包括图片/标题/内容
    /// </summary>
    [Serializable]
    [Table("OAUi")]
    public partial class OAUi
    {
        /// <summary>
        /// 界面信息Id
        /// </summary>
        [Key]
        public int UiId { get; set; }

        /// <summary>
        /// 界面图片
        /// </summary>
        [DisplayName("界面图片")]
        [StringLength(50, ErrorMessage = "{0}不能多于{1}个字符")]
        public string UiImg { get; set; }

        /// <summary>
        /// 界面标题
        /// </summary>
        [DisplayName("界面标题")]
        [StringLength(100, ErrorMessage = "{0}不能多于{1}个字符")]
        public string UiTitle { get; set; }

        /// <summary>
        /// 界面内容信息
        /// </summary>
        public string UiMess { get; set; }
    }
}
