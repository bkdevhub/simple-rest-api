using Microsoft.AspNetCore.Mvc;
using src.Application.Common.Dtos;
using src.Application.Common.Exceptions;
using src.Application.Common.Mappings;
using src.Application.Common.Repositories;
using src.Domain;

namespace src.Controllers;

[ApiController]
[Route("api/commands")]
public class CommandCollectionController : ControllerBase
{
    private readonly ICommandRepository _commandRepository;

    public CommandCollectionController(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Command>>> GetCommandCollection()
    {
        var commandCatalog = await _commandRepository
            .GetAll();

        var commands = commandCatalog
            .Select(x => 
                x.ToCommandResponseDto());
        
        return Ok(commands);
    }
    
    [HttpPost]
    public async Task<ActionResult<CommandResponseDto>> CreateCommand(
        [FromBody] CreateCommandRequestDto createCommandRequestDto)
    {
        var domainModel = createCommandRequestDto.ToCommand();
        
        var command = await _commandRepository
            .Create(domainModel);
        
        var mapped = command.ToCommandResponseDto();
        
        return CreatedAtAction(
            nameof(GetById),
            new { id = mapped.Id },
            mapped
        );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommandResponseDto>> GetById(Guid id)
    {
        var command = await _commandRepository
            .GetById(id.ToString());
        
        return command is null
            ? NotFound()
            : Ok(command.ToCommandResponseDto());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CommandResponseDto>> Update(
        Guid id,
        [FromBody] UpdateCommandRequestDto dto)
    {
        try
        {
            var existing = await _commandRepository
                .GetById(id.ToString());

            if (existing is null)
            {
                return NotFound();
            }

            existing.SystemName = dto.SystemName;
            existing.Cmd = dto.Cmd;
            existing.Purpose = dto.Purpose;

            await _commandRepository.Update(existing);

            return Ok(existing.ToCommandResponseDto());
        }
        catch (UpdateException ex)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Update failed",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
            {
                Title = "Update failed",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleted = await _commandRepository
            .Delete(id.ToString());

        return deleted
            ? NoContent()
            : NotFound();
    }
}