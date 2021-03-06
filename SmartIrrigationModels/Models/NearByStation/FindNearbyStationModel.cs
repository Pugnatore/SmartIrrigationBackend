﻿namespace SmartIrrigationModels.Models.NearByStation
{
    public class FindNearbyStationModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int? Limit { get; set; } = 8;
        public int? Radius { get; set; } = 100;

        public FindNearbyStationModel(float latitude, float longitude, int? limit, int? radius)
        {
            Latitude = latitude;
            Longitude = longitude;
            Limit = limit??8;
            Radius = radius;
        }

      
    }
}
