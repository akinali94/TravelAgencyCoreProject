using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class ContextApi : DbContext
    {
        public ContextApi(DbContextOptions<ContextApi> options):base(options)
        {
            
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
