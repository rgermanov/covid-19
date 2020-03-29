using System.Collections.Generic;

namespace Germanov.Covid19.Website.Models
{
    public class HomePageViewMode
    {
        public List<CovidInfoModel> CovidInfo { get; set; } = new List<CovidInfoModel>();

        public CovidInfoModel GermanyLastUpdate{ get;set; }

        public CovidInfoModel BulgariaLastUpdate { get; set; }

        public CovidInfoModel BelgiumLastUpdate { get; set; }

        public List<CovidInfoModel> ChartSeries { get; set; }
    }
}