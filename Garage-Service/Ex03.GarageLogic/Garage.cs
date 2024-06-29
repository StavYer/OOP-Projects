using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;
        private VehicleConstructor m_VehicleConstructor;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
            m_VehicleConstructor = new VehicleConstructor();
        }

        public Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            return m_VehicleConstructor.CreateVehicle(i_VehicleType);
        }

        public bool VehicleIsInGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddNewVehicle(string i_LicenseNumber, Vehicle i_Vehicle)
        {
            if (!VehicleIsInGarage(i_LicenseNumber))
            {
                m_Vehicles.Add(i_LicenseNumber, i_Vehicle);
            }
        }

        public List<string> GetLicenseNumbers(eVehicleStatus? i_StatusFilter = null)
        {
            if (i_StatusFilter == null)
            {
                return m_Vehicles.Keys.ToList();
            }
            else
            {
                return m_Vehicles.Where(v => v.Value.Status == i_StatusFilter).Select(v => v.Key).ToList();
            }
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                m_Vehicles[i_LicenseNumber].Status = i_NewStatus;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void InflateTiresToMax(string i_LicenseNumber)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                foreach (Wheel wheel in m_Vehicles[i_LicenseNumber].Wheels)
                {
                    wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                if (m_Vehicles[i_LicenseNumber].EnergySource is FuelEnergySource fuelEnergySource)
                {
                    fuelEnergySource.AddFuel(i_Amount, i_FuelType);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_Hours)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                if (m_Vehicles[i_LicenseNumber].EnergySource is ElectricEnergySource electricEnergySource)
                {
                    electricEnergySource.Charge(i_Hours);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public string GetVehicleInformation(string i_LicenseNumber)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                return m_Vehicles[i_LicenseNumber].GetVehicleDetails();
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
