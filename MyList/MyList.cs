using System;
using System.Collections;
using System.Collections.Generic;


namespace MyList
{
   public class MyList<T> : IEnumerator<T>, IEnumerable<T>
   {
      private const int initialCapacity = 10;

      private T[] list = new T[initialCapacity];
      private int index = -1;


      public int Count { get; private set; }
      public int Capacity
      {
         get
         {
            return list.Length;
         }

      }
      public T Current
      {
         get
         {
            if (index < 0 || Count <= index)
            {
               return default(T);
            }

            return list[index];
         }
      }

      object IEnumerator.Current
      {
         get
         {
            return Current;
         }
      }

      public T this[int index]
      {
         get
         {
            CheckIndex(index);

            return list[index];
         }

         set { list[index] = value; }
      }

      public MyList()
      {

      }

      public MyList(int capacity)
      {
         list = new T[capacity];
      }

      private void CheckIndex(int index)
      {
         if (index >= Count || index < 0)
         {
            throw new IndexOutOfRangeException(
               "Current index doesn't exist");
         }
      }

      public void Add(T data)
      {
         ResizeOrNotResize();
         list[Count++] = data;
      }

      public void Insert(int index, T data)
      {
         ResizeOrNotResize();
         Array.Copy(list, index, list, index + 1, Count - index);
         list[index] = data;
         Count++;
      }
      private void ResizeOrNotResize()
      {
         if (Count == list.Length)
         {
            Array.Resize(ref list, list.Length * 2);
         }
      }
      public void RemoveAt(int index)
      {
         if (ContainIndex(index))
         {
            Array.Copy(list, index + 1,
                    list, index, Count - (index - 1));
            Count--;
         }
         else
         {
            Console.WriteLine("Current index doesn't exist");
         }
         
      }

      private bool ContainIndex(int index)
      {
         for (int i = 0; i < Count; i++)
         {
            if (i == index)
            {
               return true;
            }
         }

         return false;
      }

      public bool Contains(T data)
      {
         for (int i = 0; i < Count; i++)
         {
            if (list[i].Equals(data))
            {
               return true;
            }
         }

         return false;
      }

      public T[] ToArray()
      {
         if (ListIsNotEmpty())
         {
            T[] ret = new T[Count];
            Array.Copy(list, ret, Count);
            return ret;
         }
         throw new InvalidOperationException();
      }

      public int IndexOf(T data)
      {
         for (int i = 0; i < Count; i++)
         {
            if (list[i].Equals(data))
            {
               return i;
            }
         }

         return -1;
      }

      public void Reverse()
      {
         if (ListIsNotEmpty())
         {
            for (int i = 0; i < Count / 2; i++)
            {
               T temporary = list[i];
               list[i] = list[Count - i - 1];
               list[Count - i - 1] = temporary;
            }
         }

         else
         {
            throw new InvalidOperationException("List is Empty");
         }
      }

      private bool ListIsNotEmpty()
      {
         return Count != 0;
      }

      public void Clear()
      {
         Count = 0;
         for (int i = 0; i < Count; i++)
         {
            list[i] = default(T);
         }
      }



      public bool MoveNext()
      {
         index++;
         return index < Count;
      }

      public void Dispose()
      {
         Console.WriteLine("I am disposing");
      }

      public void Reset() => index = -1;

      public IEnumerator<T> GetEnumerator()
      {
         for (int i = 0; i < Count; i++)
         {
            yield return list[i];
         }
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}
