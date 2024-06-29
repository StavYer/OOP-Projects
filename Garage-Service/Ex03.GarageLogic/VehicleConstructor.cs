using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        FuelCar,
        FuelMotorcycle,
        FuelTruck,
        ElectricCar,
        ElectricMotorcycle
    }

    internal class VehicleConstructor
    {
        public VehicleConstructor() { }

        public Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicleToConstruct = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    vehicleToConstruct = new Car(new FuelEnergySource(eFuelType.Octane95, 45f));
                    break;
                case eVehicleType.FuelMotorcycle:
                    vehicleToConstruct = new Motorcycle(new FuelEnergySource(eFuelType.Octane98, 5.5f));
                    break;
                case eVehicleType.FuelTruck:
                    vehicleToConstruct = new Truck(new FuelEnergySource(eFuelType.Soler, 120f));
                    break;
                case eVehicleType.ElectricCar:
                    vehicleToConstruct = new Car(new ElectricEnergySource(3.5f));
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicleToConstruct = new Motorcycle(new ElectricEnergySource(2.5f));
                    break;
            }

            return vehicleToConstruct;
        }
    }
}
