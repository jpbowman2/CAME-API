using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using CAME_API.Services;
using CAME_API.Entities;

namespace CAME_API.Services
{
    public class InMemoryWorksRepository : IWorksRepository
    {
        private readonly List<Work> _works;
        public InMemoryWorksRepository()
        {
            _works = new List<Work>()
            {
                new Work() {
                    MinistryWorksID =1,
                    MinistryID =0,
                    FormPeopleName ="PeopleA",
                    FormLanguage ="LangA",
                    FormLocation ="LocA",
                    Status ="C",
                },

                new Work() {
                    MinistryWorksID =2,
                    MinistryID =0,
                    FormPeopleName ="PeopleB",
                    FormLanguage ="LangB",
                    FormLocation ="LocB",
                    Status ="C",
                },

                new Work() {
                    MinistryWorksID =1,
                    MinistryID =0,
                    FormPeopleName ="PeopleC",
                    FormLanguage ="LangC",
                    FormLocation ="LocC",
                    Status ="C",
                }

            };
        }
        public List<Work> GetAll()
        {
            return _works;  //;new List<Work>()
        }

        public Work GetOne(int Id)
        {
            return _works.FirstOrDefault(x => x.MinistryWorksID == Id);
        }
    }

    public class InMemoryForecastsRepository: IForecastsRepository
    {
        private readonly List<Forecast> _forecasts;
        public InMemoryForecastsRepository()
        {
            _forecasts = new List<Forecast>()
            {
                new Forecast() {
                    Pk = 1,
                    Extra = false,
                    Date = new DateTime(2022, 04, 01),
                    TemperatureC = 0,
                    Summary="Cold"
                },

                new Forecast() {
                    Pk = 2,
                    Extra = true,
                    Date = new DateTime(2022, 04, 02),
                    TemperatureC = 10,
                    Summary="Cool"
                },

                new Forecast() {
                    Pk = 3,
                    Extra = false,
                    Date = new DateTime(2022, 04, 03),
                    TemperatureC = 20,
                    Summary="Warm"
                },

                new Forecast() {
                    Pk = 4,
                    Extra = true,
                    Date = new DateTime(2022, 04, 04),
                    TemperatureC = 30,
                    Summary="HOT"
                }

            };
        }
        public List<Forecast> GetAll()
        {
            return _forecasts;  //_works;new List<Forecast>()
        }

        public Forecast GetOne(int Id)
        {
            return _forecasts.FirstOrDefault(x => x.Pk == Id);
        }
    }

}
