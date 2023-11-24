
using System;

namespace HospitalManagementSystem.Utils
{
    public static class IDGenerator
    {
        public static string GenerateID()
        {
            // Return a unique ID, perhaps using a combination of DateTime and some random string
            return DateTime.UtcNow.Ticks.ToString();
        }
    }
}
