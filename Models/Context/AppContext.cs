using System.Data.Entity;

namespace TextEditor
{
    public class AppContext : DbContext
    {
        public AppContext():base("DefaultConnection")
        {
               
        }

        public DbSet<File> Files { get; set; }
    }
}
