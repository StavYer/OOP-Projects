using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool CarriesHazardousMaterials { get; private set; }
        public float CargoVolume { get; private set; }

        private const int k_MaxWheelPressure = 28;
        public int MaxWheelPressure { get { return k_MaxWheelPressure; } private set { } }

        internal Truck(EnergySource i_EnergySource)
            : base()
        {
            EnergySource = i_EnergySource;
        }

        public void InitializeTruck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelManufacturer,
            float i_InitialWheelAirPressure,
            float i_InitialLevelOfEnergy,
            bool i_CarriesHazardousMaterials,
            float i_CargoVolume)
        {
            base.SetVehicleDetails(
                i_ModelName,
                i_LicenseNumber,
                i_OwnerName,
                i_OwnerPhoneNumber,
                i_WheelManufacturer,
                i_InitialWheelAirPressure,
                i_InitialLevelOfEnergy);

            CarriesHazardousMaterials = i_CarriesHazardousMaterials;
            CargoVolume = i_CargoVolume;

            for (int i = 0; i < 12; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer, i_InitialWheelAirPressure, k_MaxWheelPressure));
            }
        }

        internal override string GetVehicleDetails()
        {
            string carriesDangerousMaterials = CarriesHazardousMaterials ? "Yes" : "No";
            string moreDetails = string.Format(@"Maximum Wheel Pressure: {0} psi,
Current Wheel Pressure: {1} psi,
Truck Carries Hazardous Materials: {2},
Truck Cargo Volume: {3} cc",
                k_MaxWheelPressure,
                Wheels[0].CurrentAirPressure,
                carriesDangerousMaterials,
                CargoVolume);

            return string.Format(@"{0},
{1}", base.GetVehicleDetails(), moreDetails);
        }
    }
}
