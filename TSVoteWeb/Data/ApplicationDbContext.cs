using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Data.Entities.Gene;
using TSVoteWeb.Data.Entities.Vote;

namespace TSVoteWeb.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.HasDefaultSchema("Admi");

        builder.Entity<City>()
            .HasIndex("StateId","Name")
            .IsUnique()
            .HasDatabaseName("IX_City_State_Name");

        builder.Entity<CommuneTownship>()
            .HasIndex("CityId","ZoneId","Name")
            .IsUnique()
            .HasDatabaseName("IX_CommuneTownship_City_Zone_Name");

        builder.Entity<Country>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("IX_Country_Name");

        builder.Entity<Gender>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("IX_Gender_Name");

        builder.Entity<GroupType>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("IX_GroupType_Name");

        builder.Entity<NeighborhoodSidewalk>()
            .HasIndex("CommuneTownshipId","Name")
            .IsUnique()
            .HasDatabaseName("IX_NeighborhoodSidewalk_CommuneTownship_Name");

        builder.Entity<State>()
            .HasIndex("CountryId","Name")
            .IsUnique()
            .HasDatabaseName("IX_State_Country_Name");

        builder.Entity<Zone>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("IX_Zone_Name");

        builder.Entity<Poll>()
            .HasIndex("CityId","MarketStall")
            .IsUnique()
            .HasDatabaseName("IX_Poll_CityId_MarketStall");

        builder.Entity<ApplicationUser>(b=>{
            b.ToTable("MyUser");
        });

        builder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("MyUserClaims");
        });

        builder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("MyUserLogins");
        });

        builder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("MyUserTokens");
        });

        builder.Entity<IdentityRole>(b =>
        {
            b.ToTable("MyRoles");
        });

        builder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("MyRoleClaims");
        });

        builder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("MyUserRoles");
        });


    }

    public DbSet<City> Cities { get; set; }
    public DbSet<CommuneTownship> communeTownships { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<GroupType> GroupTypes { get; set; }
    public DbSet<NeighborhoodSidewalk> NeighborhoodSidewalks { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<Poll> Polls { get; set; }
}
