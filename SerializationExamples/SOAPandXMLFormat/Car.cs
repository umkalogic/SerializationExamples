using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationExamples
{
    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
        public override string ToString()
        {
            string str = TheRadio.ToString();
            return $"{str}, hatchback - {IsHatchBack}";
        }
    }
}
