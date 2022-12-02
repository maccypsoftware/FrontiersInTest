using FrontiersInTest.API.Endpoints;
using RestSharp;

namespace FrontiersInTest.API.RequestBuilders
{
    public class WorldTimeActions
    {
        public static RestRequest GetWorldTime(string city)
        {            
            return new RestRequest(WorldTimeURI.GetWorldTimeUri(city), Method.Get);
            //return client.Execute(request);
        }
    }
}
