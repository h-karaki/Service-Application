using RestSharp;
using ServiceApplication.Models;
using System;
using ServiceApplication.Interfaces;

namespace ServiceApplication.Modules
{
    class ApiCalls : IGetRequest
    {
        public IRestResponse<RootObject> GetRequest(IRestClient client, IRestRequest request)
        {
            //TODO: ASYNC
            IRestResponse<RootObject> response = client.Execute<RootObject>(request);

            return response;
        }
    }
}
