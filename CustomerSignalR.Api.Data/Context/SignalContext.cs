using CustomerSignalR.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.Data.Context
{
    public class SignalContext : DbContext
    {
        public SignalContext(DbContextOptions<SignalContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
