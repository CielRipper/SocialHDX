using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class SocialHDXContext : DbContext
    {
        public SocialHDXContext(DbContextOptions<SocialHDXContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Prescriber> Prescriber { get; set; } = default!;
        public DbSet<CampusEvent> CampusEvent { get; set; } = default!;
        public DbSet<Prescription> Prescription { get; set; } = default!;
        public DbSet<StudentCase> StudentCase { get; set; } = default!;
        public DbSet<StudentCaseNote> StudentCaseNote { get; set; } = default!;
    }
}