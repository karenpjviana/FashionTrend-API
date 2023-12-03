using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Net.Mime;

[Route("api/[controller]")]
[ApiController]
public class DraftContract : ControllerBase
{
    IMediator _mediator;

    public DraftContract(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cria um novo Contrato com base nos dados fornecidos.
    /// </summary>
    /// <param name="request">Dados da Ordem de Serviço a ser criada.</param>
    /// <response code="201">Ordem de Serviço criada com sucesso.</response>
    /// <response code="400">Requisição inválida ou erro ao criar a Ordem de Serviço.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create(CreateDraftContractRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }


    /// <summary>
    /// Altera o Contrato cadastrado pelo Id.
    /// </summary>
    /// <param name="id">Id do Contrato</param>
    /// <param name="request">Dados da Contrato a ser alterada.</param>
    /// <param name="cancellationToken"></param>
    /// <response code="404">Contrato não encontrada.</response>
    /// <response code="200">Retorna que um Contrato foi alterada.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AcceptedDraftContractResponse>>
       Update(Guid id, AcceptedDraftContractRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
