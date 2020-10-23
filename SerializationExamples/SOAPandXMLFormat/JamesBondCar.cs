using System;

namespace SerializationExamples
{
    [Serializable]
    public class JamesBondCar : Car
    {
        public bool CanFly;
        public bool CanSubmerge;
        public override string ToString()
        {
            string str = TheRadio.ToString();
            return $"{str}, hatchback - {IsHatchBack}, can fly - {CanFly}, can submerge - {CanSubmerge}";
        }
    }
}
