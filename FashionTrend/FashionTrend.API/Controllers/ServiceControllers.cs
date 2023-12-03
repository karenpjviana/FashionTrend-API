using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[Route("api/[controller]")]
[ApiController]
public class ServiceControllers : ControllerBase
{
    IMediator _mediator;

    public ServiceControllers(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Retorna todos os Services(Serviços) cadastrados.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Coleção de Service(Serviço). Pode ser uma coleção vazia se não houver Services cadastrados.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<List<GetAllServiceResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllServiceRequest(), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna o Serviço cadastrado por ID.
    /// </summary>
    /// <param name="id">ID do Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados do Serviço quando encontrado.</response>
    /// <response code="404">Serviço não encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetServiceResponse>> Get(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetServiceRequest(id.Value);
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna o Serviço cadastrado por descrição.
    /// </summary>
    /// <param name="description">Descrição do Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados do Serviço quando encontrado.</response>
    /// <response code="404">Serviço não encontrado.</response>
    [HttpGet("/Description/{Description}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetByDescriptionServiceResponse>> GetByDescription(string description, CancellationToken cancellationToken)
    {
        if (description is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetByDescriptionServiceRequest(description.ToLower());
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna o Serviço cadastrado por tipo.
    /// </summary>
    /// <param name="type">Tipo de Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados do Serviço quando encontrado.</response>
    /// <response code="404">Serviço não encontrado.</response>
    [HttpGet("/Type/{Type}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetByTypeServiceResponse>> GetByType(ERequestType type, CancellationToken cancellationToken)
    {
        //if (Type is null)
        //{
        //    return BadRequest();
        //}

        var GetRequest = new GetByTypeServiceRequest(type);
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna o Serviço cadastrado por material.
    /// </summary>
    /// <param name="material">Material do Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados do Serviço quando encontrado.</response>
    /// <response code="404">Serviço não encontrado.</response>
    [HttpGet("/material/{material}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetByMaterialServiceResponse>> GetByMaterial(string material, CancellationToken cancellationToken)
    {
        if (material is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetByMaterialServiceRequest(material.ToLower());
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Cria um novo Serviço com base nos dados fornecidos.
    /// </summary>
    /// <param name="request">Dados do Serviço a serem criados.</param>
    /// <response code="201">Serviço criado com sucesso.</response>
    /// <response code="400">Requisição inválida ou erro ao criar o Serviço.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create(CreateServiceRequest request)
    {
        var Service = await _mediator.Send(request);
        return Ok(Service);
    }

    /// <summary>
    /// Altera o Serviço cadastrado pelo Id.
    /// </summary>
    /// <param name="id">Id do Serviço</param>
    /// <param name="request">Dados do Serviço a serem alterados.</param>
    /// <param name="cancellationToken"></param>
    /// <response code="404">Serviço não encontrado.</response>
    /// <response code="200">Retorna que um Serviço foi alterado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UpdateServiceResponse>> Update(Guid? id, UpdateServiceRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Deleta o Serviço cadastrado pelo Id.
    /// </summary>
    /// <param name="id">Id do Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna que um Serviço foi deletado.</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var deleteRequest = new DeleteServiceRequest(id.Value);
        var response = await _mediator.Send(deleteRequest, cancellationToken);
        return Ok(response);
    }
}
