using TechnicalTest.Question6.Common;

namespace TechnicalTest.Question6.Models;

public class OrcamentoItem
{
    private OrcamentoItem(string descricao, int quantidade, decimal valorUnitario)
    {
        Descricao = descricao;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public string Descricao { get; private set; } = string.Empty;

    public int Quantidade { get; private set; }

    public decimal ValorUnitario { get; private set; }

    public decimal ValorTotal => Quantidade * ValorUnitario;

    public static Result<OrcamentoItem> Create(string descricao, int quantidade, decimal valorUnitario)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            return Result<OrcamentoItem>.Failure("A descrição do item é obrigatória.");

        if (quantidade <= 0)
            return Result<OrcamentoItem>.Failure("A quantidade deve ser maior que zero.");

        if (valorUnitario <= 0)
            return Result<OrcamentoItem>.Failure("O valor unitário deve ser maior que zero.");

        var orcamentoItem = new OrcamentoItem(descricao, quantidade, valorUnitario);
        return Result<OrcamentoItem>.Success(orcamentoItem);
    }
}
