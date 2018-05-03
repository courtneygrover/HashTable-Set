/* 
     Name: Courtney Grover
     Class Description: Using a hashtable, creates a Set data structure - accompanied by other various methods.
*/

using System;
using System.Collections;

namespace Assignment1
{
    public class Set : ICollection, IEnumerable
    {
        private ArrayList set;
        private int size;

        public Set()
        {
            this.set = new ArrayList();
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public bool Empty
        {
            get
            {
                if (this.size == 0)
                    return true;

                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object this[int index]
        {
            get
            {
                if (index >= 0 && index < this.size)
                    return this.set[index];
                else
                    throw new IndexOutOfRangeException();

            }
        }

        public bool Contains(object o)
        {
            if (this.set.Contains(o))
                return true;

            return false;
        }

        public int Index(object o)
        {
            for (int x = 0; x < this.size; x++)
            {
                if (o.Equals(this.set[x]))
                    return x;
            }

            return -1;
        }

        public bool Add(object o)
        {
            if (Contains(o))
                return false;

            this.set.Add(o);
            this.size++;

            return true;
        }

        public bool Remove(object o)
        {
            if (Index(o) >= 0)
            {
                this.set.Remove(o);
                this.size--;
                return true;
            }

            return false;
        }

        public override bool Equals(object o)
        {
            if(o != null && o is Set)
            {
                Set s = (Set)o;
                
                foreach(object obj in this.set)
                {
                    if (!s.Contains(obj))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int sum = 0;
            for (int x = 0; x < this.set.Count; x++)
                sum += this.set[x].GetHashCode();
            return sum;
        }

        public override string ToString()
        {
            if (Empty)
                return "Set is empty.";
            string str = "[";
            for (int x = 0; x < this.set.Count - 1; x++)
                str += this.set[x] + ", ";
            str += this.set[this.set.Count - 1] + "]";
            return str;
        }

        public IEnumerator GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            this.set.CopyTo(array, index);
        }
    } //end class Set


}//end Namespace
