﻿using System;
using System.Collections.Generic;
using System.Text;
using DevMeteoStat.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace DevMeteoStat
{
    public class PointData : IPointData
    {
        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams)
        {
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}point/hourly");
            var request = new RestRequest();

            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("lat", hourlyDataOfAPointParams.Lat.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("lon", hourlyDataOfAPointParams.Long.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("alt", hourlyDataOfAPointParams.Alt, ParameterType.QueryString);
            request.AddParameter("start", hourlyDataOfAPointParams.Start);
            request.AddParameter("end", hourlyDataOfAPointParams.End);
            request.AddParameter("tz", hourlyDataOfAPointParams.Tz);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<HourlyDataModel>>(response.Content);
        }

        public RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams)
        {
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}point/daily");
            var request = new RestRequest();
            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("lat", dailyDataOfAPointParams.Lat.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("lon", dailyDataOfAPointParams.Long.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("alt", dailyDataOfAPointParams.Alt, ParameterType.QueryString);
            request.AddParameter("start", dailyDataOfAPointParams.Start, ParameterType.QueryString);
            request.AddParameter("end", dailyDataOfAPointParams.End, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<DailyDataModel>>(response.Content);
        }

        public RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt)
        {
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}point/climate");
            var request = new RestRequest();
            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("lat", lat.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("lon", lon.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("alt", alt, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<ClimateNormalsOfAPointDataModel>>(response.Content);
        }
    }
}
