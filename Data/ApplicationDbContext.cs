using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student>? students {get; set;}
    }
}