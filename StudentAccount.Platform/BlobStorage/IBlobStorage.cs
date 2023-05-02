using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentAccount.Platform.BlobStorage;

public interface IBlobStorage
{
    Task PutContextAsync(string filename);
    Task<bool> ContainsFileByNameAsync(string toString);

    Task<List<int>> FindByCourseAsync(Guid courseId);
}