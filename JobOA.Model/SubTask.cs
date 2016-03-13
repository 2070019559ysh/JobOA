namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 子任务类
    /// </summary>
    [Serializable]
    [Table("SubTask")]
    public partial class SubTask
    {
        public SubTask()
        {
            DailyUpdate = new HashSet<DailyUpdate>();
            OAMessage = new HashSet<OAMessage>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 编号,父任务Id-第几个子任务
        /// </summary>
        [DisplayName("编号")]
        public string No { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        [DisplayName("任务名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(100, ErrorMessage = "{0}不能多于{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 安排人Id
        /// </summary>
        public int ArrangePersonId { get; set; }

        /// <summary>
        /// 执行人Id
        /// </summary>
        [DisplayName("执行人")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int ExePersonId { get; set; }

        /// <summary>
        /// 检查（验收）人Id
        /// </summary>
        [DisplayName("检查（验收）人")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int CheckPersonId { get; set; }

        /// <summary>
        /// 参与者Id列表字符串
        /// </summary>
        public string Participator { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DisplayName("开始时间")]
        [Required(ErrorMessage = "{0}是必须的")]
        [RegularExpression(@"/^(?:(?:(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|"
            + @"(?:(?:16|[2468][048]|[3579][26])00)))(\/|-)(?:0?2\1(?:29)))|(?:(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-)"
            + @"(?:(?:(?:0?[13578]|1[02])\2(?:31))|(?:(?:0?[1,3-9]|1[0-2])\2(29|30))|(?:(?:0?[1-9])|(?:1[0-2]))\2"
            + @"(?:0?[1-9]|1\d|2[0-8])))))\s(?:([0-1]\d|2[0-3]):[0-5]\d:[0-5]\d)$/m", ErrorMessage = "{0}的格式不正确")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [DisplayName("完成时间")]
        [Required(ErrorMessage = "{0}是必须的")]
        [RegularExpression(@"/^(?:(?:(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|"
            + @"(?:(?:16|[2468][048]|[3579][26])00)))(\/|-)(?:0?2\1(?:29)))|(?:(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-)"
            + @"(?:(?:(?:0?[13578]|1[02])\2(?:31))|(?:(?:0?[1,3-9]|1[0-2])\2(29|30))|(?:(?:0?[1-9])|(?:1[0-2]))\2"
            + @"(?:0?[1-9]|1\d|2[0-8])))))\s(?:([0-1]\d|2[0-3]):[0-5]\d:[0-5]\d)$/m", ErrorMessage = "{0}的格式不正确")]
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? CommitTime { get; set; }

        /// <summary>
        /// 主任务Id
        /// </summary>
        [DisplayName("主任务")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int TaskId { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        [DisplayName("主任务状态")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int State { get; set; }

        /// <summary>
        /// 是否对外保密
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// 交付物说明
        /// </summary>
        [DisplayName("交付物说明")]
        [StringLength(500, ErrorMessage = "{0}不能超过{1}字符")]
        public string SubmissionThing { get; set; }

        /// <summary>
        /// 附件文件名
        /// </summary>
        [DisplayName("附件文件名")]
        [StringLength(255, ErrorMessage = "{0}包括拓展名不能多于{1}个字符")]
        public string Attachment { get; set; }

        /// <summary>
        /// 完成标准
        /// </summary>
        [DisplayName("完成标准")]
        [StringLength(500, ErrorMessage = "{0}不能超过{1}字符")]
        public string CompletionCriteria { get; set; }

        /// <summary>
        /// 工作思路、方法
        /// </summary>
        [DisplayName("工作思路、方法")]
        [StringLength(500, ErrorMessage = "{0}不能超过{1}字符")]
        public string WorkMethod { get; set; }

        /// <summary>
        /// 任务进度0~100整数
        /// </summary>
        [DisplayName("任务进度")]
        [Required(ErrorMessage = "{0}是必须的")]
        [RegularExpression(@"^1?\d{2}$", ErrorMessage = "{0}的输入不正确")]
        [Range(0, 100, ErrorMessage = "{0}的范围是{1}~{2}")]
        public decimal Progress { get; set; }

        /// <summary>
        /// 每日更新集合
        /// </summary>
        public virtual ICollection<DailyUpdate> DailyUpdate { get; set; }

        //导航属性
        /// <summary>
        /// 参与人
        /// </summary>
        public virtual Employee ArrangeEmployee { get; set; }

        /// <summary>
        /// 执行人
        /// </summary>
        public virtual Employee ExeEmployee { get; set; }

        /// <summary>
        /// 检查人
        /// </summary>
        public virtual Employee CheckEmployee { get; set; }

        /// <summary>
        /// 负责通知的信息
        /// </summary>
        public virtual ICollection<OAMessage> OAMessage { get; set; }

        /// <summary>
        /// 所属主任务
        /// </summary>
        public virtual MajorTask Task { get; set; }
    }
}
