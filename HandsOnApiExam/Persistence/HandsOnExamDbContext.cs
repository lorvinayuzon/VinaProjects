using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class HandsOnExamDbContext: DbContext
    {
        public HandsOnExamDbContext(DbContextOptions<HandsOnExamDbContext> options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
