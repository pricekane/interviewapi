using Microsoft.EntityFrameworkCore;
using ReliasInterviewApi.Models;

namespace ReliasInterviewApi.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<CandidateTest> Tests { get; set; }
        public DbSet<CandidateTestQuestion> TestQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidates");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Response>().ToTable("Responses");
            modelBuilder.Entity<CandidateTest>()
                .ToTable("CandidateTests")
                .HasMany(i => i.TestQuestions)
                .WithOne(i => i.Test)
                .HasForeignKey(i => i.TestId);
            modelBuilder.Entity<CandidateTestQuestion>()
                .ToTable("CandidateTestQuestions")
                .HasOne(i => i.Test)
                .WithMany(i => i.TestQuestions)
                .HasForeignKey(i => i.TestId);

        }
    }
}