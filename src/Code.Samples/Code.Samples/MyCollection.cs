using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class MyCollection<T> : IEnumerable<T>, IList<T>, IDisposable
	{
		private List<T> items = new List<T>();

		// Implement IEnumerable<T> with the 'yield' keyword
		public IEnumerator<T> GetEnumerator()
		{
			foreach (T item in items)
			{
				yield return item;
			}
		}

		// Implement IEnumerable with the non-generic version
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		// Implement IList<T> members
		public T this[int index]
		{
			get => items[index];
			set => items[index] = value;
		}

		public int Count => items.Count;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			items.Add(item);
		}

		public void Clear()
		{
			items.Clear();
		}

		public bool Contains(T item)
		{
			return items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public int IndexOf(T item)
		{
			return items.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			items.Insert(index, item);
		}

		public bool Remove(T item)
		{
			return items.Remove(item);
		}

		public void RemoveAt(int index)
		{
			items.RemoveAt(index);
		}

		// Implement IDisposable
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// Release managed resources
					items.Clear();
				}

				// Release unmanaged resources (if any)

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~MyCollection()
		{
			Dispose(false);
		}

		public void PrintCollection()
		{
			foreach (T item in this)
			{
				Console.WriteLine(item);
			}
		}

	}

}
