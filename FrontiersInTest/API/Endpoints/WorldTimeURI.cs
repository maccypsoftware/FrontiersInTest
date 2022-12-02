using System;

namespace FrontiersInTest.API.Endpoints
{
    public class WorldTimeURI
    {
        public static string GetWorldTimeUri(string city)
        {
            return $"/api/timezone/Europe/{city}";
        }
    }
}
