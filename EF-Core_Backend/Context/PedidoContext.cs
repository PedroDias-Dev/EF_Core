using Microsoft.EntityFrameworkCore;
using EF_Core_Backend.Domains;

namespace EF_Core_Backend.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5LQ975E\SQLEXPRESS; Initial Catalog=EF_Core_Backend; user id=sa; password=sa132");

            base.OnConfiguring(optionsBuilder);
            
        }
    }
}