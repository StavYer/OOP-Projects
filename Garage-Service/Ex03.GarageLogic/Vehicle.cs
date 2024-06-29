using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string ModelName { get; private set; }
        public string LicenseNumber { get; private set; }
        internal List<Wheel> Wheels { get; private set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }

        private string m_WheelManufacturer;
        public string WheelManufacturer { get { return m_WheelManufacturer; } private set { } }
        public eVehicleStatus Status { get; set; }

        internal EnergySource EnergySource { get; set; }

        public float RemainingEnergyPercentage
        {
            get
            {
                return EnergySource.CurrentLevel / EnergySource.MaxCapacity;
            }
            set
            {
            }
        }
        private float m_InitialWheelAirPressure;

        public Vehicle()
        {
            Status = eVehicleStatus.InRepair;
            Wheels = new List<Wheel>();
        }

        protected void SetVehicleDetails(
            string i_ModelName,
            string i_LicenseNumber,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelManufacturer,
            float i_InitialWheelAirPressure,
            float i_InitialEnergyLevel)
        {
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_WheelManufacturer = i_WheelManufacturer;
            m_InitialWheelAirPressure = i_InitialWheelAirPressure;
            EnergySource.AddEnergy(i_InitialEnergyLevel);
        }

        internal virtual string GetVehicleDetails()
        {
            bool isFuelBased = EnergySource is FuelEnergySource;
            string energyUnit = isFuelBased ? "Liters" : "Hours";
            string energySourceType = isFuelBased ? (EnergySource as FuelEnergySource).TypeOfFuel.ToString() : "Electric";
            float remainingEnergy = EnergySource.CurrentLevel;

            string details = string.Format(@"Vehicle License Number: {0},
Vehicle Model Name: {1},
Owner's Name: {2},
Owner's Phone Number: {3},
Vehicle Status: {4},
Energy Source: {5},
Remaining Energy: {6}% {7} of total,
Total Energy: {8} {7},
Wheel Manufacturer: {9}",
                LicenseNumber,
                ModelName,
                OwnerName,
                OwnerPhoneNumber,
                Status.ToString(),
                energySourceType,
                RemainingEnergyPercentage,
                energyUnit,
                EnergySource.MaxCapacity,
                m_WheelManufacturer);

            return details;
        }
    }
}
