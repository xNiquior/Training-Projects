using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Date_Class
{
    public readonly struct DateAndWeekday : IEqualityOperators<DateAndWeekday, DateAndWeekday, bool>, IComparisonOperators<DateAndWeekday, DateAndWeekday, bool>, IAdditionOperators<DateAndWeekday, int, DateAndWeekday>, ISubtractionOperators<DateAndWeekday, DateAndWeekday, int>, IEquatable<DateAndWeekday>, IIncrementOperators<DateAndWeekday>, IDecrementOperators<DateAndWeekday>
    {
        private const int FIRST_HANDLABLE_YEAR = 1900;
        private const int DAYS_IN_LEAP_YEAR = 366;
        private const int DAYS_IN_NONLEAP_YEAR = 365;
        
        private static int[] s_daysInEachMonth = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];

        private readonly int _day;
        private readonly int _month;
        private readonly int _year;
        

        public DateAndWeekday(int day, int month, int year)
        {
            if (IsDateInProperFormat(day, month, year) || DateToNumber(day, month, year) > 0)
            {
                throw new ArgumentException("The date format is incorrect.");
            }
            
            NormalizeDate(ref day, ref month, ref year);

            _day = day;
            _month = month;
            _year = year;
        }
        public DateAndWeekday(in string? date)
            : this(int.Parse(date?.Split(".")[0]), int.Parse(date.Split(".")[1]), int.Parse(date.Split(".")[2])) { }
        public DateAndWeekday(in int dayNumber)
        {
            if (!TryConvertNumberToDate(dayNumber, out int day, out int month, out int year))
            {
                throw new ArgumentException("The date format is incorrect.");
            }

            _day = day;
            _month = month;
            _year = year;
        }


        public enum MonthName
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December,
        }
        public enum WeekDayName
        {
            Sunday = 0,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
        }


        public int Day { get => _day; }
        public int Month { get => _month; }
        public int Year { get => _year; }
        public string Weekday { get => Convert.ToString((WeekDayName)(DateToNumber(this) % 7)) ?? ""; }
        public string Date { get => $"{Weekday}, the {Day} of {(MonthName)Month} {Year}"; }

        public static bool operator ==(DateAndWeekday left, DateAndWeekday right)
            => left.Equals(right);
        public static bool operator !=(DateAndWeekday left, DateAndWeekday right)
            => !(left == right);
        public static bool operator >(DateAndWeekday left, DateAndWeekday right)
            => DateToNumber(left) > DateToNumber(right);
        public static bool operator >=(DateAndWeekday left, DateAndWeekday right)
            => DateToNumber(left) >= DateToNumber(right);
        public static bool operator <(DateAndWeekday left, DateAndWeekday right)
            => DateToNumber(left) < DateToNumber(right);
        public static bool operator <=(DateAndWeekday left, DateAndWeekday right)
            => DateToNumber(left) <= DateToNumber(right);
        public static DateAndWeekday operator +(DateAndWeekday left, int right)
            => new DateAndWeekday(DateToNumber(left) + right);
        public static int operator -(DateAndWeekday left, DateAndWeekday right)
            => DateToNumber(left) - DateToNumber(right);
        public static DateAndWeekday operator ++(DateAndWeekday value)
            => new DateAndWeekday(DateToNumber(value) + 1);
        public static DateAndWeekday operator --(DateAndWeekday value)
            => new DateAndWeekday(DateToNumber(value) - 1);

        public static explicit operator DateAndWeekday(int value)
            => ConvertNumberToDate(value);
        public static explicit operator int(DateAndWeekday value)
            => DateToNumber(value);
        public static implicit operator string(DateAndWeekday value)
            => value.Date;

        public bool Equals(DateAndWeekday other)
            => DateToNumber(this) == DateToNumber(other);
        public override bool Equals([NotNullWhen(true)] object? obj)
            => obj is DateAndWeekday && Equals((DateAndWeekday)obj);
        public override int GetHashCode()
            => DateToNumber(this);
        
        public static bool IsYearLeap(in int year)
            => (year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0);
        public static int DaysInYear(in int year)
        {
            if (IsYearLeap(year))
            {
                return DAYS_IN_LEAP_YEAR;
            }

            return DAYS_IN_NONLEAP_YEAR;
        }
        public static int DaysInMonth(in int month, in int year)
        {
            int result = s_daysInEachMonth[month - 1];

            if (month == 2 && IsYearLeap(year))
            {
                return result + 1;
            }

            return result;
        }

        public void Print()
            => Console.WriteLine(Date);
        public DateAndWeekday NextDay()
            => new DateAndWeekday(Day + 1, Month, Year);
        public DateAndWeekday PreviousDay()
            => new DateAndWeekday(Day - 1, Month, Year);

        private static void NormalizeDays(ref int day, ref int month, ref int year)
        {
            while (day > DaysInMonth(month, year))
            {
                day -= DaysInMonth(month, year);
                month++;
            }

            while (day < 1)
            {
                month--;
                day += DaysInMonth(month, year);
            }
                
        }
        private static void NormalizeMonths(ref int month, ref int year)
        {
            if (month > 12)
            {
                year += month / 12;
                month = (month % 12 == 0) ? 12 : month % 12;
            }

            while (month < 1)
            {
                year--;
                month += 12;
            }
        }
        private static void NormalizeDate(ref int day, ref int month, ref int year)
        {
            NormalizeMonths(ref month, ref year);

            NormalizeDays(ref day, ref month, ref year);

            NormalizeMonths(ref month, ref year);
        }

        private static bool IsDateInProperFormat(in int day, in int month, in int year)
            => day < 1 || month < 1 || year < FIRST_HANDLABLE_YEAR;
        private static int CountLeapYears(in int yearBegin, in int yearEnd)
        {
            if (yearBegin >= yearEnd)
            {
                return 0;
            }

            int counter = (yearEnd - yearBegin) / 4;
            int remainedYears = (yearEnd - yearBegin) % 4;

            for (; remainedYears > 0; remainedYears--)
            {
                if (IsYearLeap(yearEnd - remainedYears + 1))
                {
                    counter++;
                    break;
                }
            }

            return counter;
        }
        private static int DateToNumber(in int day, in int month, in int year)
        {
            int result = (year - FIRST_HANDLABLE_YEAR) * DAYS_IN_NONLEAP_YEAR  + CountLeapYears(FIRST_HANDLABLE_YEAR, year) + day;

            for (int i = 1; i < month; i++)
            {
                result += DaysInMonth(i, year);
            }

            return result;
        }
        private static int DateToNumber(DateAndWeekday date)
            => DateToNumber(date.Day, date.Month, date.Year);
        private static DateAndWeekday ConvertNumberToDate(in int dayNumber)
        {
            int day = dayNumber;
            int month = 1;
            int year = FIRST_HANDLABLE_YEAR;

            while (day > DaysInYear(year))
            {
                day -= DaysInYear(year);
                year++;
            }
            while (day > DaysInMonth(month, year))
            {
                day -= DaysInMonth(month, year);
                month++;
            }

            return new DateAndWeekday(day, month, year);
        }
        private static bool TryConvertNumberToDate(in int dayNumber, out int day, out int month, out int year)
        {
            day = dayNumber;
            month = 1;
            year = FIRST_HANDLABLE_YEAR;

            if (dayNumber < 1)
            {
                return false;
            }

            while (day > DaysInYear(year))
            {
                day -= DaysInYear(year);
                year++;
            }
            while (day > DaysInMonth(month, year))
            {
                day -= DaysInMonth(month, year);
                month++;
            }

            return true;
        }
    }
}
