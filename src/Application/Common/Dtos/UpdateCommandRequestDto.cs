namespace src.Application.Common.Dtos;

public sealed record UpdateCommandRequestDto
(
    string SystemName,
    string Cmd,
    string Purpose
);