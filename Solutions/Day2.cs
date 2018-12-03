using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solutions
{
    public class Day2
    {
        readonly IEnumerable<string> _lines = File.ReadLines("C:/Users/Alexander/Desktop/day2input.txt");
        //List<string> _lines = new List<string> { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

        public int Test()
        {
            List<string> testInput = new List<string> { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

            int twiceOccurances = 0;
            int thriceOccurances = 0;

            foreach (var line in testInput)
            {
                var occuresTwice = line.GroupBy(x => x).Any(g => g.Count() == 2);
                var occuresThrice = line.GroupBy(x => x).Any(g => g.Count() == 3);

                twiceOccurances += occuresTwice ? 1 : 0;
                thriceOccurances += occuresThrice ? 1 : 0;

            }

            return twiceOccurances * thriceOccurances;
        }

        public int Part1()
        {
            var _lines = this._lines.ToList();

            var twiceOccurances = _lines.Count(x => x.GroupBy(y => y).Any(g => g.Count() == 2));
            var thriceOccurances = _lines.Count(x => x.GroupBy(y => y).Any(g => g.Count() == 3));
            return twiceOccurances * thriceOccurances;
        }

        public string Part2()
        {
            var _lines = this._lines.ToList();

            for (int i = 0; i < _lines.Count() - 1; i++)
            {
                var currentLine = _lines[i].ToCharArray();

                for (int j = i + 1; j < _lines.Count() - 1; j++)
                {
                    List<(char, int)> listOfDifferences = new List<(char, int)>();
                    var comparisonLine = _lines[j].ToCharArray();

                    for (int k = 0; k < currentLine.Length - 1; k++)
                    {
                        if (comparisonLine[k] != currentLine[k]) listOfDifferences.Add((comparisonLine[k], k));
                        if (listOfDifferences.Count > 1) break;
                    }

                    if (listOfDifferences.Count == 1)
                    {
                        var result = new string(currentLine).Remove(listOfDifferences[0].Item2, 1);
                        return result;
                    }

                }
            }

            return null;
        }
    }
}
