using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MessageControllers : ControllerBase
{
    IMediator _mediator;

    public MessageControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }
}
