using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationExamples
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters;
        public bool HasSubWoofers;
        public double[] StationPresets;
        [NonSerialized]
        public string RadioId = "XF-552RR6";

        public override string ToString()
        {
            string str = $"Radio {RadioId}: tweeters - {HasTweeters}, subwoofers - {HasSubWoofers}, stations - [ ";
            if (StationPresets != null)
            {
                for (int i = 0; i < StationPresets.Length; i++)
                {
                    str += $"{StationPresets[i]} ";
                }
            }

            str += $"]";
            return  str;
        }
    }
}
