using System.Collections.Generic;
using Germanov.Covid19.Website.Models;

namespace Germanov.Covid19.Website.Interfaces
{
    public interface ICovidDailyStatsService
    {
        IEnumerable<CovidInfoModel> GetStats();        
    }
}