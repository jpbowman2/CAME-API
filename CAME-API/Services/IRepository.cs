using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CAME_API.Entities;

namespace CAME_API.Services
{
    public interface IRepository
    {
        //List<Work> GetAll();
    }

    public interface IWorksRepository : IRepository
    {
        /*new*/ List<Work> GetAll();
        Work GetOne(int Id);
    }

    public interface IForecastsRepository : IRepository
    {
        /*new*/
        List<Forecast> GetAll();
        Forecast GetOne(int Id);
        Forecast Add(ForecastNew nf);
        bool Update(int id, ForecastNew nf);
        bool Delete(int id);
    }

}
