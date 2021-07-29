using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApp.Site.Models
{
	public class ApplicationDataContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Picture> Pictures { get; set; }
		public DbSet<NewsItem> News { get; set; }

		public ApplicationDataContext() : base() 
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ApplicationUser>().HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserID);
			builder.Entity<ApplicationUser>().HasMany(u => u.Liked).WithMany(p => p.LikedUsers);
			builder.Entity<ApplicationUser>().HasMany(u => u.Posts).WithOne(p => p.Author).HasForeignKey(p => p.AuthorID);
			builder.Entity<Comment>().HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
			builder.Entity<Comment>().HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserID);
			builder.Entity<Post>().HasOne(p => p.Author).WithMany(u => u.Posts).HasForeignKey(p => p.AuthorID);
			builder.Entity<Post>().HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
			builder.Entity<Post>().HasMany(p => p.LikedUsers).WithMany(u => u.Liked);
			base.OnModelCreating(builder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=testDataBase.db");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
