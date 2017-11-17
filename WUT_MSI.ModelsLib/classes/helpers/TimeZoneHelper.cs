using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
