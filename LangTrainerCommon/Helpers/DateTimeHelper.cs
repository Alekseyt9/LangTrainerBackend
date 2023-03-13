﻿

namespace LangTrainerCommon.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime? SetKindUtc(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.SetKindUtc();
            }
            return null;
        }

        public static DateTime SetKindUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime;
            }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

    }
}