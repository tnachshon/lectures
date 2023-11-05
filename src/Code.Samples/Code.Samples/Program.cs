// See https://aka.ms/new-console-template for more information
using Code.Samples;


//LinqSamplesMain();
//DebuggingExampleMain();
//await TaskExamplesMain().ConfigureAwait(false);
MyCollectionMain();

void LinqSamplesMain()
{
	var linqSamples = new LinqExamples();
	linqSamples.SelectExample();
	Console.WriteLine();

	linqSamples.WhereExample();
	Console.WriteLine();

	linqSamples.GroupByExample();
	Console.WriteLine();

	linqSamples.OrderByExample();
	Console.WriteLine();

	linqSamples.AnyExample();
	Console.WriteLine();

	linqSamples.FirstExample();
	Console.WriteLine();

	linqSamples.LastExample();
}

void DebuggingExampleMain()
{
	DebuggingExamples debuggingExample = new DebuggingExamples();

	// Example 1: Debugging a simple Sum function
	int sumResult = debuggingExample.Sum(10, 20);
	Console.WriteLine($"Sum Result: {sumResult}");

	// Example 2: Debugging a function with potential division by zero
	int dividend = 42;
	int divisor = 0;

	int divisionResult = debuggingExample.Divide(dividend, divisor);
	Console.WriteLine($"Division Result: {divisionResult}");
}


async Task TaskExamplesMain()
{
	TaskExamples examples = new TaskExamples();

	Console.WriteLine("Calling SynchronousMethod");
	examples.SynchronousMethod();
	Console.WriteLine("SynchronousMethod returned");

	Console.WriteLine("\nCalling AsynchronousMethod");
	await examples.AsynchronousMethod();
	Console.WriteLine("AsynchronousMethod returned");
}


void MyCollectionMain()
{
	using (MyCollection<string> collection = new MyCollection<string>())
	{
		collection.Add("Item 1");
		collection.Add("Item 2");
		collection.Add("Item 3");

		collection.PrintCollection();
	}
}