using System;

namespace Code.Samples
{
	public class DebuggingExamples
	{
		public int Sum(int a, int b)
		{
			int result = a + b;
			return result;
		}

		public int Divide(int dividend, int divisor)
		{
			if (divisor == 0)
			{
				Console.WriteLine("Division by zero is not allowed.");
				return 0;
			}

			int quotient = dividend / divisor;
			return quotient;
		}

		
	}

}
