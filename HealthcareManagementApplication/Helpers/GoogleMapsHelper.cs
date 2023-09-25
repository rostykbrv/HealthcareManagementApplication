using GoogleApi;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using System.Threading.Tasks;

namespace HealthcareManagementApplication.Helpers
{
    public class GoogleMapsHelper
    {
        /*private readonly string _googleMapsApiKey;

        public GoogleMapsHelper(string googleMapsApiKey)
        {
            _googleMapsApiKey = googleMapsApiKey;
        }

        public async Task<Location> GetLatLongFromAddress(string address)
        {
            var geocodeRequest = new AddressGeocodeRequest
            {
                Key = _googleMapsApiKey,
                Address = address
            };

            var geocodeResponse = await GoogleMaps.Geocode.AddressGeocode.QueryAsync(geocodeRequest);
            return geocodeResponse.Results.First().Geometry.Location;
        }

        public async Task<DirectionsResponse> GetDirections(Location origin, Location destination)
        {
            var directionsRequest = new DirectionsRequest
            {
                Key = _googleMapsApiKey,
                Origin = new LocationEx { Latitude = origin.Latitude, Longitude = origin.Longitude },
                Destination = destination
            };

            var directionsResponse = await GoogleApi.GoogleMaps.Directions.QueryAsync(directionsRequest);
            return directionsResponse;
        }*/
    }
}
