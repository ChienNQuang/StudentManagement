using System;

namespace StudentManagement.API.Helpers
{
    public static class DateTimeOffsetExtensions 
    {
        public static int GetCurrentAge (this DateTimeOffset dateTimeOffset)
        {
            var current = DateTimeOffset.UtcNow;
            int age = current.Year - dateTimeOffset.Year;

            if (current < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}