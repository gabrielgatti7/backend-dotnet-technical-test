using System.Collections.Generic;
using TechnicalTest.Question6.Common;

namespace TechnicalTest.Question6.Models;

public class Orcamento
{
    private Orcamento(Guid id, int clienteId, int veiculoId, decimal valorTotal, List<OrcamentoItem> itens)
    {
        Id = id;
        ClienteId = clienteId;
        VeiculoId = veiculoId;
        ValorTotal = valorTotal;
        _itens = itens;
    }

    public Guid Id { get; private set; }

    public int ClienteId { get; private set; }

    public int VeiculoId { get; private set; }

    public decimal ValorTotal { get; private set; }

    public readonly List<OrcamentoItem> _itens = new();

    public IReadOnlyCollection<OrcamentoItem> Itens => _itens;

    public static Result<Orcamento> Create(
    int clienteId,
    int veiculoId,
    List<(string descricao, int quantidade, decimal valorUnitario)> itens)
    {
        if (clienteId <= 0)
            return Result<Orcamento>.Failure("clienteId é obrigatório.");

        if (veiculoId <= 0)
            return Result<Orcamento>.Failure("veiculoId é obrigatório.");

        if (itens is null || itens.Count == 0)
            return Result<Orcamento>.Failure("O orçamento deve possuir pelo menos um item.");

        var orcamentoItens = new List<OrcamentoItem>();

        foreach (var item in itens)
        {
            var orcamentoItemResult = OrcamentoItem.Create(
                item.descricao,
                item.quantidade,
                item.valorUnitario);

            if (!orcamentoItemResult.IsSuccess)
                return Result<Orcamento>.Failure(orcamentoItemResult.Message);

            orcamentoItens.Add(orcamentoItemResult.Data!);
        }

        var valorTotal = orcamentoItens.Sum(i => i.ValorTotal);

        var orcamento = new Orcamento(
            Guid.NewGuid(),
            clienteId,
            veiculoId,
            valorTotal,
            orcamentoItens);

        return Result<Orcamento>.Success(orcamento);
    }
}
