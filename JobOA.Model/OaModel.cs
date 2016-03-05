namespace JobOA.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// OA的总模型类，可用来查询数据库并将更改组合在一起，这些更改稍后将作为一个单元写回存储区中
    /// </summary>
    public partial class OaModel : DbContext
    {
        /// <summary>
        /// 无参构造函数，指定了创建实体类对应的数据库的方式
        /// </summary>
        public OaModel()
            : base("name=OaModel")
        {
            Database.SetInitializer<OaModel>(new CreateDatabaseIfNotExists<OaModel>());
        }

        /// <summary>
        /// 可访问路径数据集
        /// </summary>
        public virtual DbSet<AccessPath> AccessPath { get; set; }

        /// <summary>
        /// 每日更新数据集
        /// </summary>
        public virtual DbSet<DailyUpdate> DailyUpdate { get; set; }

        /// <summary>
        /// 部门信息数据集
        /// </summary>
        public virtual DbSet<Department> Department { get; set; }

        /// <summary>
        /// 员工信息数据集
        /// </summary>
        public virtual DbSet<Employee> Employee { get; set; }

        /// <summary>
        /// OA系统异常信息数据集
        /// </summary>
        public virtual DbSet<OAException> OAException { get; set; }

        /// <summary>
        /// 通知信息数据集
        /// </summary>
        public virtual DbSet<OAMessage> OAMessage { get; set; }

        /// <summary>
        /// OA界面信息数据集
        /// </summary>
        public virtual DbSet<OAUi> OAUi { get; set; }

        /// <summary>
        /// 权限数据集
        /// </summary>
        public virtual DbSet<Permission> Permission { get; set; }

        /// <summary>
        /// 项目信息数据集
        /// </summary>
        public virtual DbSet<Project> Project { get; set; }

        /// <summary>
        /// 角色信息数据集
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// 子任务数据集
        /// </summary>
        public virtual DbSet<SubTask> SubTask { get; set; }

        /// <summary>
        /// 主任务数据集
        /// </summary>
        public virtual DbSet<MajorTask> MajorTask { get; set; }

        /// <summary>
        /// 在模型创建时，添加实体模型隐射
        /// </summary>
        /// <param name="modelBuilder">模型建立类的对象</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessPath>()
                .Property(e => e.HttpMethod)
                .IsUnicode(false);

            modelBuilder.Entity<DailyUpdate>()
                .Property(e => e.SpendTime)
                .HasPrecision(4, 0);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ArrangePersonTask)
                .WithRequired(e => e.ArrangeEmployee)
                .HasForeignKey(e => e.ArrangePersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ArrangePersonSubTask)
                .WithRequired(e => e.ArrangeEmployee)
                .HasForeignKey(e => e.ArrangePersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CheckPersonTask)
                .WithRequired(e => e.CheckEmployee)
                .HasForeignKey(e => e.CheckPersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CheckPersonSubTask)
                .WithRequired(e => e.CheckEmployee)
                .HasForeignKey(e => e.CheckPersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExePersonTask)
                .WithRequired(e => e.ExeEmployee)
                .HasForeignKey(e => e.ExePersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExePersonSubTask)
                .WithRequired(e => e.ExeEmployee)
                .HasForeignKey(e => e.ExePersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.PermissionIds)
                .IsUnicode(false);

            modelBuilder.Entity<SubTask>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<SubTask>()
                .Property(e => e.Participator)
                .IsUnicode(false);

            modelBuilder.Entity<OAException>()
               .Property(e => e.ExMessage)
               .IsUnicode(false);

            modelBuilder.Entity<SubTask>()
                .Property(e => e.Progress)
                .HasPrecision(3, 0);

            modelBuilder.Entity<SubTask>()
                .HasMany(e => e.DailyUpdate)
                .WithRequired(e => e.SubTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MajorTask>()
                .Property(e => e.Participator)
                .IsUnicode(false);

            modelBuilder.Entity<MajorTask>()
                .HasMany(e => e.SubTask)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);
        }
    }
}
