using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class EnergySource
    {
        public float CurrentLevel { get; protected set; }
        public float MaxCapacity { get; protected set; }

        internal void AddEnergy(float i_Amount)
        {
            if (CurrentLevel + i_Amount > MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxCapacity);
            }

            CurrentLevel += i_Amount;
        }
    }
}
