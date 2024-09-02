using System.ComponentModel.DataAnnotations;

namespace Fornecedores.Data.Dtos;

public class ReadFornecedorDto
{
    public string Nome { get; set; }

    public string Email { get; set; }
}
