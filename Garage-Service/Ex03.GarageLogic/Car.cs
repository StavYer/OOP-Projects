using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_MaxWheelPressure = 31;

        public eCarColor Color { get; private set; }
        public eNumberOfDoors NumberOfDoors { get; private set; }
        public int MaxWheelPressure { get { return k_MaxWheelPressure; } private set { } }

        internal Car(EnergySource i_EnergySource)
            : base()
        {
            EnergySource = i_EnergySource;
        }

        public void InitializeCar(
            string i_ModelName,
            string i_LicenseNumber,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelManufacturer,
            float i_InitialWheelAirPressure,
            float i_InitialLevelOfEnergy,
            eCarColor i_CarColor,
            eNumberOfDoors i_DoorNumber)
        {
            base.SetVehicleDetails(
                i_ModelName,
                i_LicenseNumber,
                i_OwnerName,
                i_OwnerPhoneNumber,
                i_WheelManufacturer,
                i_InitialWheelAirPressure,
                i_InitialLevelOfEnergy);

            Color = i_CarColor;
            NumberOfDoors = i_DoorNumber;

            for (int i = 0; i < 5; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturer, i_InitialWheelAirPressure, k_MaxWheelPressure));
            }
        }

        internal override string GetVehicleDetails()
        {
            string moreDetails = string.Format(@"Maximum Wheel Pressure: {0} psi,
Current Wheel Pressure: {1} psi,
Car Color: {2},
Number of Doors: {3}", 
                k_MaxWheelPressure,
                Wheels[0].CurrentAirPressure,
                Color.ToString(),
                NumberOfDoors.ToString());

            return string.Format(@"{0},
{1}", base.GetVehicleDetails(), moreDetails);
        }
    }
}
