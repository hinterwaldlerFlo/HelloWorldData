using System;
using System.Collections.Generic;

namespace HelloWorldData.Models
{
    public partial class WeatherForecast
    {
        public int Id { get; set; }
        public string DateFormatted { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
