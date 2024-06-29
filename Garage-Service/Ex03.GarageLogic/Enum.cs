using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A, A1, AA, B1
    }

    public enum eVehicleStatus
    {
        InRepair,
        Repaired,
        PaidFor
    }

    public enum eFuelType
    {
        Soler, Octane95, Octane96, Octane98
    }

    public enum eCarColor
    {
        Yellow, White, Red, Gray
    }

    public enum eNumberOfDoors
    {
        Two = 2, Three, Four, Five
    }
}
