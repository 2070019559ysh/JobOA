namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 子任务每日更新类
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
        /// 当天更新时间
        /// </summary>
        [DisplayName("更新时间")]
        [Required(ErrorMessage = "{0}是必须的")]
        [Range(typeof(DateTime), "2015-10-7 12:00:00", "9999-12-31 23:59:59", ErrorMessage = "{0}要在合理范围")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        [DisplayName("工作内容")]
        [Required(ErrorMessage="{0}是必须的")]
        [StringLength(500, ErrorMessage = "{0}要简短明了，不应超500字符")]
        public string WorkContent { get; set; }

        /// <summary>
        /// 额外任务描述
        /// </summary>
        [DisplayName("额外任务描述")]
        [StringLength(500, ErrorMessage = "{0}要简短明了，不应超500字符")]
        public string ExtraTask { get; set; }

        /// <summary>
        /// 额外任务所花时间（分钟,整数）
        /// </summary>
        [DisplayName("额外任务所花时间")]
        [Range(0, 1440, ErrorMessage = "{0}应在{1}到{2}分钟内")]
        public decimal? SpendTime { get; set; }

        /// <summary>
        /// 子任务Id
        /// </summary>
        [DisplayName("更新所属的子任务")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int SubTaskId { get; set; }

        /// <summary>
        /// 子任务
        /// </summary>
        public virtual SubTask SubTask { get; set; }
    }
}
