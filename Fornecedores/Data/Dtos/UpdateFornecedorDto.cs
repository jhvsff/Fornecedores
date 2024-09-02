using System.ComponentModel.DataAnnotations;

namespace Fornecedores.Data.Dtos;

public class UpdateFornecedorDto
{
    [Required(ErrorMessage = "O nome do fornecedor é um campo obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email do fornecedor é um campo obrigatório")]
    public string Email { get; set; }
}
