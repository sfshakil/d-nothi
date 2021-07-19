using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Utility
{
    public class ConversionMethod
    {
        public static string ObjecttoJson(object obj)
        {
            var jsonString = new JavaScriptSerializer().Serialize(obj);
            return jsonString;
        }
        public static string BanglaDigittoEngDigit(string input)
        {
           
            string output = input.Replace("০", "0").Replace("১", "1").Replace("২", "2").Replace("৩", "3").Replace("৪", "4").Replace("৫", "5").Replace("৬", "6").Replace("৭", "7").Replace("৮", "8").Replace("৯", "9");
            return output;
        }
        public static string EngDigittoBanDigit(string input)
        {

            string output = input.Replace("0","০" ).Replace("1","১").Replace("2","২").Replace("3","৩").Replace("4","৪").Replace("5","৫").Replace("6","৬").Replace("7","৭").Replace("8","৮" ).Replace("9","৯");
            return output;
        }

        public static string GetBengaliDayFromEnglishDay(string EnglishDay)
        {
            if(EnglishDay=="Saturday")
            {
                return "শনিবার";
            }
            else if(EnglishDay=="Sunday")
            {
                return "রবিবার";
            }
            else if (EnglishDay == "Monday")
            {
                return "সোমবার";
            }
            else if (EnglishDay == "Tuesday")
            {
                return "মঙ্গলবার";
            }
            else if (EnglishDay == "Wednesday")
            {
                return "বুধবার";
            }
            else if (EnglishDay == "Thursday")
            {
                return "বৃহস্পতিবার";
            }
            else
            {
                return "শুক্রবার";
            }

        }

        public static string GetBengaliMonthFromEnglishMonthNo(int MonthNo)
        {
            if (MonthNo == 1)
            {
                return "বৈশাখ";
            }
            else if (MonthNo == 2)
            {
                return "জ্যৈষ্ঠ";
            }
            else if (MonthNo == 3)
            {
                return "আষাঢ়";
            }
            else if (MonthNo == 4)
            {
                return "শ্রাবণ";
            }
            else if (MonthNo == 5)
            {
                return "ভাদ্র";
            }
            else if (MonthNo == 6)
            {
                return "আশ্বিন";
            }
            else if(MonthNo ==7)
            {
                return "কার্তিক";
            }
            else if (MonthNo == 8)
            {
                return "অগ্রহায়ণ";
            }
            else if (MonthNo == 9)
            {
                return "পৌষ";
            }
            else if (MonthNo == 10)
            {
                return "মাঘ";

            }
            else if(MonthNo==11)
            {
                return "ফাল্গুন";
            }
            else
            {
                return "চৈত্র";
            }

        }

        public static string GetEngMonthNameinBengali(int MonthNo)
        {
            if (MonthNo == 1)
            {
                return "জানুয়ারী";
            }
            else if (MonthNo == 2)
            {
                return "ফেব্রুয়ারী";
            }
            else if (MonthNo == 3)
            {
                return "মার্চ";
            }
            else if (MonthNo == 4)
            {
                return "এপ্রিল";
            }
            else if (MonthNo == 5)
            {
                return "মে";
            }
            else if (MonthNo == 6)
            {
                return "জুন";
            }
            else if (MonthNo == 7)
            {
                return "জুলাই";
            }
            else if (MonthNo == 8)
            {
                return "আগষ্ট";
            }
            else if (MonthNo == 9)
            {
                return "সেপ্টেম্বর";
            }
            else if (MonthNo == 10)
            {
                return "অক্টোবর";

            }
            else if (MonthNo == 11)
            {
                return "নভেম্বর";
            }
            else
            {
                return "ডিসেম্বর";
            }

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string EnglishNumberToBangla(string Num)
        {
            return string.Concat(Num.ToString().Select(c => (char)('\u09E6' + c - '0')));
        }

        public static string FilterJsonResponse(string jsonResponsewithGarbageData)
        {
            try
            {
                int firstStringIndex = jsonResponsewithGarbageData.IndexOf("{\"status\":");

                var pureJsonResponse = jsonResponsewithGarbageData.Substring(firstStringIndex, jsonResponsewithGarbageData.Length - firstStringIndex);

                return pureJsonResponse;
            }
            catch
            {
                return "";
            }

        }



        public static string GetDakTypeNameBangla(string value)
        {
            if (value == "Daptorik")
            {
                return "দাপ্তরিক";
            }
            else
            {
                return "নাগরিক";
            }

        }

        
    }


    internal class BengaliCalendar : Calendar
    {
        /// <summary>Represents the current era. This field is constant.</summary>
        public const int ADEra = 1;
        internal const int DatePartYear = 0;
        internal const int DatePartDayOfYear = 1;
        internal const int DatePartMonth = 2;
        internal const int DatePartDay = 3;
        internal const int MaxYear = 9999;
        internal static readonly int[] DaysToMonth365 = new int[]
        {
        0,
        31,
        62,
        93,
        124,
        155,
        185,
        215,
        245,
        275,
        305,
        335,
        365
        };
        internal static readonly int[] DaysToMonth366 = new int[]
        {
        0,
        31,
        62,
        93,
        124,
        155,
        185,
        215,
        245,
        275,
        305,
        336,
        366
        };
        private static volatile Calendar s_defaultInstance;
        private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 2029;
        /// <summary>Gets the earliest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type.</summary>
        /// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type, which is the first moment of January 1, 0001 C.E. and is equivalent to <see cref="F:System.DateTime.MinValue" />.</returns>
        [ComVisible(false)]
        public override DateTime MinSupportedDateTime
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>Gets the latest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type.</summary>
        /// <returns>The latest date and time supported by the <see cref="T:System.Globalization.GregorianCalendar" /> type, which is the last moment of December 31, 9999 C.E. and is equivalent to <see cref="F:System.DateTime.MaxValue" />.</returns>
        [ComVisible(false)]
        public override DateTime MaxSupportedDateTime
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return DateTime.MaxValue;
            }
        }
        /// <summary>Gets a value that indicates whether the current calendar is solar-based, lunar-based, or a combination of both.</summary>
        /// <returns>A <see cref="F:System.Globalization.CalendarAlgorithmType.SolarCalendar" /> object.</returns>
        [ComVisible(false)]
        public override CalendarAlgorithmType AlgorithmType
        {
            get
            {
                return CalendarAlgorithmType.SolarCalendar;
            }
        }
        /// <summary>Gets the list of eras in the <see cref="T:System.Globalization.GregorianCalendar" />.</summary>
        /// <returns>An array of integers that represents the eras in the <see cref="T:System.Globalization.GregorianCalendar" />.</returns>
        public override int[] Eras
        {
            get
            {
                return new int[]
                {
                1
                };
            }
        }

        internal static Calendar GetDefaultInstance()
        {
            if (s_defaultInstance == null)
            {
                s_defaultInstance = new BengaliCalendar();
            }
            return s_defaultInstance;
        }

        internal virtual int GetDatePart(long ticks, int part)
        {
            DateTime bengaliDiff = new DateTime(594, 4, 14);
            ticks = ticks - bengaliDiff.Ticks;

            int i = (int)(ticks / 864000000000L);
            int num = i / 146097;
            i -= num * 146097;
            int num2 = i / 36524;
            if (num2 == 4)
            {
                num2 = 3;
            }
            i -= num2 * 36524;
            int num3 = i / 1461;
            i -= num3 * 1461;
            int num4 = i / 365;
            if (num4 == 4)
            {
                num4 = 3;
            }
            if (part == 0)
            {
                return num * 400 + num2 * 100 + num3 * 4 + num4 + 1;
            }
            i -= num4 * 365;
            if (part == 1)
            {
                return i + 1;
            }
            int[] array = (num4 == 3 && (num3 != 24 || num2 == 3)) ? DaysToMonth366 : DaysToMonth365;
            int num5 = i >> 6;
            while (i >= array[num5])
            {
                num5++;
            }
            if (part == 2)
            {
                return num5;
            }
            return i - array[num5 - 1] + 1;
        }
        internal static long GetAbsoluteDate(int year, int month, int day)
        {
            if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
            {
                int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? DaysToMonth366 : DaysToMonth365;
                if (day >= 1 && day <= array[month] - array[month - 1])
                {
                    int num = year - 1;
                    int num2 = num * 365 + num / 4 - num / 100 + num / 400 + array[month - 1] + day - 1;
                    return (long)num2;
                }
            }
            throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadYearMonthDay");
        }
        internal virtual long DateToTicks(int year, int month, int day)
        {
            return GetAbsoluteDate(year, month, day) * 864000000000L;
        }
        /// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of months away from the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of months to the specified <see cref="T:System.DateTime" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to which to add months. </param>
        /// <param name="months">The number of months to add. </param>
        /// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="months" /> is less than -120000.-or- <paramref name="months" /> is greater than 120000. </exception>
        public override DateTime AddMonths(DateTime time, int months)
        {
            if (months < -120000 || months > 120000)
            {
                throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
                {
                -120000,
                120000
                }));
            }
            int num = this.GetDatePart(time.Ticks, 0);
            int num2 = this.GetDatePart(time.Ticks, 2);
            int num3 = this.GetDatePart(time.Ticks, 3);
            int num4 = num2 - 1 + months;
            if (num4 >= 0)
            {
                num2 = num4 % 12 + 1;
                num += num4 / 12;
            }
            else
            {
                num2 = 12 + (num4 + 1) % 12;
                num += (num4 - 11) / 12;
            }
            int[] array = (num % 4 == 0 && (num % 100 != 0 || num % 400 == 0)) ? DaysToMonth366 : DaysToMonth365;
            int num5 = array[num2] - array[num2 - 1];
            if (num3 > num5)
            {
                num3 = num5;
            }
            long ticks = this.DateToTicks(num, num2, num3) + time.Ticks % 864000000000L;
            //Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
            return new DateTime(ticks);
        }
        /// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to which to add years. </param>
        /// <param name="years">The number of years to add. </param>
        /// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range. </exception>
        public override DateTime AddYears(DateTime time, int years)
        {
            return this.AddMonths(time, years * 12);
        }
        /// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>An integer from 1 to 31 that represents the day of the month in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override int GetDayOfMonth(DateTime time)
        {
            return this.GetDatePart(time.Ticks, 3);
        }
        /// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override DayOfWeek GetDayOfWeek(DateTime time)
        {
            return (DayOfWeek)((time.Ticks / 864000000000L + 1L) % 7);
        }
        /// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>An integer from 1 to 366 that represents the day of the year in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override int GetDayOfYear(DateTime time)
        {
            return this.GetDatePart(time.Ticks, 1);
        }
        /// <summary>Returns the number of days in the specified month in the specified year in the specified era.</summary>
        /// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="month">An integer from 1 to 12 that represents the month. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar.-or- <paramref name="month" /> is outside the range supported by the calendar. </exception>
        public override int GetDaysInMonth(int year, int month, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", "ArgumentOutOfRange_Range");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("month", "ArgumentOutOfRange_Month");
            }
            int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? DaysToMonth366 : DaysToMonth365;
            return array[month] - array[month - 1];
        }
        /// <summary>Returns the number of days in the specified year in the specified era.</summary>
        /// <returns>The number of days in the specified year in the specified era.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar.</exception>
        public override int GetDaysInYear(int year, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
                {
                1,
                9999
                }));
            }
            if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0))
            {
                return 365;
            }
            return 366;
        }
        /// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>An integer that represents the era in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override int GetEra(DateTime time)
        {
            return 1;
        }
        /// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>An integer from 1 to 12 that represents the month in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override int GetMonth(DateTime time)
        {
            return this.GetDatePart(time.Ticks, 2);
        }
        /// <summary>Returns the number of months in the specified year in the specified era.</summary>
        /// <returns>The number of months in the specified year in the specified era.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar. </exception>
        public override int GetMonthsInYear(int year, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year >= 1 && year <= 9999)
            {
                return 12;
            }
            throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
            {
            1,
            9999
            }));
        }
        /// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
        /// <returns>An integer that represents the year in <paramref name="time" />.</returns>
        /// <param name="time">The <see cref="T:System.DateTime" /> to read. </param>
        public override int GetYear(DateTime time)
        {
            return this.GetDatePart(time.Ticks, 0);
        }
        /// <summary>Determines whether the specified date in the specified era is a leap day.</summary>
        /// <returns>true if the specified day is a leap day; otherwise, false.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="month">An integer from 1 to 12 that represents the month. </param>
        /// <param name="day">An integer from 1 to 31 that represents the day. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar. -or- <paramref name="year" /> is outside the range supported by the calendar.-or- <paramref name="month" /> is outside the range supported by the calendar.-or- <paramref name="day" /> is outside the range supported by the calendar. </exception>
        public override bool IsLeapDay(int year, int month, int day, int era)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("month", "ArgumentOutOfRange_Range");
            }
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", "ArgumentOutOfRange_Range");
            }
            if (day < 1 || day > this.GetDaysInMonth(year, month))
            {
                throw new ArgumentOutOfRangeException("day", "ArgumentOutOfRange_Range");
            }
            return this.IsLeapYear(year) && (month == 2 && day == 29);
        }
        /// <summary>Calculates the leap month for a specified year and era.</summary>
        /// <returns>The return value is always 0 because the <see cref="T:System.Globalization.GregorianCalendar" /> type does not support the notion of a leap month.</returns>
        /// <param name="year">A year.</param>
        /// <param name="era">An era. Specify either <see cref="F:System.Globalization.GregorianCalendar.ADEra" /> or <see cref="F:System.Globalization.Calendar.CurrentEra" />.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="year" /> is less than the Gregorian calendar year 1 or greater than the Gregorian calendar year 9999.-or-<paramref name="era" /> is not <see cref="F:System.Globalization.GregorianCalendar.ADEra" /> or <see cref="F:System.Globalization.Calendar.CurrentEra" />.</exception>
        [ComVisible(false)]
        public override int GetLeapMonth(int year, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
                {
                1,
                9999
                }));
            }
            return 0;
        }
        /// <summary>Determines whether the specified month in the specified year in the specified era is a leap month.</summary>
        /// <returns>This method always returns false, unless overridden by a derived class.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="month">An integer from 1 to 12 that represents the month. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar.-or- <paramref name="month" /> is outside the range supported by the calendar. </exception>
        public override bool IsLeapMonth(int year, int month, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
                {
                1,
                9999
                }));
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("month", "ArgumentOutOfRange_Range");
            }
            return false;
        }
        /// <summary>Determines whether the specified year in the specified era is a leap year.</summary>
        /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar. </exception>
        public override bool IsLeapYear(int year, int era)
        {
            if (era != 0 && era != 1)
            {
                throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
            }
            if (year >= 1 && year <= 9999)
            {
                return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
            }
            throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
            {
            1,
            9999
            }));
        }
        /// <summary>Returns a <see cref="T:System.DateTime" /> that is set to the specified date and time in the specified era.</summary>
        /// <returns>The <see cref="T:System.DateTime" /> that is set to the specified date and time in the current era.</returns>
        /// <param name="year">An integer that represents the year. </param>
        /// <param name="month">An integer from 1 to 12 that represents the month. </param>
        /// <param name="day">An integer from 1 to 31 that represents the day. </param>
        /// <param name="hour">An integer from 0 to 23 that represents the hour. </param>
        /// <param name="minute">An integer from 0 to 59 that represents the minute. </param>
        /// <param name="second">An integer from 0 to 59 that represents the second. </param>
        /// <param name="millisecond">An integer from 0 to 999 that represents the millisecond. </param>
        /// <param name="era">An integer that represents the era. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="era" /> is outside the range supported by the calendar.-or- <paramref name="year" /> is outside the range supported by the calendar.-or- <paramref name="month" /> is outside the range supported by the calendar.-or- <paramref name="day" /> is outside the range supported by the calendar.-or- <paramref name="hour" /> is less than zero or greater than 23.-or- <paramref name="minute" /> is less than zero or greater than 59.-or- <paramref name="second" /> is less than zero or greater than 59.-or- <paramref name="millisecond" /> is less than zero or greater than 999. </exception>
        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
        {
            if (era == 0 || era == 1)
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            throw new ArgumentOutOfRangeException("era", "ArgumentOutOfRange_InvalidEraValue");
        }
        /// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.GregorianCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
        /// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
        /// <param name="year">A two-digit or four-digit integer that represents the year to convert. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="year" /> is outside the range supported by the calendar. </exception>
        public override int ToFourDigitYear(int year)
        {
            if (year < 0)
            {
                throw new ArgumentOutOfRangeException("year", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if (year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, "ArgumentOutOfRange_Range", new object[]
                {
                1,
                9999
                }));
            }
            return base.ToFourDigitYear(year);
        }
    }



}

//public static List<double> mas_len = new List<double> { 0, 30.92569444, 62.63289352, 94.00184028, 125.4761458, 156.4885417, 186.9247338, 216.8066667, 246.3155787, 275.6427546, 305.0935301, 334.9103588, 365.2587564814815 };
//public static List<string> mn = new List<string> {"January", "February", "March", "April", "May", "June", "July",
//          "August", "September", "October", "November", "December" };

//public static string convertToBanglaDate(int year, int month, int day)
//{
//    var english_number = "" + Bangla_Date(year, month, day + 1); // 1 is added for bangladeshi calender 

//    var bangla_converted_number = EnglishNumberToBangla(english_number);

//    return bangla_converted_number;
//}

//public double calData(int jd)
//{

//    double z1 = jd + 0.5;
//    double z2 = Math.Floor(z1);
//    double f = z1 - z2;
//    if (z2 < 2299161) a = z2;
//    else
//    {
//        alf = floor((z2 - 1867216.25) / 36524.25);
//        a = z2 + 1 + alf - floor(alf / 4);
//    }
//    b = a + 1524;
//    c = floor((b - 122.1) / 365.25);
//    d = floor(365.25 * c);
//    e = floor((b - d) / 30.6001);
//    bc_days = b - d - floor(30.6001 * e) + f;
//    kday = floor(bc_days);
//    if (e < 13.5) kmon = e - 1;
//    else kmon = e - 13;
//    if (kmon > 2.5) kyear = c - 4716;
//    if (kmon < 2.5) kyear = c - 4715;
//    hh1 = (bc_days - kday) * 24;
//    khr = floor(hh1);
//    kmin = hh1 - khr;
//    ksek = kmin * 60;
//    kmin = floor(ksek);
//    ksek = floor((ksek - kmin) * 60);
//    if (kday < 10) kday = " " + kday;
//    if (khr < 10) khr = "0" + khr;
//    if (kmin < 10) kmin = "0" + kmin;
//    if (ksek < 10) ksek = "0" + ksek;
//    var dstr = mn[kmon - 1] + " " + kday + ", " + kyear + " " + khr + ":" + kmin + ":00";
//    //var sDate = new Date(Date.parse("03/20/2012", "MM/dd/yyyy"));
//    s = new Date(dstr);

//}
//            return s;
//        }

//        private static string Bangla_Date(int year, int month, int v)
//{
//    double lastday;


//    string country = "India";

//    var str = "";
//    var startjd = 0.0;
//    if (country == "India")
//    {
//        startjd = 1938094.4629; //India
//    }
//    else
//    {
//        startjd = 1938094.483733333;
//    }
//    double nJD = ModernDate_to_Julianeday(year, month, v);
//    if (nJD < startjd)
//    {
//        str = " Date is not appropriate.\n";
//    }
//    else
//    {
//        var jddiff = nJD - startjd;
//        var lasteyear = Math.Floor(jddiff / 365.2587564814815);
//        var mesh = startjd + lasteyear * 365.2587564814815;
//        var lasteday = 0.0;
//        double ps, ns, bebc_month, beday;
//        for (var i = 0; i < 12; i++)
//        {
//            ps = mesh + mas_len[i];
//            ns = mesh + mas_len[i + 1];
//            if ((nJD >= ps) && (nJD <= Math.Floor(ns) + 1.75))
//            {
//                bebc_month = i + 1;
//                beday = Math.Floor(nJD - ps) + 1;
//                //bbc_month_len =Math.floor(ns) + 0.5;
//            }

//        }
//        // Array array = new Array();
//        for (var i = 0; i < 12; i++)
//        {
//            lastday = mesh + mas_len[i];
//            var nda = new Date(calData(lastday + 1).toDateString());
//            //       array.Push((nda.getMonth() + 1) + "/" + nda.getDate() + "/" + nda.getFullYear());
//        }
//        //    bbc_month_len = array.join(",");

//        //var bar = Math.floor(nJD + 0.5) % 7 + 1;
//        //str = convert(beday) + " " + beng_bc_month_name[bebc_month] + " " + 
//        //convert(lasteyear + 1) + " বঙ্গাব্দ, " + Weekebc_days[bar] + "বার।";

//    }
//    //return str;
//    return lasteyear + 1 + "," + bebc_month + "," + beday;


//}

//private static double ModernDate_to_Julianeday(int eyear, int ebc_month, int eday)
//{
//    double julian_eday;

//    if (ebc_month < 3)
//    {
//        eyear = eyear - 1;
//        ebc_month = ebc_month + 12;
//    }

//    julian_eday = Math.Floor((365.25 * eyear)) + Math.Floor(30.59 * (ebc_month - 2)) + eday + 1721086.5;
//    if (eyear < 0)
//    {
//        julian_eday = julian_eday - 1;
//        if (((eyear % 4) == 0) && (3 <= ebc_month))
//        {
//            julian_eday = julian_eday + 1;
//        }
//    }
//    if (2299160 < julian_eday)
//    {
//        julian_eday = julian_eday + Math.Floor(eyear * 1.0 / 400) - Math.Floor(eyear * 1.0 / 100) + 2;
//    }

//    return julian_eday;

//}
