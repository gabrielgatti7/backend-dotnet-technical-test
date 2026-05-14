# Question6Api

API ASP.NET Core desenvolvida para a questão 6 do teste técnico de Back-end .NET Júnior.

## Objetivo

Implementar um endpoint para cadastro de orçamentos de uma oficina mecânica, aplicando as seguintes regras de negócio:

- `clienteId` é obrigatório.
- `veiculoId` é obrigatório.
- Deve existir pelo menos um item.
- Cada item deve possuir:
  - descrição obrigatória;
  - quantidade maior que zero;
  - valor unitário maior que zero.
- O valor total do orçamento é calculado automaticamente pela API.
- A API retorna mensagens claras em caso de erro.

## Estrutura do projeto

O projeto foi organizado em camadas, separando responsabilidades:

```text
Question6Api/
├── Common/
│   └── Result.cs
├── Controllers/
│   └── OrcamentosController.cs
├── Dtos/
│   ├── CreateOrcamentoDto.cs
│   ├── CreateOrcamentoItemDto.cs
│   ├── OrcamentoItemResponseDto.cs
│   └── OrcamentoResponseDto.cs
├── Domain/
│   ├── Orcamento.cs
│   └── OrcamentoItem.cs
├── Services/
│   └── OrcamentoService.cs
└── Program.cs
```

## Decisões de implementação

### Models
As entidades `Orcamento` e `OrcamentoItem` concentram as regras de validação e criação por meio de métodos estáticos `Create`.

### DTOs
Os DTOs são utilizados para representar os dados de entrada e saída da API, desacoplando o contrato externo das entidades internas.

### Service
A classe `OrcamentoService` coordena a criação e consulta dos orçamentos, mantendo a lógica de negócio fora do controller.

### Result\<T\>
Foi utilizado o padrão `Result<T>` para retornar sucesso ou erro sem depender de exceções para controle de fluxo.

### Persistência em memória
Para simplificar a solução, os orçamentos são armazenados em uma lista estática em memória. Em uma aplicação real, essa responsabilidade seria delegada a um repositório com banco de dados.

## Endpoints

### `POST /api/orcamentos`
Cria um novo orçamento.

**Exemplo de requisição:**
```json
{
  "clienteId": 10,
  "veiculoId": 25,
  "itens": [
    {
      "descricao": "Troca de óleo",
      "quantidade": 1,
      "valorUnitario": 120.00
    },
    {
      "descricao": "Filtro de óleo",
      "quantidade": 1,
      "valorUnitario": 45.00
    }
  ]
}
```

---

### `GET /api/orcamentos/{id}`
Retorna um orçamento previamente cadastrado pelo seu `id`.

## Testando a API

A API pode ser testada diretamente pelo **Swagger UI**, disponível em `/swagger` ao rodar o projeto em ambiente de desenvolvimento.
