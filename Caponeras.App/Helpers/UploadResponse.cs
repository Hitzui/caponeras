using System.Text.Json.Serialization;

namespace Caponeras.App.Helpers;

public class UploadResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
