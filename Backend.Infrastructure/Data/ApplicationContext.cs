using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<AAP> AAP { get; set; }
        public DbSet<Audience> Audience { get; set; }
        public DbSet<AudiencePack> AudiencePack { get; set; }
        public DbSet<EmotionalResult> EmotionalResult { get; set; }
        public DbSet<EmotionalExpect> EmotionalExpect { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<AudienceSession> AudienceSession { get; set; }


        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            modelBuilder.ApplyConfiguration(new AAPConfiguration());
            modelBuilder.ApplyConfiguration(new AudienceConfiguration());
            modelBuilder.ApplyConfiguration(new AudiencePackConfiguration());
            modelBuilder.ApplyConfiguration(new EmotionalExpectConfiguration());
            modelBuilder.ApplyConfiguration(new EmotionalResultConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new ASConfiguration());

            modelBuilder.Entity<Profile>()
               .HasKey(p => p.ProfileId);
            modelBuilder.Entity<Profile>()
                .HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Profile>()
               .HasIndex(p => p.Login).IsUnique();
            modelBuilder.Entity<Profile>()
               .HasIndex(p => p.PhoneNumber).IsUnique();

            modelBuilder.Entity<AAP>()
                .HasOne(aap => aap.Audience)
                .WithMany(a => a.AAPs)
                .HasForeignKey(aap => aap.AudienceId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AAP>()
                .HasOne(aap => aap.AudiencePack)
                .WithMany(ap => ap.AAPs)
                .HasForeignKey(aap => aap.AudiencePackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AudienceSession>()
                .HasOne(aus => aus.Session)
                .WithMany(s => s.AudienceSession)
                .HasForeignKey(aus => aus.SessionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AudienceSession>()
                .HasOne(aus => aus.AudiencePack)
                .WithMany(ap => ap.AudienceSession)
                .HasForeignKey(aus => aus.AudiencePackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmotionalResult>()
                .HasOne(er => er.Session)
                .WithMany(s => s.EmotionalResult)
                .HasForeignKey(er => er.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmotionalResult>()
              .HasOne(er => er.Audience)
              .WithMany()
              .HasForeignKey(er => er.AudienceId)
              .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<EmotionalExpect>()
                .HasOne(er => er.Session)
                .WithMany(s => s.EmotionalExpect)
                .HasForeignKey(er => er.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmotionalExpect>()
              .HasOne(er => er.Audience)
              .WithMany()
              .HasForeignKey(er => er.AudienceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Session)
                .WithOne(s => s.Report)
                .HasForeignKey<Report>(r => r.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(ci => ci.Profile)
                .WithMany(p => p.Sessions)
                .HasForeignKey(ci => ci.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

    }
}
