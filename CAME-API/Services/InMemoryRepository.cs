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
        private List<Forecast> _forecasts;
        public InMemoryForecastsRepository()
        {
            _forecasts = new List<Forecast>()
            {
                new Forecast(
                    new ForecastNew(){
                        Extra = false,
                        Date = new DateTime(2022, 04, 01),
                        TemperatureC = 0,
                        Summary="Cold"
                    }
                ) { Id = 1 },

                new Forecast(
                    new ForecastNew(){
                        //Id = 2,
                        Extra = true,
                        Date = new DateTime(2022, 04, 02),
                        TemperatureC = 10,
                        Summary="Cool"
                    }
                ) { Id = 2 },

                new Forecast(
                    new ForecastNew(){
                        //Id = 3,
                        Extra = false,
                        Date = new DateTime(2022, 04, 03),
                        TemperatureC = 40,
                        Summary="Warm"
                    }
                ) { Id = 3 },

                new Forecast(
                    new ForecastNew(){
                        //Id = 4,
                        Extra = true,
                        Date = new DateTime(2022, 04, 04),
                        TemperatureC = 30,
                        Summary="HOT"
                    }
                ) { Id = 4 },

            };
        }
        public List<Forecast> GetAll()
        {
            return _forecasts;  //_works;new List<Forecast>()
        }

        public Forecast GetOne(int Id)
        {
            return _forecasts.FirstOrDefault(x => x.Id == Id);
        }

        public Forecast Add(ForecastNew nf)
        {
            Forecast f = new Forecast(nf);

            int m = 0;
            foreach (Forecast f0 in _forecasts) { if (f0.Id > m) { m = f0.Id; }; }
            m++;  // max of ids in _forecast +1
            f.Id = m;

            _forecasts.Add(f);
            return f;
        }

        public bool Update(int id, ForecastNew nf)
        {
            int m = Array.FindIndex<Forecast>(_forecasts.ToArray(), item => item.Id == id);
            if (m == -1)  { return false; }

            _forecasts[m].Extra = nf.Extra;
            _forecasts[m].Date = nf.Date;
            _forecasts[m].TemperatureC = nf.TemperatureC;
            _forecasts[m].Summary=nf.Summary;
            return true;
        }

        public bool Delete(int id)
        {
            int m = -1;
            m= Array.FindIndex<Forecast>(_forecasts.ToArray(), item => item.Id == id);
            if (m == -1)  { return false; }
            _forecasts.RemoveAt(m);
            return true;
        }

    }

}
