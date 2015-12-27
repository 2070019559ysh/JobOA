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
        /// 额外信息
        /// </summary>
        [DisplayName("额外信息")]
        [StringLength(100, ErrorMessage = "{0}不能多于{1}个字符")]
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
        /// 关联的主任务
        /// </summary>
        public virtual MajorTask Task { get; set; }

        /// <summary>
        /// 关联的子任务
        /// </summary>
        public virtual SubTask SubTask { get; set; }
    }
}
