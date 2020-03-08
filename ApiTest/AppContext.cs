﻿using ApiTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolCourse> SchoolCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(bc => new { bc.StudentId, bc.CourseId });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.StudentCourses)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<SchoolCourse>()
       .HasKey(bc => new { bc.SchoolId, bc.CourseId });
            modelBuilder.Entity<SchoolCourse>()
                .HasOne(bc => bc.School)
                .WithMany(b => b.SchoolCourses)
                .HasForeignKey(bc => bc.SchoolId);
            modelBuilder.Entity<SchoolCourse>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.SchoolCourses)
                .HasForeignKey(bc => bc.CourseId);
        }
    }
}
