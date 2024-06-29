using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEnergySource : EnergySource
    {
        public eFuelType TypeOfFuel { get; set; }

        public FuelEnergySource(eFuelType i_FuelType, float i_MaxLiters)
        {
            TypeOfFuel = i_FuelType;
            CurrentLevel = 0;
            MaxCapacity = i_MaxLiters;
        }

        public void AddFuel(float i_Amount, eFuelType i_ProvidedFuelType)
        {
            if (i_ProvidedFuelType != TypeOfFuel)
            {
                throw new ArgumentException(String.Format("Cannot refuel with {0}. This vehicle requires {1}.", i_ProvidedFuelType, TypeOfFuel));
            }

            AddEnergy(i_Amount);
        }
    }
}
