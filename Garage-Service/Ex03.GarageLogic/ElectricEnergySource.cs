using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEnergySource : EnergySource
    {
        public ElectricEnergySource(float i_MaxHours)
        {
            CurrentLevel = 0;
            MaxCapacity = i_MaxHours;
        }

        public void Charge(float i_Hours)
        {
            AddEnergy(i_Hours);
        }
    }
}
