using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GradAwait.Models;
using Microsoft.AspNetCore.Identity;

namespace GradAwait.Data;
public class GradAwaitDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }

    public GradAwaitDbContext(DbContextOptions<GradAwaitDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });
        modelBuilder.Entity<Projects>().HasData(new Projects
        {
            Id = 1,
            UserId = 1,
            ProjectName = "Project 1",
            Description = "This is the first project",
            Url = "https://github.com/",
        });
        modelBuilder.Entity<MessageBoard>().HasData(new MessageBoard
        {
            Id = 1,
            UserId = 1,
            Message = "Amazing post!",
            Image = "https://imgur.com/",
            Date = "5-8-24",
        });
        modelBuilder.Entity<ReactionType>().HasData(new ReactionType
        {
            Id = 1,
            Type = "Happy"
        });
        modelBuilder.Entity<ReactionType>().HasData(new ReactionType
        {
            Id = 2,
            Type = "Sad"
        });
        modelBuilder.Entity<Reactions>().HasData(new Reactions
        {
            Id = 1,
            UserId = 1,
            MsgId = 4,
            ReactionTypeId = 2,
        });
        modelBuilder.Entity<NewsLetter>().HasData(new NewsLetter
        {
            Id = 1,
            UserId = 1,
            Title = "New Newsletter Post!",
            Body = "The NSS grads are so great",
            Image = "https://imgur.com/",
            Date = "5-8-24",
        });
    }
}
