using System.Runtime.Serialization;

namespace SerializationExamples.JSONOld
{
    [DataContract]
    public class HighLowTemps
    {
        [DataMember]
        public int High { get; set; }
        [DataMember]
        public int Low { get; set; }
    }
}
