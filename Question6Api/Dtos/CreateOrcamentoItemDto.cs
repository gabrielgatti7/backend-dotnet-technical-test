namespace TechnicalTest.Question6.Dtos;

public class CreateOrcamentoItemDto
{
    public string Descricao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public decimal ValorUnitario { get; set; }
}
