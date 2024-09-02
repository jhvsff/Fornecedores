using Fornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Data;

public class FornecedorContext : DbContext
{
    public FornecedorContext(DbContextOptions<FornecedorContext> opts) : base(opts)
    {
        
    }

    public DbSet<Fornecedor> Fornecedores { get; set; }
}
