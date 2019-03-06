using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Utility
{
    public static class DateTimeUtility
    {
        public static long GetUnixTime(DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeSeconds();
        }

        public static DateTime GetDateTimeFromUnixTime(long unixTimestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimestamp).ToUniversalTime();
            return dtDateTime;
        }
    }
}
