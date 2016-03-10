namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Job_OA系统发送信息的类
    /// </summary>
    [Serializable]
    [Table("OAMessage")]
    public partial class OAMessage
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 信息标题
        /// </summary>
        [DisplayName("信息标题")]
        [StringLength(100, ErrorMessage = "{0}不能多于{1}个字符")]
        public string Title { get; set; }

        /// <summary>
        /// 额外信息
        /// </summary>
        [DisplayName("额外信息")]
        [StringLength(1000, ErrorMessage = "{0}不能多于{1}个字符")]
        public string ExtraMessage { get; set; }

        /// <summary>
        /// 关联主任务Id
        /// </summary>
        [DisplayName("关联主任务")]
        public int? TaskId { get; set; }

        /// <summary>
        /// 关联子任务Id
        /// </summary>
        [DisplayName("关联子任务")]
        public int? SubTaskId { get; set; }

        /// <summary>
        /// 发消息员工Id
        /// </summary>
        [DisplayName("发消息员工")]
        public int FromEmployeeId { get; set; }

        /// <summary>
        /// 收消息员工Id
        /// </summary>
        [DisplayName("收消息员工")]
        public int ToEmployeeId { get; set; }

        /// <summary>
        /// 发消息员工
        /// </summary>
        public virtual Employee FromEmployee { get; set; }

        /// <summary>
        /// 收消息员工
        /// </summary>
        public virtual Employee ToEmployee { get; set; }

        /// <summary>
        /// 关联的主任务
        /// </summary>
        public virtual MajorTask Task { get; set; }

        /// <summary>
        /// 关联的子任务
        /// </summary>
        public virtual SubTask SubTask { get; set; }
    }
}
