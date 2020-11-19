using System;
using ArInterfaces;

namespace ArServices
{
    class DateClassMgr : iDateClassMgr
    {
        //get current time based on Singapore Standard Time 
        //SGT - UTC +8
        public DateTime GetCurrentDate()
        {
            DateTime _localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));
            _localTime = _localTime.Date;

            return _localTime;
        }

        public DateTime GetCurrentDateTime()
        {
            DateTime _localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));

            return _localTime;
        }
    }
}
