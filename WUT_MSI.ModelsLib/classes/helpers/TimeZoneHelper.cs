using System.Collections.Generic;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class TimeZoneHelper
    {
        public static int GetTimeZome(List<string> timezones)
        {
            if (timezones == null || timezones.Count == 0)
                return 1;
            
            return int.Parse(timezones[0].Substring(3).Split(':')[0]);
        }
    }
}
