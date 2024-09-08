using RomanNumerals;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        string a  = RomanNumeral.Subtraction("XXX", "XX");
        Console.WriteLine(a);
    }
}