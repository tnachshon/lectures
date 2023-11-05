using System;
using System.Threading.Tasks;

namespace Code.Samples
{
	
	public class TaskExamples
	{
		public void SynchronousMethod()
		{
			Console.WriteLine("SynchronousMethod: Start");
			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"SynchronousMethod: Step {i}");
				Task.Delay(1000).Wait(); // Simulate work with synchronous delay
			}
			Console.WriteLine("SynchronousMethod: End");
		}

		public async Task AsynchronousMethod()
		{
			Console.WriteLine("AsynchronousMethod: Start");
			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"AsynchronousMethod: Step {i}");
				await Task.Delay(1000); // Simulate asynchronous work with await
			}
			Console.WriteLine("AsynchronousMethod: End");
		}

	}

}
