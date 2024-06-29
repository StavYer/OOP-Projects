using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_MaxWheelPressure = 33;

        public eLicenseType LicenseType { get; set; }
        public int EngineVolume { get; private set; }
        public int MaxWheelPressure { get { return k_MaxWheelPressure; } private set { } }

        internal Motorcycle(EnergySource i_EnergySource)
            : base()
        {
            EnergySource = i_EnergySource;
        }

        public void InitializeMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelManufacturer,
            float i_InitialWheelAirPressure,
            float i_InitialLevelOfEnergy,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
        {
            base.SetVehicleDetails(
                i_ModelName,
                i_LicenseNumber,
                i_OwnerName,
                i_OwnerPhoneNumber,
                i_WheelManufacturer,
                i_InitialWheelAirPressure,
                i_InitialLevelOfEnergy);

            EngineVolume = i_EngineVolume;
            LicenseType = i_LicenseType;

            for (int i = 0; i < 2; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer, i_InitialWheelAirPressure, k_MaxWheelPressure));
            }
        }

        internal override string GetVehicleDetails()
        {
            string moreDetails = string.Format(@"Maximum Wheel Pressure: {0} psi,
Current Wheel Pressure: {1} psi,
Motorcycle License Type: {2},
Engine Volume: {3} cc",
                k_MaxWheelPressure,
                Wheels[0].CurrentAirPressure,
                LicenseType.ToString(),
                EngineVolume);

            return string.Format(@"{0},
{1}", base.GetVehicleDetails(), moreDetails);
        }
    }
}
