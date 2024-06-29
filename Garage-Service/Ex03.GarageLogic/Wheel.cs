using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        public string ManufacturerName { get; private set; }
        public float CurrentAirPressure { get; private set; }
        public float MaxAirPressure { get; private set; }

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            Inflate(i_CurrentAirPressure);
        }

        public void Inflate(float i_Amount)
        {
            if (CurrentAirPressure + i_Amount > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }

            CurrentAirPressure += i_Amount;
        }
    }
}
