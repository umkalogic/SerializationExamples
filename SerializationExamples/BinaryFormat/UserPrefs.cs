using System;

namespace SerializationExamples.BinaryFormat
{
    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
        public override string ToString()
        {
            return $"Window color: {WindowColor}, Font size: {FontSize}\n";
        }
    }
}
