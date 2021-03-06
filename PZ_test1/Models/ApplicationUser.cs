﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PZ_test1.Models
{
    public class ApplicationUser : IdentityUser
    {
       public virtual Employees Employees { get; set; }
        public virtual Students Students { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext()
//            : base("DefaultConnection", throwIfV1Schema: false)
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
//            return new ApplicationDbContext();
//        }

//        //moj kod
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            // one-to-zero or one relationship between ApplicationUser and Customer
//            // UserId column in Customers table will be foreign key
//            modelBuilder.Entity<ApplicationUser>()
//                .HasOptional(m => m.Employees)
//                .WithRequired(m => m.ApplicationUser);
////                            .Map(p => p.MapKey("UserId"));
//            //
//            modelBuilder.Entity<ApplicationUser>()
//                .HasOptional(m => m.Students)
//                .WithRequired(m => m.ApplicationUser);
////                            .Map(p => p.MapKey("UserId"));

//            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
//            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
//            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
//            //modelBuilder.Entity<Students>()
//            //    .HasMany(m => m.StudentCourses)
//            //    .WithRequired(m=> m.Students)
//            //    .Map(x =>
//            //        {
//            //            x.MapKey("StudentId");
//            //            x.ToTable("ModelStudentCourses");
//            //        }
//            //    );
//            //temat obrad
//            //modelBuilder.Entity<Students>()
//            //    .HasMany(u => u.StudentCourses)
//            //    .WithMany()
//            //    .Map(x =>
//            //    {
//            //        x.MapLeftKey("Id");
//            //        x.MapRightKey("TheirFriends");
//            //        x.ToTable("ModelStudentCourses");
//            //    });

//            //modelBuilder.Entity<Students>().HasMany<StudentCourses>(s => s.StudentCourses).WithRequired(c => c.Students).Map(c =>
//            //{
//            //    c.MapKey("Id");
//            //    c.ToTable("ModelStudentCourses");
//            //});

//            //koniec tematu obrad
//        }

//      /*  public virtual DbSet<CoursesOfStudy> CoursesOfStudy { get; set; }
//        public virtual DbSet<Employees> Employees { get; set; }
//        public virtual DbSet<Fields> Fields { get; set; }
//        public virtual DbSet<FilledFields> FilledFields { get; set; }
//        public virtual DbSet<Forms> Forms { get; set; }
//        public virtual DbSet<RepetedSubject> RepetedSubject { get; set; }
//        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
//        public virtual DbSet<Students> Students { get; set; }
//        public virtual DbSet<Timetable> Timetable { get; set; }*/
//    }
//}


//////moj kod
////protected override void OnModelCreating(DbModelBuilder modelBuilder)
////{
////    base.OnModelCreating(modelBuilder);

////    // one-to-zero or one relationship between ApplicationUser and Customer
////    // UserId column in Customers table will be foreign key
////    modelBuilder.Entity<ApplicationUser>()
////        .HasOptional(m => m.Employees)
////        .WithRequired(m => m.ApplicationUser)
////        .Map(p => p.MapKey("UserId"));

////    modelBuilder.Entity<ApplicationUser>()
////        .HasOptional(m => m.Students)
////        .WithRequired(m => m.ApplicationUser)
////        .Map(p => p.MapKey("UserId"));
////}