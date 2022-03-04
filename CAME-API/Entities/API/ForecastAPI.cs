using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAME_API.Entities
{
    public class ForecastSL
    {
        public int Pk { get; set; }
        public bool Extra { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }

    }

    public class ForecastItem
    {
        public int Pk { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }

    }
}

