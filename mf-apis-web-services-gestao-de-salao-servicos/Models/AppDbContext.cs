using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ServicoCategoria> ServicoCategorias { get; set; }
        public DbSet<ServicoSubCategoria> ServicoSubCategorias { get; set; }
    }
}
