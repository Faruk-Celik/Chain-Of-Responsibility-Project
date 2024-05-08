using Microsoft.EntityFrameworkCore;

namespace ChainOfRespProject.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6VB768D\\SQLEXPRESS02; initial catalog=DbChainOfResponsibility; integrated Security=true;");

        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
