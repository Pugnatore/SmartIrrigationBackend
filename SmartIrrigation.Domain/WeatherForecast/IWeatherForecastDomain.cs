﻿using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Domain
{
    public interface IWeatherForecastDomain
    {
        RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude);
    }
}
