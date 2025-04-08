using System;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Models;

namespace TaskTrackingSystem.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
