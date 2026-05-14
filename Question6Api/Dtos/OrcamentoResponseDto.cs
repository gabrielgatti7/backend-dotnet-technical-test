namespace Question6Api.Dtos;

public class OrcamentoResponseDto
{
    public Guid Id { get; set; }

    public int ClienteId { get; set; }

    public int VeiculoId { get; set; }

    public decimal ValorTotal { get; set; }

    public List<OrcamentoItemResponseDto> Itens { get; set; } = [];
}
