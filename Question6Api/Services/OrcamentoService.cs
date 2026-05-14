using Question6Api.Dtos;
using TechnicalTest.Question6.Common;
using TechnicalTest.Question6.Dtos;
using TechnicalTest.Question6.Models;

namespace TechnicalTest.Question6.Services;

public class OrcamentoService
{
    // Armazenamento em memória utilizado apenas para fins de demonstração.
    // Em uma aplicação real, o ideal seria persistir os dados em um banco de
    // dados por meio de um repositório (por exemplo, com Entity Framework Core).
    private static readonly List<Orcamento> _orcamentos = [];

    public Result<Orcamento> Create(CreateOrcamentoDto dto)
    {
        if (dto is null)
            return Result<Orcamento>.Failure("Os dados do orçamento são obrigatórios.");

        var itens = dto.Itens
            .Select(item => (
                item.Descricao,
                item.Quantidade,
                item.ValorUnitario))
            .ToList();

        var result = Orcamento.Create(
            dto.ClienteId,
            dto.VeiculoId,
            itens);

        if (!result.IsSuccess)
            return result;

        _orcamentos.Add(result.Data!);

        return result;
    }

    public Result<OrcamentoResponseDto> GetById(Guid id)
    {
        var orcamento = _orcamentos.FirstOrDefault(o => o.Id == id);

        if (orcamento is null)
            return Result<OrcamentoResponseDto>.Failure("Orçamento não encontrado.");

        var dto = new OrcamentoResponseDto
        {
            Id = orcamento.Id,
            ClienteId = orcamento.ClienteId,
            VeiculoId = orcamento.VeiculoId,
            ValorTotal = orcamento.ValorTotal,
            Itens = orcamento.Itens
                .Select(item => new OrcamentoItemResponseDto
                {
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    ValorTotal = item.ValorTotal
                })
                .ToList()
        };

        return Result<OrcamentoResponseDto>.Success(dto);
    }
}
