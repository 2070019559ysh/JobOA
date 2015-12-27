namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 项目、任务进度状态
    /// </summary>
    public enum ProgressState
    {
        /// <summary>
        /// 未完成
        /// </summary>
        NotFinished=0,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed=1,
        /// <summary>
        /// 已验收
        /// </summary>
        Acceptance=2,
        /// <summary>
        /// 验收不通过
        /// </summary>
        AcceptanceNotThrough=3,
        /// <summary>
        /// 终止
        /// </summary>
        Stop=4
    }

    /// <summary>
    /// 工作项目类
    /// </summary>
    [Serializable]
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<MajorTask>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        [DisplayName("项目名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(100, ErrorMessage = "{0}不能多于{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 项目简述
        /// </summary>
        [DisplayName("项目简述")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(500, ErrorMessage = "{0}不能多于{1}个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 是否保密
        /// </summary>
        [DisplayName("是否保密")]
        [Required(ErrorMessage = "{0}是必须的")]
        public bool IsSecrecy { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        [DisplayName("项目状态")]
        [Required(ErrorMessage = "{0}是必须的")]
        public int State { get; set; }

        /// <summary>
        /// 所属的主任务集合
        /// </summary>
        public virtual ICollection<MajorTask> Task { get; set; }
    }
}
