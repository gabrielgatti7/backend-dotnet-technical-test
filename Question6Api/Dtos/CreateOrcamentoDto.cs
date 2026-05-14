namespace TechnicalTest.Question6.Dtos;

public class CreateOrcamentoDto
{
    public int ClienteId { get; set; }

    public int VeiculoId { get; set; }

    public List<CreateOrcamentoItemDto> Itens { get; set; } = [];
}
