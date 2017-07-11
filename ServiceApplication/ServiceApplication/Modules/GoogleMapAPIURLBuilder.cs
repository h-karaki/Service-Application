//https://developers.google.com/maps/documentation/geocoding/start

namespace ServiceApplication.Modules
{
    class GoogleMapApiurlBuilder
    {
        //Key should be passed in as a parameter instead of saved.
        private static string _key = "";
        private static string _baseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        public static string BuildUrl(string address)
        {
            return _baseUrl + address.Replace(' ','+') + "&key=" + _key;
        }
    }
}

