using ServiceApplication.Interfaces;
using ServiceApplication.Models;
using RestSharp;

namespace ServiceApplication.Modules
{
    class CoordinateLookup : IConvertAddressToCoordinate
    {
        Coordinate _coords;

        public Coordinate ConvertAddressToCoordinate(string address, IRestResponse<RootObject> jsonObject)
        {
            //TODO: Dependency Injection for Coordintes
            _coords = new Coordinate();
            _coords.X = 555;
            _coords.Y = 555;
            
            _coords.X = jsonObject.Data.Results[0].Geometry.Location.Lat;
            _coords.Y = jsonObject.Data.Results[0].Geometry.Location.Lng;

            return _coords;
        }
    }
}
