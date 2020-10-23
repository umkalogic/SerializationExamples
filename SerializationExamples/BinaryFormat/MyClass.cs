using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationExamples
{
    [Serializable]
    public class MyClass
    {
        public int N1 = 0;
        [NonSerialized] public int N2 = 0; 
        public string Str1 = null;
        [NonSerialized] public string Str2 = null;

        public override string ToString()
        {
            return $"N1 = {N1}, N2 = {N2}, str1 = {Str1}, str2 = {Str2}.\n";
        }
    }
}
