using FrontiersInTest.Models;
using System;

namespace FrontiersInTest.Builder
{
    public class BuildingDataBuilder
    {
        public static BuildingModel BuildBuildingFromData(string[] buildingDetails)
        {
            return new BuildingModel()
            {
                Rank = Convert.ToInt32(buildingDetails[0]),
                Name = buildingDetails[1],
                City = buildingDetails[2],
                CompletionYear = buildingDetails[4],
                HeightMeters = buildingDetails[5][..buildingDetails[5].IndexOf(" ")],
                Floors = Convert.ToInt32(buildingDetails[8]),
            };
        }
    }
}
