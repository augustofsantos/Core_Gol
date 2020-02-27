using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gol.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Gol.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Travel> travel { get; set; }
        public DbSet<User> user { get; set; }
        
    }
}