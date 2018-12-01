using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solutions
{
    public class Day1
    {
        internal readonly IEnumerable<int> _lines = File.ReadLines("C:/Users/Alexander/Desktop/input.txt").Select(x => Convert.ToInt32(x)).ToList();

        public int Part1()
        {
            var sum = 0;

            foreach (var line in _lines)
            {
                sum += line;
            }

            return sum;
        }

        public int Part2()
        {
            var sum = 0;
            bool sumIsUnique = true;
            HashSet<int> sumSet = new HashSet<int>();

            while (sumIsUnique)
            {
                foreach (var line in _lines)
                {
                    sum += line;

                    if (!sumSet.Contains(sum)) sumSet.Add(sum);
                    else
                    {
                        sumIsUnique = false;
                        break;
                    }
                }
            }

            return sum;
        }
    }
}