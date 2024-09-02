using AutoMapper;
using Fornecedores.Data;
using Fornecedores.Data.Dtos;
using Fornecedores.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedoresController : ControllerBase
{
    private FornecedorContext _context;
    private IMapper _mapper;

    public FornecedoresController(FornecedorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um fornecedor ao banco de dados
    /// </summary>
    /// <param name="fornecedorDto">Objeto com os campos necessários para a criação de um fornecedor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFornecedor([FromBody] CreateFornecedorDto fornecedorDto)
    {
        Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
        _context.Fornecedores.Add(fornecedor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFornecedoresPorId), new { id = fornecedor.Id }, fornecedor);
    }

    /// <summary>
    /// Atualiza um fornecedor no banco de dados
    /// </summary>
    /// <param name="id">Código identificador do fornecedor</param>
    /// <param name="fornecedorDto">Objeto com os campos necessários para a atualização de um fornecedor</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a operação ocorra com sucesso</response>
    /// <response code="404">Caso o código identificador do fornecedor não corresponda a um fornecedor válido</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFornecedor(int id, [FromBody] UpdateFornecedorDto fornecedorDto)
    {
        var fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == id);

        if (fornecedor == null) return NotFound();

        _mapper.Map(fornecedorDto, fornecedor);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Retorna uma lista de fornecedores do banco de dados
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados</param>
    /// <param name="take">Número de registros a serem retornados</param>
    /// <returns>IEnumerable</returns>
    [HttpGet]
    public IEnumerable<ReadFornecedorDto> RecuperaFornecedores([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        return _mapper.Map<List<ReadFornecedorDto>>(_context.Fornecedores.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna os dados de um fornecedor do banco de dados
    /// </summary>
    /// <param name="id">Código identificador do fornecedor</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a consulta retorne dados válidos</response>
    /// <response code="404">Caso a consulta não retorne dados válidos</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaFornecedoresPorId(int id)
    {
        var fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == id);

        if (fornecedor == null) return NotFound();

        var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

        return Ok(fornecedorDto);

    }

    /// <summary>
    /// Deleta um fornecedor do banco de dados
    /// </summary>
    /// <param name="id">Código identificador do fornecedor</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a operação ocorra com sucesso</response>
    /// <response code="404">Caso o código identificador do fornecedor não corresponda a um fornecedor válido</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaFornecedor(int id)
    {
        var fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == id);

        if (fornecedor == null) return NotFound();

        _context.Remove(fornecedor);
        _context.SaveChanges();

        return NoContent();

    }
}
