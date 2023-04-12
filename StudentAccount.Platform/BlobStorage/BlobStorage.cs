using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace StudentAccount.Platform.BlobStorage;

public class BlobStorage : IBlobStorage
{
    protected virtual string BlobContainerName { get; set; } = "workshop";
    private readonly BlobServiceClient _client;

    public BlobStorage(BlobConfiguration blobConfiguration)
    {
        _client = new BlobServiceClient(blobConfiguration.ConnectionString);
    }

    public async Task PutContextAsync(string filename)
    {
        await _client.GetBlobContainerClient(BlobContainerName)
            .GetBlobClient(filename)
            .UploadAsync(new MemoryStream());
    }

    public async Task<bool> ContainsFileByNameAsync(string filename)
    {
        return await _client.GetBlobContainerClient(BlobContainerName).GetBlobClient(filename).ExistsAsync();
    }

    public async Task<List<int>> FindByCourseAsync(Guid courseId)
    {
        var results = _client.GetBlobContainerClient(BlobContainerName)
            .GetBlobs(prefix:  courseId.ToString("N"))
            .AsPages(default, 1000)
            .SelectMany(dt => dt.Values).Select(bi =>int.Parse(bi.Name.Split('_').Last())).ToList();

        return results;
    }
}