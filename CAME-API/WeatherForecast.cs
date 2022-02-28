using System;

namespace CAME_API
{
    public class WeatherForecastSL
    {
        public int Pk { get; set; }
        public bool Extra { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    }

    public class WeatherForecastItems
    {
        public int Pk { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
