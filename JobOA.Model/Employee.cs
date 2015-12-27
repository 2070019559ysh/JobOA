namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 在线状态枚举
    /// </summary>
    public enum OnlineState
    {
        /// <summary>
        /// 在线
        /// </summary>
        onLine = 1,
        /// <summary>
        /// 离线
        /// </summary>
        offLine = 0
    }

    /// <summary>
    /// 员工类
    /// </summary>
    [Serializable]
    [Table("Employee")]
    public partial class Employee
    {
        /// <summary>
        /// 无参构造方法初始化主(子)任务集合
        /// </summary>
        public Employee()
        {
            ArrangePersonTask = new HashSet<MajorTask>();
            ArrangePersonSubTask = new HashSet<SubTask>();
            CheckPersonTask = new HashSet<MajorTask>();
            CheckPersonSubTask = new HashSet<SubTask>();
            ExePersonTask = new HashSet<MajorTask>();
            ExePersonSubTask = new HashSet<SubTask>();
            Roles = new HashSet<Role>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0}必须11位数字")]
        [StringLength(11, ErrorMessage = "{0}不能超过{1}个字符")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "{0}要{2}~{1}个字符")]
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("真实姓名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [StringLength(20, ErrorMessage = "{0}不能多于{1}个字符")]
        public string RealName { get; set; }

        /// <summary>
        /// 头像名
        /// </summary>
        public string HeadPicture { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 最近一次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [DisplayName("邮箱地址")]
        [StringLength(50, ErrorMessage = "{0}不能大于{1}个字符")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}的格式要正确")]
        public string Email { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 角色Id字符串列表
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        [DisplayName("部门")]
        [Required(ErrorMessage = "必须指定{0}")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public int OnlineState { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 安排人主任务集合
        /// </summary>
        public virtual ICollection<MajorTask> ArrangePersonTask { get; set; }

        /// <summary>
        /// 安排人子任务集合
        /// </summary>
        public virtual ICollection<SubTask> ArrangePersonSubTask { get; set; }

        /// <summary>
        /// 检查人主任务集合
        /// </summary>
        public virtual ICollection<MajorTask> CheckPersonTask { get; set; }

        /// <summary>
        /// 检查人子任务集合
        /// </summary>
        public virtual ICollection<SubTask> CheckPersonSubTask { get; set; }

        /// <summary>
        /// 拥有的角色
        /// </summary>
        [NotMapped]
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 执行人主任务集合
        /// </summary>
        public virtual ICollection<MajorTask> ExePersonTask { get; set; }

        /// <summary>
        /// 执行人子任务集合
        /// </summary>
        public virtual ICollection<SubTask> ExePersonSubTask { get; set; }
    }
}
