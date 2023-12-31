﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[Route("api/[controller]")]
[ApiController]
public class ServiceOrder : ControllerBase
{
    IMediator _mediator;

    public ServiceOrder(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retorna todos as ServiceOrders(Ordens de Serviço) cadastradas.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Coleção de ServiceOrder(Ordem de Serviço). Pode ser uma coleção vazia se não houver ServiceOrders cadastrados.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<List<GetAllServiceOrderResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllServiceOrderRequest(), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna a Ordem de Serviço cadastrada por ID.
    /// </summary>
    /// <param name="id">ID da Ordem de Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados da Ordem de Serviço quando encontrada.</response>
    /// <response code="404">Ordem de Serviço não encontrada.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetServiceOrderResponse>> Get(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetServiceOrderRequest(id.Value);
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna a Ordem de Serviço cadastrada por ServiceId.
    /// </summary>
    /// <param name="id">ID da Ordem de Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados da Ordem de Serviço quando encontrada.</response>
    /// <response code="404">Ordem de Serviço não encontrada.</response>
    [HttpGet("serviceId/{supplierId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetServiceOrderResponse>> GetByServiceId(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetServiceOrderRequest(id.Value);
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Retorna a Ordem de Serviço cadastrada por SupplierId.
    /// </summary>
    /// <param name="id">ID do Supplier(Fornecedor)</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados da Ordem de Serviço quando encontrada.</response>
    /// <response code="404">Ordem de Serviço não encontrada.</response>
    [HttpGet("supplierId/{supplierId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetServiceOrderResponse>> GetBySupplierId(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var GetRequest = new GetServiceOrderRequest(id.Value);
        var response = await _mediator.Send(GetRequest, cancellationToken);
        return Ok(response);
    }


    /// <summary>
    /// Cria uma nova Ordem de Serviço com base nos dados fornecidos.
    /// </summary>
    /// <param name="request">Dados da Ordem de Serviço a ser criada.</param>
    /// <response code="201">Ordem de Serviço criada com sucesso.</response>
    /// <response code="400">Requisição inválida ou erro ao criar a Ordem de Serviço.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create(CreateServiceOrderRequest request)
    {
        var ServiceOrder = await _mediator.Send(request);
        return Ok(ServiceOrder);
    }

    /// <summary>
    /// Altera a Ordem de Serviço cadastrado pelo Id.
    /// </summary>
    /// <param name="id">Id da Ordem de Serviço</param>
    /// <param name="request">Dados da Ordem de Serviço a ser alterada.</param>
    /// <param name="cancellationToken"></param>
    /// <response code="404">Ordem de Serviço não encontrada.</response>
    /// <response code="200">Retorna que uma Ordem de Serviço foi alterada.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UpdateServiceOrderResponse>> Update(Guid? id, UpdateServiceOrderRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Deleta a Ordem de Serviço cadastrada pelo Id.
    /// </summary>
    /// <param name="id">Id da Ordem de Serviço</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna que uma Ordem de Serviço foi deletada.</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var deleteRequest = new DeleteServiceOrderRequest(id.Value);
        var response = await _mediator.Send(deleteRequest, cancellationToken);
        return Ok(response);
    }
}
