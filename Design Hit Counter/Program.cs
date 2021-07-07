using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Hit_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            HitCounter hit = new HitCounter();
            hit.Hit(1);
            Console.WriteLine("Hit at 1");
            hit.Hit(2);
            Console.WriteLine("Hit at 2");
            hit.Hit(3);
            Console.WriteLine("Hit at 3");
            Console.WriteLine("Hit count at 4 is {0}",hit.GetHits(4));
            hit.Hit(300);
            Console.WriteLine("Hit at 300");
            Console.WriteLine("Hit count at 300 is {0}", hit.GetHits(300));
            Console.WriteLine("Hit count at 301 is {0}", hit.GetHits(301));
            Console.WriteLine("Hit count at 302 is {0}", hit.GetHits(302));

            Console.WriteLine("Hit count at 303 is {0}", hit.GetHits(303));
            Console.WriteLine("Hit count at 304 is {0}", hit.GetHits(304));
            Console.WriteLine("Hit count at 305 is {0}", hit.GetHits(305));

            Console.WriteLine("Hit count at 599 is {0}", hit.GetHits(599));
            Console.WriteLine("Hit count at 600 is {0}", hit.GetHits(600));
        }

        public class HitCounter
        {
            Queue<int> reference;
            /** Initialize your data structure here. */
            public HitCounter()
            {
                reference = new Queue<int>();
            }

            /** Record a hit.
                @param timestamp - The current timestamp (in seconds granularity). */
            public void Hit(int timestamp)
            {
                reference.Enqueue(timestamp);
            }

            /** Return the number of hits in the past 5 minutes.
                @param timestamp - The current timestamp (in seconds granularity). */
            public int GetHits(int timestamp)
            {
                while (reference.Count > 0)
                {
                    int diff = timestamp - reference.Peek();
                    if (diff >= 300) reference.Dequeue();
                    else break;
                }
                return reference.Count;
            }
        }

        /**
         * Your HitCounter object will be instantiated and called as such:
         * HitCounter obj = new HitCounter();
         * obj.Hit(timestamp);
         * int param_2 = obj.GetHits(timestamp);
         */
    }
}
