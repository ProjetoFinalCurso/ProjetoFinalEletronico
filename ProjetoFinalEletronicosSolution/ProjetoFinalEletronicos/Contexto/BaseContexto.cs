
using System.Data.Entity;

namespace ProjetoFinalEletronicos
{
    public class BaseContexto: DbContext
    {
        public BaseContexto() : base("name=Conexao")
        {
        }
        public DbSet<Modelo.Cliente> Clientes { get; set; }
        public DbSet<Modelo.Categoria> Categorias { get; set; }
        public DbSet<Modelo.Produto> Produtos { get; set; }
        public DbSet<Modelo.Marca> Marcas { get; set; }
    }
}
