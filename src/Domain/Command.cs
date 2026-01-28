using System.Text.Json.Serialization;

namespace src.Domain;

public sealed class Command
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = Guid.NewGuid().ToString();
    
    [JsonPropertyName("system")]
    public required string SystemName { get; set; }
    
    [JsonPropertyName("cmd")]
    public required string Cmd { get; set; }

    [JsonPropertyName("purpose")]
    public string? Purpose { get; set; }
}
