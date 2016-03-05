namespace JobOA.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// OA����ģ���࣬��������ѯ���ݿⲢ�����������һ����Щ�����Ժ���Ϊһ����Ԫд�ش洢����
    /// </summary>
    public partial class OaModel : DbContext
    {
        /// <summary>
        /// �޲ι��캯����ָ���˴���ʵ�����Ӧ�����ݿ�ķ�ʽ
        /// </summary>
        public OaModel()
            : base("name=OaModel")
        {
            Database.SetInitializer<OaModel>(new CreateDatabaseIfNotExists<OaModel>());
        }

        /// <summary>
        /// �ɷ���·�����ݼ�
        /// </summary>
        public virtual DbSet<AccessPath> AccessPath { get; set; }

        /// <summary>
        /// ÿ�ո������ݼ�
        /// </summary>
        public virtual DbSet<DailyUpdate> DailyUpdate { get; set; }

        /// <summary>
        /// ������Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<Department> Department { get; set; }

        /// <summary>
        /// Ա����Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<Employee> Employee { get; set; }

        /// <summary>
        /// OAϵͳ�쳣��Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<OAException> OAException { get; set; }

        /// <summary>
        /// ֪ͨ��Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<OAMessage> OAMessage { get; set; }

        /// <summary>
        /// OA������Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<OAUi> OAUi { get; set; }

        /// <summary>
        /// Ȩ�����ݼ�
        /// </summary>
        public virtual DbSet<Permission> Permission { get; set; }

        /// <summary>
        /// ��Ŀ��Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<Project> Project { get; set; }

        /// <summary>
        /// ��ɫ��Ϣ���ݼ�
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// ���������ݼ�
        /// </summary>
        public virtual DbSet<SubTask> SubTask { get; set; }

        /// <summary>
        /// ���������ݼ�
        /// </summary>
        public virtual DbSet<MajorTask> MajorTask { get; set; }

        /// <summary>
        /// ��ģ�ʹ���ʱ�����ʵ��ģ������
        /// </summary>
        /// <param name="modelBuilder">ģ�ͽ�����Ķ���</param>
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
