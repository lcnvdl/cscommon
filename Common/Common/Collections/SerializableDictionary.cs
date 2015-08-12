using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Collections
{
	/// <summary>
	/// Serializable dictionary
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	[Serializable]
	public class SerializableDictionary<TKey, TValue>: IDictionary<TKey, TValue>
	{
		private List<KeyValuePair<TKey, TValue>> values; 

		public SerializableDictionary()
		{
			values = new List<KeyValuePair<TKey, TValue>>();
		}

		public void Add(TKey key, TValue value)
		{
			Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		public bool ContainsKey(TKey key)
		{
			return values.Any(m => key.Equals(m.Key));
		}

		public ICollection<TKey> Keys
		{
			get { return values.Select(m=>m.Key).ToList(); }
		}

		public bool Remove(TKey key)
		{
			return values.RemoveAll(m => key.Equals(m.Key)) > 0;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (ContainsKey(key))
			{
				value = this[key];
				return true;
			}
			else
			{
				value = default(TValue);
				return false;
			}
		}

		public ICollection<TValue> Values
		{
			get { throw new NotImplementedException(); }
		}

		public TValue this[TKey key]
		{
			get { return values.FirstOrDefault(m => m.Key.Equals(key)).Value; }
			set { Add(new KeyValuePair<TKey, TValue>(key, value)); }
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			if (ContainsKey(item.Key))
			{
				Remove(item.Key);
			}

			values.Add(item);
		}

		public void Clear()
		{
			values.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ContainsKey(item.Key);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			values.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return values.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return values.GetEnumerator();
		}
	}
}
