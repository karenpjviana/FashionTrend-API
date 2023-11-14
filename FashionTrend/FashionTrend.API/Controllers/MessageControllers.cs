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

    //[HttpGet]
    //public async Task<ActionResult<List<GetAllMessageResponse>>> GetAll(CancellationToken cancellationToken)
    //{
    //    var response = await _mediator.Send(new GetAllMessageRequest(), cancellationToken);
    //    return Ok(response);
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<GetAllMessageResponse>> Get(Guid? id, CancellationToken cancellationToken)
    //{
    //    if (id is null)
    //    {
    //        return BadRequest();
    //    }

    //    var GetRequest = new GetMessageRequest(id.Value);
    //    var response = await _mediator.Send(GetRequest, cancellationToken);
    //    return Ok(response);
    //}

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageRequest request)
    {
        var Message = await _mediator.Send(request);
        return Ok(Message);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult<UpdateMessageResponse>> Update(Guid id, UpdateMessageRequest request, CancellationToken cancellationToken)
    //{
    //    if (id != request.Id)
    //    {
    //        return BadRequest();
    //    }
    //    var response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    //{
    //    if (id is null)
    //    {
    //        return BadRequest();
    //    }

    //    var deleteRequest = new DeleteMessageRequest(id.Value);
    //    var response = await _mediator.Send(deleteRequest, cancellationToken);
    //    return Ok(response);
    //}
}
