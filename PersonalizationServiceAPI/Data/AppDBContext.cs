

using PersonalizationServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalizationServiceAPI.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }
        public DbSet<PersonalizationSettings> Settings { get; set; }



    }
}
