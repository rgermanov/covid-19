using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Germanov.Covid19.Website.Interfaces;
using Germanov.Covid19.Website.Models;

namespace Germanov.Covid19.Website.Services
{
    public class CovidDailyStatsService : ICovidDailyStatsService
    {
        private readonly string _fileNamePath = string.Empty;

        public CovidDailyStatsService()
        {
            _fileNamePath = ".\\App_Data\\full_data.csv";
        }
        public IEnumerable<CovidInfoModel> GetStats()
        {
            using (var reader = new StreamReader(_fileNamePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    
                    var records = new List<CovidInfoModel>();

                    while(csv.Read())
                    {
                        records.Add(new CovidInfoModel{
                            //Province = csv.GetField<string>("Province/State"),
                            Country = csv.GetField<string>("location"),
                            Date = csv.GetField<DateTime>("date"),
                            ConfirmedCases = csv.TryGetField<decimal>("total_cases", out decimal confirmed) ? confirmed : 0,
                            //RecoveredCases = csv.TryGetField<decimal>("Recovered", out decimal recovered) ? recovered : 0,
                            DeathCases = csv.TryGetField<decimal>("total_deaths", out decimal deaths) ? deaths : 0
                        });
                    }

                    return records;
                }
            }            
        }
    }
}