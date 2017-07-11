using RestSharp;
using ServiceApplication.Models;

namespace ServiceApplication.Interfaces
{
    interface IConvertAddressToCoordinate
    {
        Coordinate ConvertAddressToCoordinate(string address, IRestResponse<RootObject> jsonObject);
    }
}
