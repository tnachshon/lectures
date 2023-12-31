﻿using System;

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

		public int OuterFunc(int a, int b)
		{
			var innerResult = InnerFunc(a, b);
			var rand = new Random(DateTime.Now.Millisecond).Next(10, 50);
			var res = innerResult * rand;
			return res;
		}

		private int InnerFunc(int a, int b)
		{
			var c = 8;
			return a + b + c;
		}


	}

}
