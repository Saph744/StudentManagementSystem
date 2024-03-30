using Microsoft.EntityFrameworkCore;
using schoolmanagement.data.Mapping;
using schoolmanagement.Domain.Models;
using System.Data.Common;

namespace schoolmanagement.data
{
    public class SchoolManagementDbContext : DbContext
    {
        private DbConnection dbConnection;
        private bool v;
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {

        }
        //public DbSet<student> Students { get; set; }
        public SchoolManagementDbContext(DbConnection dbConnection, bool v)
        {
            this.dbConnection = dbConnection;
            this.v = v;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentMap());

        }

    }
}
