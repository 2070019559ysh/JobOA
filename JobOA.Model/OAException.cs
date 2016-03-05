namespace JobOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Job_OAϵͳ�쳣��
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
        /// �쳣��Ϣ
        /// </summary>
        [DisplayName("�쳣��Ϣ")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public string ExMessage { get; set; }

        /// <summary>
        /// �쳣ʱ��
        /// </summary>
        [DisplayName("�쳣������ʱ��")]
        [Required(ErrorMessage = "{0}�Ǳ����")]
        public DateTime ExTime { get; set; }
    }
}
