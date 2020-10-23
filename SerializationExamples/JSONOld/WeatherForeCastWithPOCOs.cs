using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationExamples.JSONOld
{
    [DataContract]
    public class WeatherForecastWithPocos
    {
        [DataMember] public DateTimeOffset Date { get; set; }
        [DataMember] public int TemperatureCelsius { get; set; }
        [DataMember] public string Summary { get; set; }
        [DataMember] public string SummaryField;
        [DataMember] public IList<DateTimeOffset> DatesAvailable { get; set; }
        [DataMember] public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
        [DataMember] public string[] SummaryWords { get; set; }

        public WeatherForecastWithPocos()
        {
            SummaryField = "None";
        }

        public override string ToString()
        {
            return $"Date: {Date}, {TemperatureCelsius}C, {Summary}, {TemperatureRanges}";
        }
    }

}
