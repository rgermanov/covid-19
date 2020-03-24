using System;

namespace Germanov.Covid19.Website.Models
{
    public class CovidInfoModel
    {
        public string Province { get; set; }

        public string Country { get; set; }

        public DateTime Date { get; set; }

        public decimal ConfirmedCases { get; set; }

        public decimal RecoveredCases { get; set; }

        public decimal DeathCases { get; set; }
    }

}