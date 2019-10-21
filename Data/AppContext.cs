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

        public DbSet<Interviewee> Interviewees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interviewee>().ToTable("Interviewee");
        }
    }
}