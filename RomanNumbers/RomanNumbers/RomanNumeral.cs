using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    /// <summary>
    /// Представляет собой римское число от 0 до 3999.
    /// </summary>
    public readonly struct RomanNumeral
    {
        /// <summary>
        /// Представляет собой наибольшее возможное численное значение типа RomanNumeral. Это поле
        /// является константой.
        /// </summary>
        public const int MaxValue = 3999;
        /// <summary>
        /// Представляет собой наименьшее возможное численное значение типа RomanNumeral. Это поле
        /// является константой.
        /// </summary>
        public const int MinValue = 0;

        /// <summary>
        /// Десятичное численное значение типа RomanNumeral. Это поле только для чтения.
        /// </summary>
        public readonly int Value;
        /// <summary>
        /// Строковое представление римского числа. Это поле только для чтения.
        /// </summary>
        public readonly string Romanized;

        /// <summary>
        /// Римский ноль - "Nulla". Это поле является константой.
        /// </summary>
        public const string RomanZero = "N";

        private static Dictionary<string, int> RomanSymbols = new()
        {
            { "MM", 2000 },
            { "M", 1000 },
            { "CM", 900},
            { "D", 500},
            { "CD", 400},
            { "CC", 200 },
            { "C", 100},
            { "XC", 90},
            { "L", 50},
            { "XL", 40},
            { "XX", 20 },
            { "X", 10},
            { "IX", 9},
            { "V", 5},
            { "IV", 4},
            { "II", 2 },
            { "I", 1},
        };


        public RomanNumeral(int value)
        {
            Value = value;
            Romanized = Romanize(value);
        }
        public RomanNumeral(string value)
        {
            if (IsRomanNumberDesignationCorrect(value))
            {
                Value = Deromanize(value);
                Romanized = value;
            }
            else
            {
                throw new ArgumentException("Неверный ввод");
            }
        }


        /// <summary>
        /// Реализация неявного преобразования числа из типа int в тип RomanNumeral.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator RomanNumeral(int value)
            => new RomanNumeral(value);

        /// <summary>
        /// Реализация неявного преобразования строки типа string в число типа RomanNumeral.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator RomanNumeral(string value)
            => new RomanNumeral(value);

        /// <summary>
        /// Реализация явного преобразования числа из типа RomanNumeral в тип string.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator string(RomanNumeral value)
            => value.Romanized;

        /// <summary>
        /// Реализация явного преобразования числа из типа RomanNumeral в тип int.
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator int(RomanNumeral value)
            => value.Value;


        public static RomanNumeral operator +(RomanNumeral left, RomanNumeral right)
        {
            if (left.Value + right.Value > 3999)
            {
                throw new OverflowException("Сумма вне диапазона");
            }

            return new RomanNumeral(left.Value + right.Value);
        }
        public static RomanNumeral operator -(RomanNumeral left, RomanNumeral right)
        {
            if (left.Value < right.Value)
            {
                throw new OverflowException("Разность вне диапазона!");
            }

            return new RomanNumeral(left.Value - right.Value);
        }
        public static RomanNumeral operator *(RomanNumeral left, RomanNumeral right)
        {
            if (left.Value * right.Value > 3999)
            {
                throw new OverflowException("Произведение вне диапазона!");
            }

            return new RomanNumeral(left.Value * right.Value);
        }
        public static RomanNumeral operator /(RomanNumeral left, RomanNumeral right)
        {
            if (left.Value < right.Value)
            {
                throw new OverflowException("Частное вне диапазона!");
            }
            if (right.Value == 0)
            {
                throw new DivideByZeroException("На ноль делить нельзя!");
            }

            return new RomanNumeral(left.Value / right.Value);
        }
        public static RomanNumeral operator %(RomanNumeral left, RomanNumeral right)
        {
            if (right.Value == 0)
            {
                throw new DivideByZeroException("На ноль делить нельзя!");
            }
            return new RomanNumeral(left.Value % right.Value);
        }


        /// <summary>
        /// Складывает два римских числа.
        /// </summary>
        /// <param name="summand1">Первое слагаемое.</param>
        /// <param name="summand2">Второе слагаемое.</param>
        /// <returns>Сумма.</returns>
        public static RomanNumeral Addition(RomanNumeral summand1, RomanNumeral summand2)
            => summand1 + summand2;

        /// <summary>
        /// Вычитает из первого римского числа второе.
        /// </summary>
        /// <param name="minuend">Вычитатель.</param>
        /// <param name="subtrahend">Вычитаемое.</param>
        /// <returns>Разность.</returns>
        public static RomanNumeral Subtraction(RomanNumeral minuend, RomanNumeral subtrahend)
            => minuend - subtrahend;

        /// <summary>
        /// Перемножает два римских числа.
        /// </summary>
        /// <param name="multiplicanda">Множимое (Первый множитель).</param>
        /// <param name="multiplier">Множитель (Второй множитель).</param>
        /// <returns>Произведение.</returns>
        public static RomanNumeral Multiplication(RomanNumeral multiplicanda, RomanNumeral multiplier)
            => multiplicanda * multiplier;

        /// <summary>
        /// Нацело делит первое римское число на второе.
        /// </summary>
        /// <param name="dividend">Делимое.</param>
        /// <param name="divisor">Делитель.</param>
        /// <returns>Целочисленное частное.</returns>
        public static RomanNumeral IntegerDivision(RomanNumeral dividend, RomanNumeral divisor)
            => dividend / divisor;

        /// <summary>
        /// Возвращает остаток от деления двух римских чисел.
        /// </summary>
        /// <param name="dividend">Делимое.</param>
        /// <param name="divisor">Делитель.</param>
        /// <returns>Остаток.</returns>
        public static RomanNumeral Remainder(RomanNumeral dividend, RomanNumeral divisor)
            => dividend % divisor;


        /// <summary>
        /// Проверяет, является ли входная строка с записью римского числа верной.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>
        /// Значение <c>true</c>, если <paramref name="input"/> является верной записью;
        /// в противном случае — значение <c>false</c>.
        /// </returns>
        public static bool IsRomanNumberDesignationCorrect(string? input)
        {
            if (input == null || input.Length == 0)
            {
                return false;
            }

            if (input == "N")
            {
                return true;
            }

            var usedSymbols = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Length - i > 1 && RomanSymbols.TryGetValue(Convert.ToString(input[i]) + Convert.ToString(input[i + 1]), out int _))
                {
                    usedSymbols.Add(Convert.ToString(input[i]) + Convert.ToString(input[i + 1]));

                    i++;
                    continue;
                }
                else if (RomanSymbols.TryGetValue(Convert.ToString(input[i]), out _))
                {
                    usedSymbols.Add(Convert.ToString(input[i]));

                    continue;
                }

                return false;
            }

            if (input.Length > 1)
            {
                for (int i = 0; i < usedSymbols.Count() - 1; i++)
                {
                    if (RomanSymbols[usedSymbols[i]] <= RomanSymbols[usedSymbols[i + 1]])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Преобразует десятичную запись числа в строковое представление римского числа.
        /// </summary>
        /// <param name="value">Входное десятичное число.</param>
        /// <returns>Строка с записью римского числа.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string Romanize(int? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Значение не должно быть пустым!");
            }

            if (value > MaxValue || value < MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Неверный ввод: Число может быть только в диапазоне от 0 до 3999 включительно!");
            }


            char[] result = new char[15];
            int i = 0;
            while (value > 0)
            {
                foreach (var item in RomanSymbols)
                {
                    if (item.Value <= value)
                    {
                        foreach (char symbol in item.Key)
                        {
                            result[i] = symbol;
                            i++;
                        }

                        value -= item.Value;
                    }
                }
            }

            if (result[0] == '\0')
            {
                return RomanZero;
            }

            return new string(result, 0, i);
        }

        /// <summary>
        /// Преобразует строковое представление римского числа в десятичное.
        /// </summary>
        /// <param name="value">Входная строка.</param>
        /// <returns>Десятичное число.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Deromanize(string? value)
        {
            if (IsRomanNumberDesignationCorrect(value))
            {
                if (value == RomanZero)
                {
                    return 0;
                }

                int result = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value.Length - i > 1 && RomanSymbols.ContainsKey(Convert.ToString(value[i]) + Convert.ToString(value[i + 1])))
                    {
                        result += RomanSymbols[Convert.ToString(value[i]) + Convert.ToString(value[i + 1])];
                        
                        i++;
                    }
                    else
                    {
                        result += RomanSymbols[Convert.ToString(value[i])];
                    }

                }

                return result;
            }
            else
            {
                throw new ArgumentException("Неверый ввод");
            }
        }

        /// <summary>
        /// Преобразует строковое представление римского числа в эквивалентное ему 
        /// десятичное число. Возвращает значение, указывающее, успешно ли выполнена операция.
        /// </summary>
        /// <param name="value">Строка, которую надо перевести</param>
        /// <param name="result">При возврате содержит в себе результат успешного перевода
        /// или 0 при сбое. Сбой возможен при неверном формате входной строки.</param>
        /// <returns>
        /// Значение <c>true</c>, если <paramref name="input"/> является верной записью;
        /// в противном случае — значение <c>false</c>.
        /// </returns>
        public static bool TryDeromanize(string? value, out int result)
        {
            if (IsRomanNumberDesignationCorrect(value))
            {
                result = Deromanize(value);
                return true;
            }

            result = 0;
            return false;
        }
    }
}
