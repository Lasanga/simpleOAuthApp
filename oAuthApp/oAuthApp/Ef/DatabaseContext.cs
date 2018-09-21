using Microsoft.EntityFrameworkCore;
using oAuthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oAuthApp.Ef
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
