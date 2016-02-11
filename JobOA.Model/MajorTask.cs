namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 主任务类
    /// </summary>
    [Serializable]
    [Table("MajorTask")]
    public partial class MajorTask
    {
        /// <summary>
        /// 无参构造函数初始化信息、子任务
        /// </summary>
        public MajorTask()
        {
            OAMessage = new HashSet<OAMessage>();
            SubTask = new HashSet<SubTask>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

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
        [RegularExpression(@"^\d{4}\D{1}\d{2}\D{1}\d{2}\D{1}(\d{1,2}:\d{1,2}:\d{1,2})?$", ErrorMessage = "{0}的格式不正确")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [DisplayName("完成时间")]
        [Required(ErrorMessage = "{0}是必须的")]
        [RegularExpression(@"^\d{4}\D{1}\d{2}\D{1}\d{2}\D{1}(\d{1,2}:\d{1,2}:\d{1,2})?$", ErrorMessage = "{0}的格式不正确")]
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
        /// 任务状态
        /// </summary>
        [DisplayName("主任务状态")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int State { get; set; }

        /// <summary>
        /// 是否已经短信通知
        /// </summary>
        public bool IsNotice { get; set; }

        /// <summary>
        /// 是否对外保密
        /// </summary>
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// 附件文件名
        /// </summary>
        [DisplayName("附件文件名")]
        [StringLength(255, ErrorMessage = "{0}包括拓展名不能多于{1}个字符")]
        public string Attachment { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        [DisplayName("所属项目")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int ProjectId { get; set; }

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
        /// 所属项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 子任务
        /// </summary>
        public virtual ICollection<SubTask> SubTask { get; set; }
    }
}
