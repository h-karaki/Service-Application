using System.Collections.Generic;

namespace ServiceApplication.Interfaces
{
    interface IReadData
    {
        List<string> ReadDataFromFileSource(string fileSourceName);
    }
}
