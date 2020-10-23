using System.Collections.Generic;

namespace Extending06
{

    public class UniqueList<T> : List<T>
    {
        public void RemoveDuplicates()
        {
            base.Sort();
            int limit = this.Count;
            for (int i = limit-1; i > 0; i--)
 {
                if (this[i].Equals(this[i - 1]))
                {
                    this.RemoveAt(i);
                }
            }
        }
    }
}