using Attendence_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System
{
    public class TrainingDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public TrainingDbContext()
        {
            _connectionString = @"Server = DESKTOP-UARLHUC\SQLEXPRESS; Database = Csharpb12; Trusted_Connection = True;";
            _migrationAssembly = Assembly.GetExecutingAssembly().GetName().Name;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendence>().ToTable("Attendences");

            modelBuilder.Entity<CourseRegistration>().ToTable("CourseRegistrations");

         
            modelBuilder.Entity<CourseRegistration>().HasKey((x) => new { x.CourseId, x.StudentId });


            modelBuilder.Entity<Course>()
                .HasMany(x => x.StudentAttendence)
                .WithOne(y => y.Course)
                .HasForeignKey(z => z.CourseID);

            modelBuilder.Entity<CourseRegistration>()
                .HasOne(x => x.Course)
                .WithMany(y => y.CourseStudents)
                .HasForeignKey(z => z.CourseId);

            modelBuilder.Entity<CourseRegistration>()
                .HasOne(x => x.Student)
                .WithMany(y => y.StudentCourses)
                .HasForeignKey(z => z.StudentId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }








    }
}
