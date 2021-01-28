﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class ReadHourlyRepository : IReadHourlyRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadHourlyRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }


        public void AddReadHourly(RootWeatherDataModel<HourlyDataModel> rootWeatherDataModel, bool isStation, int? idStation)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                foreach (var item in rootWeatherDataModel.Data)
                {
                    string sql =
                        $"Insert into [dbo].[Read_Hourly] (DateReading,Temperature,Dwpt, Rhum, Prcp, Snow, Wdir, Wspd, Wpgt, Pres, Tsun, Coco, IsStation, IdReader) values (@DateReading, @Temperature, @Dwpt, @Rhum, @Prcp, @Snow, @Wdir, @Wspd, @Wpgt, @Pres, @Tsun, @Coco, @IsStation, @IdReader)";
                    db.Execute(sql,
                        new
                        {
                            DateReading = item.Time, Temperature = item.Temp, Dwpt = item.Dwpt, Rhum = item.Rhum,
                            Prcp = item.Prcp, Snow = item.Snow, Wdir = item.WDir, Wspd = item.WSpd, Wpgt = item.WPgt,
                            Pres = item.Pres, Tsun = item.Tsun, Coco = item.Coco, isStation=isStation, IdReader=idStation
                        });
                }
            }
        }
    }
}