using RestSharp;
using ServiceApplication.Models;

namespace ServiceApplication.Interfaces
{
    public interface IGetRequest
    {
        IRestResponse<RootObject> GetRequest(IRestClient client, IRestRequest request);
    }
}