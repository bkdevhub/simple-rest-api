using src.Application.Common.Dtos;
using src.Domain;

namespace src.Application.Common.Mappings;

public static class CommandMappings
{
    public static CommandResponseDto ToCommandResponseDto(this Command command)
    {
        return new CommandResponseDto(command.Id, command.SystemName, command.Cmd, command.Purpose);
    }
    
    public static Command ToCommand(this CreateCommandRequestDto dto)
    {
        var mapped = new Command
        {
            SystemName = dto.SystemName,
            Cmd = dto.Cmd,
            Purpose = dto.Purpose,
        };

        return mapped;
    }
}