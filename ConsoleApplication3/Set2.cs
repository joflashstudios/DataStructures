using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Set2<T> : ISet<T>
    {
        Slot[] buckets = new Slot[50000];
        
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        public bool IsReadOnly => false;
        public int Count { get; private set; } = 0;
        private int InternalGetHashCode(T item)
        {
            if (item == null)
            {
                return 0;
            }
            return comparer.GetHashCode(item) & 2147483647;
        }

        public bool Add(T item)
        {
            var hash = InternalGetHashCode(item);
            var slotIndex = hash % buckets.Length;
            var startSlot = buckets[slotIndex];
            var slot = startSlot;
            if (slot == null)
            {
                buckets[slotIndex] = new Slot { hash = hash, value = item };
                Count++;
                return true;
            }
            else
            {
                do
                {
                    if (slot.hash == hash && comparer.Equals(slot.value, item))
                    {
                        return false;
                    }
                    slot = slot.next;
                } while (slot != null);

                buckets[slotIndex] = new Slot { hash = hash, value = item, next = startSlot };
                Count++;
                return true;
            }
        }
        
        public bool Contains(T item)
        {
            var hash = InternalGetHashCode(item);
            var slot = buckets[hash % buckets.Length];
            if (slot == null)
            {
                return false;
            }
            else
            {
                do
                {
                    if (slot.hash == hash && comparer.Equals(slot.value, item))
                    {
                        return true;
                    }
                    slot = slot.next;
                } while (slot != null);

                return false;
            }
        }

        public bool Remove(T item)
        {
            var hash = InternalGetHashCode(item);
            var slot = buckets[hash % buckets.Length];

            Slot lastSlot = null;
            if (slot == null)
            {
                return false;
            }
            else
            {
                do
                {
                    if (slot.hash == hash && comparer.Equals(slot.value, item))
                    {
                        if (lastSlot != null)
                        {
                            lastSlot.next = slot.next;
                        }
                        else
                        {
                            buckets[hash % buckets.Length] = null;
                        }
                        Count--;
                        return true;
                    }
                    
                    lastSlot = slot;
                    slot = slot.next;
                } while (slot != null);

                return false;
            }
        }
        
        class Slot
        {
            internal int hash;
            internal T value;
            internal Slot next;
        }

        #region set methods I don't care about
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
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
