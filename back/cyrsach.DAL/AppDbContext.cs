using cyrsach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace cyrsach.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<TestEntity> Tests => Set<TestEntity>();
        public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();

        public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Test → Questions
            modelBuilder.Entity<TestEntity>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Question → Answers
            modelBuilder.Entity<QuestionEntity>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Test → Author
            modelBuilder.Entity<TestEntity>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
