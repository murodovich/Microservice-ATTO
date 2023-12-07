using Microsoft.EntityFrameworkCore;

namespace School.Infrastructure.Persistance
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) 
            : base(options)
        {
            
        }

        
    }
}
