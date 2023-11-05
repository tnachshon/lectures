using System;
using System.Collections.Generic;
using System.Linq;

public class LinqExamples
{
	private string[] _countries { get; } = {
		"USA", "Canada", "UK", "Germany", "France", "Japan", "Australia", "India", "Brazil", "China"
	};

	private int[] _numbers { get; } = {
		42, 13, 7, 25, 91, 10, 56, 33, 79, 5
	};

	public void SelectExample()
	{
		// Use Select to project each country to its length.
		var countryLengths = _countries.Select(country => country.Length);
		Console.WriteLine("Country Lengths:");
		foreach (var length in countryLengths)
		{
			Console.WriteLine(length);
		}
	}

	public void WhereExample()
	{
		// Use Where to filter countries with a length greater than 5.
		var longCountries = _countries.Where(country => country.Length > 5);
		Console.WriteLine("Countries with Length > 5:");
		foreach (var country in longCountries)
		{
			Console.WriteLine(country);
		}
	}

	public void GroupByExample()
	{
		// Use GroupBy to group countries by their first letter.
		var groupedCountries = _countries.GroupBy(country => country[0]);
		Console.WriteLine("Countries Grouped by First Letter:");
		foreach (var group in groupedCountries)
		{
			Console.WriteLine($"Starting with '{group.Key}': {string.Join(", ", group)}");
		}
	}

	public void OrderByExample()
	{
		// Use OrderBy to sort random numbers in ascending order.
		var sortedNumbers = _numbers.OrderBy(number => number);
		Console.WriteLine("Sorted Numbers (Ascending):");
		foreach (var number in sortedNumbers)
		{
			Console.WriteLine(number);
		}
	}


	public void AnyExample()
	{
		// Use Any to check if any country starts with 'U'.
		bool anyStartsWithU = _countries.Any(country => country.StartsWith("U"));
		Console.WriteLine($"Any country starts with 'U': {anyStartsWithU}");
	}

	public void FirstExample()
	{
		// Use First to get the first country with a length of 3.
		string firstCountryWithLength3 = _countries.First(country => country.Length == 3);
		Console.WriteLine($"First country with length 3: {firstCountryWithLength3}");
	}

	public void LastExample()
	{
		// Use Last to get the last number that is less than 20.
		int lastNumberLessThan20 = _numbers.Last(number => number < 20);
		Console.WriteLine($"Last number less than 20: {lastNumberLessThan20}");
	}

}
