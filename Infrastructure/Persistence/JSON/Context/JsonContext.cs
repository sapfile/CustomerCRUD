using Domain.Entities;
using Infrastructure.Persistence.JSON.Interface;
using System.Text.Json;

namespace Infrastructure.Persistence.JSON.Context;

public class JsonContext : IJsonContext
{
    public async Task<List<T>?> GetDataList<T>(CancellationToken cancellationToken) where T : EntityBase
    {
        var fileName = GetFileName<T>();

        using FileStream stream = File.OpenRead(fileName);

        List<T>? data = await JsonSerializer.DeserializeAsync<List<T>>(stream, cancellationToken: cancellationToken);

        return data;
    }

    public async Task Save<T>(List<T> Entity, CancellationToken cancellationToken) where T : EntityBase
    {
        var fileName = GetFileName<T>();

        using FileStream stream = File.Create(fileName);

        await JsonSerializer.SerializeAsync(stream, Entity, cancellationToken: cancellationToken);
    }

    private string GetFileName<T>()
    {
        string baseDirectory = AppContext.BaseDirectory;

        string filePath = Path.Combine(baseDirectory, "Database/JSON", $"{typeof(T).Name}.json");
        return filePath; // $"Database/JSON/{typeof(T).Name}.json";
    }
}