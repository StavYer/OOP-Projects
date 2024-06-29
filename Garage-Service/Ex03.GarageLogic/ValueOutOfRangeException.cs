using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; private set; }
        public float MinValue { get; private set; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(String.Format("Exceeds allowed range. Allowed range: {0} - {1}", i_MinValue, i_MaxValue))
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
