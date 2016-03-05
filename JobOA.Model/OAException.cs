namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Job_OA系统异常类
    /// </summary>
    [Serializable]
    [Table("OAException")]
    public partial class OAException
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [DisplayName("异常信息")]
        [Required(ErrorMessage = "{0}是必须的")]
        public string ExMessage { get; set; }

        /// <summary>
        /// 异常时间
        /// </summary>
        [DisplayName("异常发生的时间")]
        [Required(ErrorMessage = "{0}是必须的")]
        public DateTime ExTime { get; set; }
    }
}
