using Microsoft.EntityFrameworkCore;
using PaceHosipital.Models;
using System.Collections.Generic;

namespace PaceHosipital.DatabaseContext
{
    public class DBContextt:DbContext
    {
        public DBContextt(DbContextOptions<DBContextt> options) : base(options) { }

        public DbSet<AdminType> AdminTypes { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
