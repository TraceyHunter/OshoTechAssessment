using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ConfigurationAPI.Models
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options)
            : base(options)
        {

        }

        public DbSet<Configuration> Configurations { get; set; } = null;
    }
}
