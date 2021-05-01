namespace AbsentProject.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AbsentModel : DbContext
    {
        public AbsentModel()
            : base("name=AbsentConnection")
        {
        }

        public virtual DbSet<Absent> Absents { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<EmpType> EmpTypes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionRole> PermissionRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Absents)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dept>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Dept)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Emp>()
                .HasMany(e => e.Absents)
                .WithRequired(e => e.Emp)
                .HasForeignKey(e => e.TecherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Emp>()
                .HasMany(e => e.CourseTeachers)
                .WithRequired(e => e.Emp)
                .HasForeignKey(e => e.TeacherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Emp>()
                .HasMany(e => e.RoleUsers)
                .WithRequired(e => e.Emp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmpType>()
                .HasMany(e => e.Emps)
                .WithRequired(e => e.EmpType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.PermissionRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Absents)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UpdatedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
