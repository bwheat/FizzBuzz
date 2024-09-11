using FizzBuzz.Model;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzz.Repositories 
{
    public class CapServicesDbContext : DbContext 
    {
        public CapServicesDbContext(DbContextOptions<CapServicesDbContext> options) : base(options)
        { }

        public virtual DbSet<FizzBuzzResult> FizzBuzzResults { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.
            modelBuilder.Entity<FizzBuzzResult>().HasNoKey();//.ToTable("Persons", "dbo").HasKey(x => x.Id);
            modelBuilder.Entity<Person>();//.ToTable("FizzBuzzResult", "dbo").HasKey(a => new
            // {
            //     a.Id
            // });           

        }

        // public virtual IQueryable<TEntity> RunSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        // {
        //     return this.Set<TEntity>().FromSqlRaw(sql, parameters);
        // }
    }
}