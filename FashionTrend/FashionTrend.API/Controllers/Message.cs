using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[Route("api/[controller]")]
[ApiController]
public class Message : ControllerBase
{
    IMediator _mediator;

    public Message(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cria uma nova mensagem.
    /// </summary>
    /// <param name="request">Dados da mensagem a ser criada.</param>
    /// <response code="201">Mensagem criada com sucesso.</response>
    /// <response code="400">Requisição inválida ou erro ao criar a Mensagem.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create(CreateMessageRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }
}
