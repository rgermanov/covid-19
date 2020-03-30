using System.Collections.Generic;

namespace Germanov.Covid19.Website.Models
{
    public class HomePageViewMode
    {        
        public CovidInfoModel GermanyLastUpdate{ get;set; }

        public CovidInfoModel BulgariaLastUpdate { get; set; }

        public CovidInfoModel BelgiumLastUpdate { get; set; }        

        public List<string> CountryList { get; set; } = new List<string>();

        public string SelectedCountry { get; set; }

        public List<CovidInfoModel> SelectedCountryCases { get; set; }
               
    }
}