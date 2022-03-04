using System;
using System.ComponentModel.DataAnnotations;

namespace CAME_API.Entities
{
    public class Forecast
    {
        [Key] public int Pk { get; set; }
        public bool Extra { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }

    }

}