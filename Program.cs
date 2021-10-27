using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace IbanValidacion
{
    class Program
    {
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			if (IBAN(input) == true)
			{
				Console.WriteLine("This IBAN is valid");
			}
			else
			{
				Console.WriteLine("This IBAN is invalid");
			}



		}

		static bool IBAN(string input)
		{
			string pattern = @"^[A-Z]{2}[A-Z0-9]{20}$";
			Match mat = Regex.Match(input, pattern);
			string all = input.Substring(4) + input.Substring(0, 4);

			StringBuilder sb = new StringBuilder();



			if (mat.Success)
			{

				foreach (char sym in all)
				{
					if (char.IsDigit(sym))
					{
						sb.Append(sym);
					}
					else
					{
						sb.Append(sym - 'A' + 10);
					}
				}
				all = input.Substring(4) + input.Substring(0, 2) + "00";
				Console.WriteLine(all);
				if (BigInteger.Parse(sb.ToString()) % 97 == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}




		}
	}
}
