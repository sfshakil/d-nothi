using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using Autofac;
using dNothi.Infrastructure;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.AccountServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser;
using dNothi.Services.SyncServices;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using dNothi.JsonParser.Entity.Dak;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Linq;

namespace dNothi.Syncer
{
    class Program
    {
        private static IContainer container;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static async Task Main(string[] args)
        {


            var thisDate = DateTime.Now;
            BengaliCalendar bCal = new BengaliCalendar();

           string Month= GetBengaliMonthFromEnglishMonthNo(bCal.GetMonth(thisDate));
           string Day= EnglishNumberToBangla(bCal.GetDayOfMonth(thisDate).ToString());
           string Year= EnglishNumberToBangla(bCal.GetYear(thisDate).ToString());

            // Console.WriteLine("Today in the Gregorian Calendar:  {0:dddd}, {0}", thisDate);
            Console.WriteLine("Today in the Persian Calendar:" + Day + "," + Month + "," + Year);

            Console.ReadKey();

        }
        private static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<AppDbContext>().As<IDbContext>();
            builder.RegisterType<EfRepository<AppUser>>().As<IRepository<AppUser>>();
            builder.RegisterType<EfRepository<User>>().As<IRepository<User>>();


            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakTag>>().As<IRepository<dNothi.Core.Entities.DakTag>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.LocalUploadedDak>>().As<IRepository<dNothi.Core.Entities.LocalUploadedDak>>();

            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakType>>().As<IRepository<dNothi.Core.Entities.DakType>>();

            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakList>>().As<IRepository<dNothi.Core.Entities.DakList>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakItem>>().As<IRepository<dNothi.Core.Entities.DakItem>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakItemDetails>>().As<IRepository<dNothi.Core.Entities.DakItemDetails>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Officer>>().As<IRepository<dNothi.Core.Entities.Officer>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakAttachment>>().As<IRepository<dNothi.Core.Entities.DakAttachment>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.To>>().As<IRepository<dNothi.Core.Entities.To>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.Other>>().As<IRepository<dNothi.Core.Entities.Other>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.MovementStatus>>().As<IRepository<dNothi.Core.Entities.MovementStatus>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakNothi>>().As<IRepository<dNothi.Core.Entities.DakNothi>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakUser>>().As<IRepository<dNothi.Core.Entities.DakUser>>();
            builder.RegisterType<EfRepository<dNothi.Core.Entities.DakOrigin>>().As<IRepository<dNothi.Core.Entities.DakOrigin>>();
          
            builder.RegisterType<EfRepository<EmployeeInfo>>().As<IRepository<EmployeeInfo>>();
            builder.RegisterType<EfRepository<OfficeInfo>>().As<IRepository<OfficeInfo>>();
            builder.RegisterType<EfRepository<SyncStatus>>().As<IRepository<SyncStatus>>();
            builder.RegisterType<EfRepository<UserToken>>().As<IRepository<UserToken>>();
            builder.RegisterType<EfRepository<NothiListRecords>>().As<IRepository<NothiListRecords>>();

            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DakInboxService>().As<IDakInboxServices>();
            builder.RegisterType<DakOutboxService>().As<IDakOutboxService>();
            builder.RegisterType<DakListService>().As<IDakListService>();
            builder.RegisterType<DakNothijatoService>().As<IDakNothijatoService>();
            builder.RegisterType<DakNothivuktoService>().As<IDakNothivuktoService>();
            builder.RegisterType<DakArchiveService>().As<IDakArchiveService>();
            builder.RegisterType<NothiInboxService>().As<INothiInboxServices>();
            builder.RegisterType<NothiOutboxService>().As<INothiOutboxServices>();
            builder.RegisterType<NothiAllService>().As<INothiAllServices>();
            builder.RegisterType<NothiTypeListService>().As<INothiTypeListServices>();
            builder.RegisterType<UserMessageParser>().As<IUserMessageParser>();
            builder.RegisterType<SyncerService>().As<ISyncerService>();
            builder.RegisterType<DakListService>().As<IDakListService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DakUploadService>().As<IDakUploadService>();

            container = (builder.Build());
            return container;
        }

        public static string GetBengaliDayFromEnglishDay(string EnglishDay)
        {
            if (EnglishDay == "Saturday")
            {
                return "শনিবার";
            }
            else if (EnglishDay == "Sunday")
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
            else if (MonthNo == 7)
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
            else if (MonthNo == 11)
            {
                return "ফাল্গুন";
            }
            else
            {
                return "চৈত্র";
            }

        }

        public static string EnglishNumberToBangla(string Num)
        {
            return string.Concat(Num.ToString().Select(c => (char)('\u09E6' + c - '0')));
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


}
