namespace src.Application.Common.Dtos;

public sealed record CreateCommandRequestDto
(
    string SystemName,
    string Cmd,
    string Purpose
);