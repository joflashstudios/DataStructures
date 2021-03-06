﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    internal class Set2<T> : ISet<T>
    {
        private Slot[] _buckets = new Slot[3];

        private readonly EqualityComparer<T> _comparer = EqualityComparer<T>.Default;

        public bool IsReadOnly => false;
        public int Count { get; private set; } = 0;
        private int InternalGetHashCode(T item)
        {
            if (item == null)
            {
                return 0;
            }
            return _comparer.GetHashCode(item) & 2147483647;
        }

        public bool Add(T item)
        {
            var hash = InternalGetHashCode(item);
            var slotIndex = hash % _buckets.Length;
            var startSlot = _buckets[slotIndex];
            var slot = startSlot;
            if (slot == null)
            {
                _buckets[slotIndex] = new Slot { Hash = hash, Value = item };
                Count++;
                return true;
            }

            var collisions = 0;
            do
            {
                if (slot.Hash == hash && _comparer.Equals(slot.Value, item))
                {
                    return false;
                }
                slot = slot.Next;
                collisions++;
            } while (slot != null);

            _buckets[slotIndex] = new Slot { Hash = hash, Value = item, Next = startSlot };
            Count++;

            if (collisions > 10)
            {
                Expand();
            }
            return true;
        }
        
        public bool Contains(T item)
        {
            var hash = InternalGetHashCode(item);
            var slot = _buckets[hash % _buckets.Length];
            if (slot == null)
            {
                return false;
            }

            do
            {
                if (slot.Hash == hash && _comparer.Equals(slot.Value, item))
                {
                    return true;
                }
                slot = slot.Next;
            } while (slot != null);

            return false;
        }

        public bool Remove(T item)
        {
            var hash = InternalGetHashCode(item);
            var slot = _buckets[hash % _buckets.Length];

            Slot lastSlot = null;
            if (slot == null)
            {
                return false;
            }

            while (slot.Hash != hash || !_comparer.Equals(slot.Value, item))
            {
                lastSlot = slot;
                slot = slot.Next;
                if (slot == null)
                {
                    return false;
                }
            }

            if (lastSlot != null)
            {
                lastSlot.Next = slot.Next;
            }
            else
            {
                _buckets[hash % _buckets.Length] = null;
            }

            Count--;
            return true;
        }

        private void Expand()
        {
            var newSize = primes.First(x => x > _buckets.Length * 2);
            var newBuckets = new Slot[newSize];
            
            for (var bucketIndex = 0; bucketIndex < _buckets.Length;  bucketIndex++)
            {
                var slot = _buckets[bucketIndex];
                while(slot != null)
                {
                    var next = slot.Next;

                    var newIndex = slot.Hash % newSize;
                    if (newBuckets[newIndex] == null)
                    {
                        slot.Next = null;
                        newBuckets[newIndex] = slot;
                    }
                    else
                    {
                        slot.Next = newBuckets[newIndex];
                        newBuckets[newIndex] = slot;
                    }

                    slot = next;
                }
            }
            _buckets = newBuckets;
        }

        private class Slot
        {
            internal int Hash;
            internal T Value;
            internal Slot Next;
            public override string ToString()
            {
                return Value.ToString();
            }
        }

        private static readonly int[] primes = new int[]
        {
            3,
            7,
            11,
            17,
            23,
            29,
            37,
            47,
            59,
            71,
            89,
            107,
            131,
            163,
            197,
            239,
            293,
            353,
            431,
            521,
            631,
            761,
            919,
            1103,
            1327,
            1597,
            1931,
            2333,
            2801,
            3371,
            4049,
            4861,
            5839,
            7013,
            8419,
            10103,
            12143,
            14591,
            17519,
            21023,
            25229,
            30293,
            36353,
            43627,
            52361,
            62851,
            75431,
            90523,
            108631,
            130363,
            156437,
            187751,
            225307,
            270371,
            324449,
            389357,
            467237,
            560689,
            672827,
            807403,
            968897,
            1162687,
            1395263,
            1674319,
            2009191,
            2411033,
            2893249,
            3471899,
            4166287,
            4999559,
            5999471,
            7199369
        };


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
