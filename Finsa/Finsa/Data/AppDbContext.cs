using Finsa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AboutSlider> AboutSliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogToCategory> BlogToCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<PageImage> PageImages { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToBlog> TagToBlogs { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSocial> TeamSocials { get; set; }
        public DbSet<TeamToSkill> TeamToSkills { get; set; }
        public DbSet<CommentSelf> CommentSelves { get; set; }
    }
}
