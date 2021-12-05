using Dhanashree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dhanashree.Data
{
    public class EmployeesDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
     : base(options)
        { }
    }
}
