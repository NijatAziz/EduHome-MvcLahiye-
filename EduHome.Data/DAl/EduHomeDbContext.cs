using EduHome.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Data.DAl
{
    public class EduHomeDbContext : IdentityDbContext<User>
    {

        public EduHomeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherFaculty> TeacherFaculties { get; set; }
        public DbSet<TeacherHobby> TeacherHobbies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Blog>(b =>
        //    {
        //        b.HasOne(p => p.Author)
        //          .WithMany(p => p.Blogs)
        //          .HasForeignKey(p => p.AuthorId);
        //    });

        //}
    }
}
