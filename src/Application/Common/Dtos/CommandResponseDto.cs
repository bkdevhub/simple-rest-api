namespace src.Application.Common.Dtos;

public sealed record CommandResponseDto
(
    string Id,
    string SystemName,
    string Cmd,
    string? Purpose
);