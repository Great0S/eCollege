using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eCollege.Data
{
    public partial class UCMSContext : DbContext
    {
        public UCMSContext(DbContextOptions<UCMSContext> options)
                : base(options)
            {
            }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounter>(entity =>
            {
                entity.ToTable("accounter", "ucms");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("employee_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNum).HasColumnName("account_num");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("employee_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReceiptNo).HasColumnName("receipt_no");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accounter)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("receipts$employee_id");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("batch");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fees).HasColumnName("fees");

                entity.Property(e => e.SpecId)
                    .IsRequired()
                    .HasColumnName("spec_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.FeesNavigation)
                    .WithMany(p => p.Batch)
                    .HasForeignKey(d => d.Fees)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_batch_fees");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.Batch)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_batch_specialization");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseName)
                    .HasName("PK_course");

                entity.ToTable("course");

                entity.Property(e => e.CourseName)
                    .HasColumnName("course_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_course_course");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_departments_id");

                entity.ToTable("departments", "ucms");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees", "ucms");

                entity.HasIndex(e => e.Department)
                    .HasName("dept_no_idx");

                entity.HasIndex(e => e.Job)
                    .HasName("job_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(45);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45);

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasColumnName("job")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_employees_departments");

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_employees_jobs");
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.HasKey(e => e.FeeNo)
                    .HasName("PK_fees");

                entity.ToTable("fees");

                entity.Property(e => e.FeeNo)
                    .HasColumnName("fee_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegisterFee)
                    .HasColumnName("register_fee")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.StudyFee)
                    .HasColumnName("study_fee")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("smallmoney")
                    .HasComputedColumnSql("[register_fee]+[study_fee]")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.YearTotal)
                    .HasColumnName("year_total")
                    .HasColumnType("smallmoney")
                    .HasComputedColumnSql("[register_fee]+[study_fee])*(2")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_jobs_job_id");

                entity.ToTable("jobs", "ucms");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.JobId)
                    .IsRequired()
                    .HasColumnName("job_id")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Programs>(entity =>
            {
                entity.ToTable("programs", "ucms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnName("duration")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Registeration>(entity =>
            {
                entity.HasKey(e => e.RegisterId)
                    .HasName("PK_registeration_register_id");

                entity.ToTable("registeration", "ucms");

                entity.HasIndex(e => e.ProgramId)
                    .HasName("program_id_idx");

                entity.HasIndex(e => e.SpecId)
                    .HasName("spec_id_idx");

                entity.HasIndex(e => e.StdId)
                    .HasName("std_id_idx");

                entity.Property(e => e.RegisterId)
                    .HasColumnName("register_id")
                    .HasMaxLength(45);

                entity.Property(e => e.Batch)
                    .IsRequired()
                    .HasColumnName("batch")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Docs)
                    .HasColumnName("docs")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.MedExam)
                    .IsRequired()
                    .HasColumnName("med_exam")
                    .HasMaxLength(45);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(45);

                entity.Property(e => e.ProgramId).HasColumnName("program_id");

                entity.Property(e => e.Recommend)
                    .IsRequired()
                    .HasColumnName("recommend")
                    .HasMaxLength(45);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnName("semester")
                    .HasMaxLength(50);

                entity.Property(e => e.SpecId)
                    .IsRequired()
                    .HasColumnName("spec_id")
                    .HasMaxLength(50);

                entity.Property(e => e.StdId).HasColumnName("std_id");

                entity.Property(e => e.SubjectType)
                    .IsRequired()
                    .HasColumnName("subject_type")
                    .HasMaxLength(45);

                entity.Property(e => e.UniId)
                    .IsRequired()
                    .HasColumnName("uni_id")
                    .HasMaxLength(45);

                entity.HasOne(d => d.BatchNavigation)
                    .WithMany(p => p.Registeration)
                    .HasForeignKey(d => d.Batch)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_registeration_batch");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Registeration)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("registeration$program_id");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Registeration)
                    .HasForeignKey(d => d.StdId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("registeration$std_id");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasColumnName("room_name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("score");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasMaxLength(50);

                entity.Property(e => e.Term_Grade)
                    .HasColumnName("term_grade")
                    .HasMaxLength(50);

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.RegId)
                    .IsRequired()
                    .HasColumnName("reg_id")
                    .HasMaxLength(45);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnName("semester")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.SubId)
                    .IsRequired()
                    .HasColumnName("sub_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Reg)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.RegId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_score_registeration");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_score_subjects");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => e.SpecName)
                    .HasName("PK_specialization_id");

                entity.ToTable("specialization", "ucms");

                entity.HasIndex(e => e.DeptartmentId)
                    .HasName("dept_no_idx");

                entity.Property(e => e.SpecName)
                    .HasColumnName("spec_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasColumnName("course")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeptartmentId)
                    .IsRequired()
                    .HasColumnName("deptartment_id")
                    .HasMaxLength(45);

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Specialization)
                    .HasForeignKey(d => d.Course)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_specialization_course");

                entity.HasOne(d => d.Deptartment)
                    .WithMany(p => p.Specialization)
                    .HasForeignKey(d => d.DeptartmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_specialization_departments");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student", "ucms");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("binary(4048)");

                entity.Property(e => e.RegId)
                    .IsRequired()
                    .HasColumnName("reg_id")
                    .HasMaxLength(45);

                entity.Property(e => e.Religon)
                    .HasColumnName("religon")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_subjects_id");

                entity.ToTable("subjects", "ucms");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Hours).HasColumnName("hours");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.HasKey(e => e.SchId)
                    .HasName("PK_timetable");

                entity.ToTable("timetable");

                entity.Property(e => e.SchId)
                    .HasColumnName("sch_id")
                    .HasColumnType("numeric");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("numeric");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasColumnName("day")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasColumnName("month")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Timetable)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_timetable_room");
            });
        }

        public virtual DbSet<Accounter> Accounter { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<Registeration> Registeration { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }

        // Unable to generate entity type for table 'ucms.advisor'. Please see the warning messages.
        // Unable to generate entity type for table 'ucms.interview'. Please see the warning messages.
        // Unable to generate entity type for table 'ucms.med_exam'. Please see the warning messages.
    }
}