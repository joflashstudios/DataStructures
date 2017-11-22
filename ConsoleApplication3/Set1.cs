using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Set1<T> : ISet<T>
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;
        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                return true;
            }
            return false;
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

        public void ExceptWith(IEnumerable<T> other)
        {
            foreach(T item in other)
            {
                Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        void ICollection<T>.Add(T item)
        {
            items.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        #region set methods I don't care about
        public void IntersectWith(IEnumerable<T> other)
        {
            var newList = new List<T>();
            foreach (var item in this)
            {
                if (other.Contains(item))
                {
                    newList.Add(item);
                }
            }
            items = newList;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
