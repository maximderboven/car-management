using System;
using Insurance.Domain;

namespace Insurance.UI.CA.Extensions
{
    internal static class DriverExtension
    {
        internal static string GetInfo(this Driver d)
        {
            return $"{d.LastName} {d.FirstName} (born on {d.DateOfBirth.ToShortDateString()})";
        }
    }
}