using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solutions
{
    public class Day3
    {
        readonly IEnumerable<string> _lines = File.ReadLines("C:/Users/Alexander/Desktop/day3input.txt");
        readonly string _regexString = @"[#](\d+)\s[@]\s(\d+)[,](\d+)[:]\s(\d+)[x](\d+)";

        public int Part1()
        {
            Regex regex = new Regex(_regexString);
            HashSet<(int, int)> setOfCoordinates = new HashSet<(int, int)>();
            HashSet<(int, int)> setOfDuplicates = new HashSet<(int, int)>();

            int numberOfDuplicateSquares = 0;

            //List<string> _lines = new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            foreach (var line in _lines)
            {
                Match match = regex.Match(line);

                var xMin = int.Parse(match.Groups[2].Value);
                var xMax = xMin + int.Parse(match.Groups[4].Value);
                var yMin = int.Parse(match.Groups[3].Value);
                var yMax = yMin + int.Parse(match.Groups[5].Value);

                for (int x = xMin; x < xMax; x++)
                {
                    for (int y = yMin; y < yMax; y++)
                    {
                        numberOfDuplicateSquares += !setOfCoordinates.Add((x, y)) && setOfDuplicates.Add((x, y)) ? 1 : 0;
                    }
                }
            }

            return numberOfDuplicateSquares;
        }

        public int Part2()
        {
            var _lines = this._lines.ToList();
            //List<string> _lines = new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            Regex regex = new Regex(_regexString);

            HashSet<int> distinctClaims = new HashSet<int>();
            Dictionary<Point,int> claimsAndCoordinates = new Dictionary<Point, int>();

            foreach (var line in _lines)
            {
                Match match = regex.Match(line);

                int xMin = int.Parse(match.Groups[2].Value);
                var xMax = xMin + int.Parse(match.Groups[4].Value);
                var yMin = int.Parse(match.Groups[3].Value);
                var yMax = yMin + int.Parse(match.Groups[5].Value);

                var claimID = int.Parse(match.Groups[1].Value);
                distinctClaims.Add(claimID);

                for (int x = xMin; x < xMax; x++)
                {
                    for (int y = yMin; y < yMax; y++)
                    {
                        var currentPoint = new Point(x, y);

                        if (claimsAndCoordinates.ContainsKey(currentPoint))
                        {
                            distinctClaims.Remove(claimsAndCoordinates[currentPoint]);
                            distinctClaims.Remove(claimID);
                        }
                        else
                        {
                            claimsAndCoordinates.Add(currentPoint, claimID);
                        }
                    }
                }
            }

            return distinctClaims.First();
        }
    }
}
