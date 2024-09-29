using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ServicoUsuarios>()
                .HasKey(c => new { c.ServicoCategoriaId, c.UsuariosId });

            builder.Entity<ServicoUsuarios>()
                .HasOne(c => c.ServicoCategoria).WithMany(c => c.Usuario)
                .HasForeignKey(c => c.ServicoCategoriaId);

            builder.Entity<ServicoUsuarios>()
               .HasOne(c => c.Usuario).WithMany(c => c.Servicos)
               .HasForeignKey(c => c.UsuariosId);
        }

        public DbSet<ServicoCategoria> ServicoCategorias { get; set; }
        public DbSet<ServicoSubCategoria> ServicoSubCategorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ServicoUsuarios> ServicosUsuarios { get; set; }
    }
}
