namespace Question6Api.Dtos;

public class OrcamentoItemResponseDto
{
    public string Descricao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal { get; set; }
}