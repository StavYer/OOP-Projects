using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private Garage s_Garage = new Garage();

        public void Manage()
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                int choice = GetUserChoice(8);
                switch (choice)
                {
                    case 1:
                        InsertNewVehicle();
                        break;
                    case 2:
                        DisplayLicenseNumbers();
                        break;
                    case 3:
                        ChangeVehicleStatus();
                        break;
                    case 4:
                        InflateTiresToMaximum();
                        break;
                    case 5:
                        RefuelVehicle();
                        break;
                    case 6:
                        ChargeVehicle();
                        break;
                    case 7:
                        DisplayVehicleInformation();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("Garage Management System");
            Console.WriteLine("1. Insert New Vehicle");
            Console.WriteLine("2. Display License Numbers");
            Console.WriteLine("3. Change Vehicle Status");
            Console.WriteLine("4. Inflate Tires to Maximum");
            Console.WriteLine("5. Refuel Vehicle");
            Console.WriteLine("6. Charge Vehicle");
            Console.WriteLine("7. Display Vehicle Information");
            Console.WriteLine("0. Exit");
            Console.WriteLine("");
        }

        private int GetUserChoice(int i_MenuLength)
        {
            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice >= i_MenuLength)
            {
                Console.WriteLine("Invalid input. Please enter a number in range.");
                Console.Write("Enter your choice: ");
            }
            Console.WriteLine("");
            return choice;
        }

        private void InsertNewVehicle()
        {
            Console.WriteLine("Select Vehicle Type:");
            eVehicleType vehicleType = (eVehicleType)GetUserChoice(Enum.GetNames(typeof(eVehicleType)).Length);

            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();
            try
            {
                if (s_Garage.VehicleIsInGarage(licenseNumber))
                {
                    Console.WriteLine("Vehicle is already in the garage. Status set to 'In Repair'.");
                    s_Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                }
                else
                {
                    Vehicle newVehicle = s_Garage.CreateVehicle(vehicleType);
                    Console.Write("Enter Model Name: ");
                    string modelName = Console.ReadLine();
                    Console.Write("Enter Owner Name: ");
                    string ownerName = Console.ReadLine();
                    Console.Write("Enter Owner Phone Number: ");
                    string ownerPhoneNumber = Console.ReadLine();
                    Console.Write("Enter Wheel Manufacturer: ");
                    string wheelManufacturer = Console.ReadLine();
                    Console.Write("Enter Initial Wheel Air Pressure: ");
                    float initialWheelAirPressure = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Initial Level of Energy (current liters of fuel, current time left to operate...):");
                    float initialLevelOfEnergy = float.Parse(Console.ReadLine());

                    try
                    {
                        switch (newVehicle)
                        {
                            case Car car:
                                Console.WriteLine("Select Car Color:");
                                foreach (var color in Enum.GetValues(typeof(eCarColor)))
                                {
                                    Console.WriteLine($"{(int)color}. {color}");
                                }
                                eCarColor carColor = (eCarColor)GetUserChoice(Enum.GetNames(typeof(eCarColor)).Length);
                                Console.WriteLine("Select Number of Doors:");
                                foreach (var doors in Enum.GetValues(typeof(eNumberOfDoors)))
                                {
                                    Console.WriteLine($"{(int)doors - 2}. {doors}");
                                }
                                eNumberOfDoors numberOfDoors = (eNumberOfDoors)GetUserChoice(Enum.GetNames(typeof(eNumberOfDoors)).Length) + 2;
                                car.InitializeCar(modelName, licenseNumber, ownerName, ownerPhoneNumber, wheelManufacturer, initialWheelAirPressure, initialLevelOfEnergy, carColor, numberOfDoors);
                                break;

                            case Motorcycle motorcycle:
                                Console.WriteLine("Select License Type:");
                                foreach (var licenseType in Enum.GetValues(typeof(eLicenseType)))
                                {
                                    Console.WriteLine($"{(int)licenseType}. {licenseType}");
                                }
                                eLicenseType motorcycleLicenseType = (eLicenseType)GetUserChoice(Enum.GetNames(typeof(eLicenseType)).Length);
                                Console.Write("Enter Engine Volume: ");
                                int motorcycleEngineVolume = int.Parse(Console.ReadLine());
                                motorcycle.InitializeMotorcycle(modelName, licenseNumber, ownerName, ownerPhoneNumber, wheelManufacturer, initialWheelAirPressure, initialLevelOfEnergy,
                                    motorcycleLicenseType, motorcycleEngineVolume);
                                break;

                            case Truck truck:
                                Console.Write("Does the truck carry hazardous materials? (yes/no): ");
                                bool carriesHazardousMaterials = Console.ReadLine().ToLower() == "yes";
                                Console.Write("Enter Cargo Volume: ");
                                float cargoVolume = float.Parse(Console.ReadLine());
                                truck.InitializeTruck(modelName, licenseNumber, ownerName, ownerPhoneNumber, wheelManufacturer, initialWheelAirPressure, initialLevelOfEnergy,
                                    carriesHazardousMaterials, cargoVolume);
                                break;
                        }
                        s_Garage.AddNewVehicle(licenseNumber, newVehicle);
                        Console.WriteLine("Vehicle added to the garage.");
                    }
                    catch (ValueOutOfRangeException)
                    {
                        Console.WriteLine("You have set either an invalid amount of fuel or an invalid wheel pressure. Please try again.");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You have entered an invalid output. Please try again.");
            }
            Console.WriteLine("");
        }

        private void DisplayLicenseNumbers()
        {
            Console.WriteLine("Select filter:");
            Console.WriteLine("0. All");
            Console.WriteLine("1. In Repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid For");
            Console.WriteLine("");
            int choice = GetUserChoice(4);
            List<string> licenseNumbers = null;
            switch (choice)
            {
                case 0:
                    licenseNumbers = s_Garage.GetLicenseNumbers();
                    break;
                case 1:
                    licenseNumbers = s_Garage.GetLicenseNumbers(eVehicleStatus.InRepair);
                    break;
                case 2:
                    licenseNumbers = s_Garage.GetLicenseNumbers(eVehicleStatus.Repaired);
                    break;
                case 3:
                    licenseNumbers = s_Garage.GetLicenseNumbers(eVehicleStatus.PaidFor);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            if (licenseNumbers != null)
            {
                Console.WriteLine("License Numbers:");
                licenseNumbers.ForEach(Console.WriteLine);
            }
            Console.WriteLine("");
        }

        private void ChangeVehicleStatus()
        {
            try
            {
                Console.Write("Enter License Number: ");
                string licenseNumber = Console.ReadLine();
                Console.WriteLine("Select New Status:");
                foreach (var status in Enum.GetValues(typeof(eVehicleStatus)))
                {
                    Console.WriteLine($"{(int)status}. {status}");
                }
                eVehicleStatus newStatus = (eVehicleStatus)GetUserChoice(Enum.GetNames(typeof(eVehicleStatus)).Length);
                s_Garage.ChangeVehicleStatus(licenseNumber, newStatus);
                Console.WriteLine("Vehicle status updated.");
                Console.WriteLine("");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This vehicle is not in our garage. Please try again.");
            }
        }

        private void InflateTiresToMaximum()
        {
            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();
            try
            {
                s_Garage.InflateTiresToMax(licenseNumber);
                Console.WriteLine("Tires inflated to maximum pressure.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid License Number. The Vehicle is not in our Garage.");
            }
            Console.WriteLine("");
        }

        private void DisplayEnum(Type i_enumType)
        {
            foreach (var bullet in Enum.GetValues(i_enumType))
            {
                Console.WriteLine(String.Format("{0}. {1}", (int)bullet, bullet));
            }
        }

        private void RefuelVehicle()
        {
            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Select Fuel Type:");
            foreach (var fuel in Enum.GetValues(typeof(eFuelType)))
            {
                Console.WriteLine(String.Format("{0}. {1}", (int)fuel, fuel));
            }

            eFuelType fuelType = (eFuelType)GetUserChoice(Enum.GetNames(typeof(eFuelType)).Length);
            Console.Write("Enter amount to refuel: ");
            float amount = float.Parse(Console.ReadLine());
            try
            {
                s_Garage.RefuelVehicle(licenseNumber, fuelType, amount);
                Console.WriteLine("Vehicle refueled.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The vehicle is either not in our garage, or you have provided a wrong fuel type.");
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine("Can't refuel - You have exceeded the maximum capacity of the tank!");
            }

            Console.WriteLine("");
        }

        private void ChargeVehicle()
        {
            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();
            Console.Write("Enter hours to charge: ");
            float hours = float.Parse(Console.ReadLine());
            try
            {
                s_Garage.ChargeVehicle(licenseNumber, hours);
                Console.WriteLine("Vehicle charged.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The vehicle is either not in our garage, or operates on fuel.");
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine("Exceeded Maximum Charger Capacity. Please Try Again.");
            }
        }

        private void DisplayVehicleInformation()
        {
            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();
            string vehicleInfo = s_Garage.GetVehicleInformation(licenseNumber);
            Console.WriteLine("Vehicle Information:");
            Console.WriteLine(vehicleInfo);
            Console.WriteLine("");
        }
    }
}
